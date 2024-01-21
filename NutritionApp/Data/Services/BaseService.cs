using NutritionApp.Services;

namespace NutritionApp.Data.Services
{
    public class BaseService(IAuthService authService)
    {
        protected IAuthService AuthService { get; } = authService;

        protected string IdToken => AuthService.CurrentUser.Credential.IdToken;
        protected string UserId => AuthService.CurrentUser.Uid;
    }
}
