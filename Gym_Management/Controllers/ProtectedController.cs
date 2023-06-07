using Gym_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
   
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetData()
        {
            var status = new Status();
            status.StatusCode = 1;
            status.Message = "Data from protected controller";
            return Ok(status);
        }
    }
}
