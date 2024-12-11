using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class SamplesController : Controller
    {
        public ActionResult Index()
        {
            //return Content("<h1>Hello STEP</h1>");
            City city = new City() { id=1, name="Almaty"};
            //return Json(city);
            //return RedirectToAction("List", "My");
            return StatusCode(204);
        }

        public ActionResult GetImage() 
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images/1.png");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/jpeg";
            string file_name = "10000.png";
            return File(fs, file_type, file_name);
        }

        [HttpGet, Route("s_1/{a}/{b}")]
        public ActionResult Details(string a, string b) 
        { 
            return Content(a + " " + b);
        }
    }
}
