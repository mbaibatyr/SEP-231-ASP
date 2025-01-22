using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyWebAPI_BasicAUTH.Model;
using System.Xml.Linq;
using Dapper;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MyWebAPI_BasicAUTH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MyController : ControllerBase
    {
        [HttpGet, Route("Method_1")]
        public ActionResult Method_1()
        {
            var claim_psw = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "psw");
            var psw = claim_psw.Value;

            var Name = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok("Hello STEP");
        }

        [HttpGet, Route("Method_2/{name}/{id}"), AllowAnonymous]
        public ActionResult Method_2(string name, string id)
        {
            return Ok($"Hello {name} - {id}");
        }

        [HttpPost, Route("Method_3")]
        public ActionResult Method_3(Book book)
        {
            return Ok($"Hello {book.Id} - {book.Name} - {book.Content} - {book.Author}");
        }

        [HttpPut, Route("Method_4/{id}")]
        public ActionResult Method_4(string id, Book book)
        {
            using (SqlConnection db = new SqlConnection("Server=210-17;Database=MyDB;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("Id", id);
                p.Add("Name", book.Name);
                p.Add("Author", book.Author);
                p.Add("Content", book.Content);
                db.Execute("pBook", p, commandType: System.Data.CommandType.StoredProcedure);
                return Ok($"Updated");
            }
        }
        [HttpPut, Route("Method_4_1")]
        public ActionResult Method_4_1(Book book)
        {
            using (SqlConnection db = new SqlConnection("Server=210-17;Database=MyDB;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                DynamicParameters p = new DynamicParameters(book);
                db.Execute("pBook", new DynamicParameters(book), commandType: System.Data.CommandType.StoredProcedure);
                return Ok($"Updated");
            }
        }

        [HttpPost, Route("Method_4_2")]
        public ActionResult Method_4_2(List<Book> books)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Book book in books)
            {
                sb.AppendLine($"{book.Name} - {book.Author}");
            }
            return Ok(sb.ToString());
        }

        [HttpPost, Route("Method_5/{id}")]
        public ActionResult Method_5(string id, AuthorMain model)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var book in model.Books)
            {
                sb.AppendLine($"{book.Name} - {model.Author}");
            }
            sb.AppendLine($"{id} - {id}");
            return Ok(sb.ToString());
        }

        [HttpGet, Route("Method_6")]
        public int Method_6(string id)
        {
            return int.Parse(id) * int.Parse(id);
        }

        [HttpGet, Route("Method_7")]
        public HttpResponseMessage Method_7()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost, Route("Method_8")]
        public ActionResult Method_8(string[] lst)
        {
            return Ok($"{lst.Length}");
        }

        [HttpGet, Route("Method_9")]
        public Book Method_9(string Author, string BookName)
        {
            return new Book { Name = BookName, Author = Author };
        }

        [HttpGet, Route("Method_10")]
        public ActionResult Method_10(string id)
        {
            if (id == "1")
                return Ok();
            else if (id == "2")
                return NotFound("не найден");
            else if (id == "3")
                return BadRequest("кривые параметры");
            else if (id == "4")
                return Unauthorized("не автризваон");
            else if (id == "5")
                return NotFound("не найден");
            else if (id == "6")
                return NoContent();
            else return Ok("ok");
        }

        [HttpPost, Route("Method_11")]
        public ActionResult Method_11([FromBody] string id)
        {
            return Ok(id);
        }

        [HttpGet, Route("Method_12")]
        public ActionResult Method_12([FromQuery] City city)
        {
            return Ok($"{city.Id}  {city.Name}");
        }
    }
}
