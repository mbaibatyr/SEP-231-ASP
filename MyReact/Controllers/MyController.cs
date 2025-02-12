using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyReact.Model;

namespace MyReact.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpGet, Route("FillSelect")]
        public ActionResult FillSelect()
        {
            List<ForSelect> lst = new List<ForSelect>()
            {
                new ForSelect{ Value="1", Text = "Kazakhstan"},
                new ForSelect{ Value="2", Text = "Russia"},
                new ForSelect{ Value="3", Text = "USA"},
            };
            return Ok(lst);
        }
    }
}
