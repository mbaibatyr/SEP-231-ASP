using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI_Windows.Controllers
{
    [Route("[controller]")]
    [ApiController, Authorize]
    public class MyController : ControllerBase
    {
        [HttpGet, Route("Test")]
        public ActionResult Test() 
        {
            var username = User.Identity.Name.Split('\\')[1];
            return Ok(username);
        }
    }
}
