using Firebase.Auth;

namespace NutritionApp.Services.AuthService;

public interface IAuthService
{
    User User { get; set; }
    Task<User> SignUp(string email, string password);
    Task<User> Login(string email, string password);
    void SignOut();
}
