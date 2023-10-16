using Firebase.Auth;

namespace NutritionApp.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly FirebaseAuthClient firebaseAuth;
    private bool isInitialized = false;
    public User User { get; set; }


    public AuthService(FirebaseAuthClient firebaseAuth)
    {
        this.firebaseAuth = firebaseAuth;
    }

    public async Task<User> SignUp(string email, string password)
    {
        var userCredentials = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
        User = userCredentials.User;

        return User;
    }
    public async Task<User> Login(string email, string password)
    {
        var userCredentials = await firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
        User = userCredentials.User;

        return User;
    }

    public void SignOut() => firebaseAuth.SignOut();
}
