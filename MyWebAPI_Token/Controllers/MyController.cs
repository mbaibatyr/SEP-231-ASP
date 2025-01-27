using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI_Token.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebAPI_Token.Controllers
{
    [Route("[controller]")]
    [ApiController, Authorize]
    public class MyController : ControllerBase
    {
        IConfiguration config;
        public MyController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet, Route("getDateTime") ]
        public ActionResult getDateTime()
        {
            return Ok(DateTime.Now.ToString("dd.MM.yyyy"));
        }

        [HttpPost, Route("GetToken"), AllowAnonymous]
        public ActionResult GetToken(UserModel model)
        {
            try
            {

                /*
                 проверка в БД
                 */

                //return Unauthorized(new ReturnStatus
                //{
                //    status = StatusEnum.ERROR,
                //    result = "error"
                //});

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

                var claims = new[] {
                      new Claim("myRole", "admin"),
                      new Claim("dateBirth", "2000-01-01")
            };

                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    //claims,
                    null,
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: credentials);

                var sToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new ReturnStatus
                {
                    status = StatusEnum.OK,
                    result = sToken
                });
            }
            catch (Exception err)
            {
                return Ok(new ReturnStatus
                {
                    status = StatusEnum.ERROR,
                    result = "ERROR",
                    error = err.Message
                });
            }
        }
    }
}
