using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Model;
using System.Xml.Linq;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpGet, Route("Method_1")]
        public ActionResult Method_1()
        {
            return Ok("Hello STEP");
        }

        [HttpGet, Route("Method_2/{name}/{id}")]
        public ActionResult Method_2(string name, string id)
        {
            return Ok($"Hello {name} - {id}");
        }

        [HttpPost, Route("Method_3")]
        public ActionResult Method_3(Book book)
        {
            return Ok($"Hello {book.Id} - {book.Name} - {book.Content} - {book.Author}");
        }
    }
}
