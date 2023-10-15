using Firebase.Auth;

namespace NutritionApp.Services.AuthService;

public class AuthService : IAuthService
{
    private FirebaseAuthClient firebaseAuth;
    private bool isInitialized = false;
    public User User { get; set; }


    public AuthService()
    {

    }

    private async Task Init()
    {
        if (!isInitialized)
        {
            var secretService = new SecretService(RestClientFactory.CreateRestClient("https://localhost:44349"));
            var config = await secretService.GetAuthConfig("123");
            firebaseAuth = new FirebaseAuthClient(config);
        }
    }

    public async Task<User> SignUp(string email, string password)
    {
        await Init();

        var userCredentials = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
        User = userCredentials.User;

        return User;
    }
    public async Task<User> Login(string email, string password)
    {
        await Init();

        var userCredentials = await firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
        User = userCredentials.User;

        return User;
    }

    public void SignOut() => firebaseAuth.SignOut();
}
