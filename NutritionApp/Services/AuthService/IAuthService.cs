namespace NutritionApp.Services.AuthService;

public interface IAuthService
{
    Task<string> SignUp(string email, string password);
    Task<string> Login(string email, string password);
    void SignOut();
}
