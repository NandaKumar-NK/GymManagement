using Gym_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Gym_Management.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        
        [HttpGet]
       
        public IActionResult GetData()
            {
                var status = new Status();
                status.StatusCode = 1;
                status.Message = "Data from admin controller";
                return Ok(status);
            }
        }
    
}
