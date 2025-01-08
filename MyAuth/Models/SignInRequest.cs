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

    public class SignUpRequest
    {
        [Required, DisplayName("Логин")]
        public string login { get; set; }
        [Required, DisplayName("Пароль"), DataType(DataType.Password)]
        public string psw { get; set; }
        [Required, DisplayName("Пароль подтверждение"), DataType(DataType.Password), Compare("psw", ErrorMessage = "Пароли не совпадают")]
        public string psw2 { get; set; }
        [Required, DisplayName("Роль")]
        public string role { get; set; }
    }

    public class RoleResponse
    {
        public string id { get; set; }
        public string name { get; set; }
    }


    
}
