using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using MyAuth.Abstract;
using MyAuth.Models;
using System.Data;

namespace MyAuth.Service
{
    public class UserService : IUser
    {
        IConfiguration config;
        public UserService(IConfiguration config)
        {
            this.config = config;
        }

        public IEnumerable<RoleResponse> GetRoles()
        {
            using (SqlConnection db = new SqlConnection(config["db"]))
            {                
                return db.Query<RoleResponse>("[dbo].[pRole]", commandType: System.Data.CommandType.StoredProcedure);                
            }
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

        public bool SignUp(SignUpRequest request)
        {
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                //DynamicParameters p = new DynamicParameters(request);
                var result = db.ExecuteScalar<string>("[dbo].pUsers;2", new { @login = request.login, @psw = request.psw, @role = request.role }, commandType: System.Data.CommandType.StoredProcedure);
                return result == "1" ? false : true;
            }
        }
    }
}
