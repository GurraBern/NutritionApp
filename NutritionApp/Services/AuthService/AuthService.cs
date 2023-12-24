using Firebase.Auth;

namespace NutritionApp.Services;

public class AuthService(FirebaseAuthClient firebaseAuth) : IAuthService
{
    private UserCredential _userCredential;
    public User CurrentUser => _userCredential?.User;

    public async Task SignUp(string email, string password)
    {
        _userCredential = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
    }

    public async Task Login(string email, string password)
    {
        _userCredential = await firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
        if (_userCredential != null)
        {
            await SecureStorage.SetAsync("email", email);
            await SecureStorage.SetAsync("password", password);
        }
    }

    public async Task TryAutoLogin()
    {
        var email = await SecureStorage.GetAsync("email");
        var password = await SecureStorage.GetAsync("password");

        if (email != null && password != null)
            await Login(email, password);
    }

    public void SignOut()
    {
        _userCredential = null;
        firebaseAuth.SignOut();
    }
}
