using Microsoft.AspNetCore.Authentication.Negotiate;

namespace MyWebAPI_Windows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                    .AddNegotiate();                      

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
