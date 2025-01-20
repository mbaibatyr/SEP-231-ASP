using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyWebAPI.Model;
using System.Xml.Linq;
using Dapper;
using System.Text;

namespace MyWebAPI.Controllers
{
    [Route("[controller]")]
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
    }
}
