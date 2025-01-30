using Microsoft.AspNetCore.Authentication.Negotiate;

namespace MyWebAPI_Windows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                    .AddNegotiate();
            builder.Services.AddControllers();

            var app = builder.Build();            

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
