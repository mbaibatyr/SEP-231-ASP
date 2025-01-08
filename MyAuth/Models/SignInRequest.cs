using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAuth.Models
{
    public class SignInRequest
    {
        [Required, DisplayName("Логин")]
        public string login { get; set; }
        [Required, DisplayName("Пароль"), DataType(DataType.Password)]
        public string psw { get; set; }
    }
}
