using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyMVC.Models
{
    public class City
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Название")]
        [MaxLength(5, ErrorMessage = "not more 5")]
        public string name { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime dt { get; set; }

        //[Remote(action: "CheckEmail", controller: "City", ErrorMessage = "Email уже используется")]
        //public string mail { get; set; }
    }
}
