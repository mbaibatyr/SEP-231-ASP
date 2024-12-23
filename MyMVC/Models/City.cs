using System.ComponentModel.DataAnnotations;

namespace MyMVC.Models
{
    public class City
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string name { get; set; }
    }
}
