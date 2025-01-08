using MyAuth.Models;

namespace MyAuth.Abstract
{
    public interface IUser
    {
        bool SignIn(SignInRequest request);
        bool SignUp(SignUpRequest request);
        IEnumerable<RoleResponse> GetRoles();
    }
}
