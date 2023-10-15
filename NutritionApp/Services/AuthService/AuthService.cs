using Firebase.Auth;

namespace NutritionApp.Services.AuthService;

public class AuthService : IAuthService
{
    private FirebaseAuthClient firebaseAuth;
    private bool isInitialized = false;

    public AuthService()
    {

    }

    private async Task Init()
    {
        if (!isInitialized)
        {
            var secretService = new SecretService(RestClientFactory.CreateRestClient("https://localhost:44349"));
            var config = await secretService.GetAuthConfig();
            firebaseAuth = new FirebaseAuthClient(config);
        }
    }

    public async Task<string> SignUp(string email, string password)
    {
        await Init();

        var userCredentials = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
        return userCredentials is null ? null : await userCredentials.User.GetIdTokenAsync();
    }
    public async Task<string> Login(string email, string password)
    {
        await Init();

        var userCredentials = await firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
        return userCredentials is null ? null : await userCredentials.User.GetIdTokenAsync();
    }

    public void SignOut() => firebaseAuth.SignOut();
}
