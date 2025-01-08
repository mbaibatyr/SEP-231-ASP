using Dapper;
using Microsoft.Data.SqlClient;
using MyAuth.Abstract;
using MyAuth.Models;

namespace MyAuth.Service
{
    public class UserService : IUser
    {
        IConfiguration config;
        public UserService(IConfiguration config)
        {
            this.config = config;
        }
        public bool SignIn(SignInRequest request)
        {
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                DynamicParameters p = new DynamicParameters(request);
                var result = db.Query<dynamic>("[dbo].[pUsers]", p, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                return result != null ? true : false;
            }
        }
    }
}
