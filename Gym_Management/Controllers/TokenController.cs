using Gym_Management.Models;
using Gym_Management.Repository.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
  
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly DBContext _ctx;
        private readonly ITokenService _service;
        public TokenController(DBContext ctx, ITokenService service)
        {
            this._ctx = ctx;
            this._service = service;

        }
        [Route("api/[controller]/Refresh")]
        [HttpPost]
        public IActionResult Refresh(RefreshTokenRequest tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = _service.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _ctx.TokenInfo.SingleOrDefault(u => u.Usename == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiry <= DateTime.Now)
                return BadRequest("Invalid client request");
            var newAccessToken = _service.GetToken(principal.Claims);
            var newRefreshToken = _service.GetRefreshToken();
            user.RefreshToken = newRefreshToken;
            _ctx.SaveChanges();
            return Ok(new RefreshTokenRequest()
            {
                AccessToken = newAccessToken.TokenString,
                RefreshToken = newRefreshToken
            });
        }

        // revoken is use for removing token entry
        [HttpPost, Authorize]
        [Route("api/[controller]/Revoke")]
        public IActionResult Revoke()
        {
            try
            {
                var username = User.Identity.Name;
                var user = _ctx.TokenInfo.SingleOrDefault(u => u.Usename == username);
                if (user is null)
                    return BadRequest();
                user.RefreshToken = null;
                _ctx.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
