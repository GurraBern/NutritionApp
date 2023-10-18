using Firebase.Auth;

namespace NutritionApp.Services;

public interface IAuthService
{
    User CurrentUser { get; }
    Task SignUp(string email, string password);
    Task Login(string email, string password);
    void SignOut();
}
