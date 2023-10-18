using Firebase.Auth;

namespace NutritionApp.Services;

public class AuthService : IAuthService
{
    private readonly FirebaseAuthClient _firebaseAuth;
    private UserCredential _userCredential;
    public User? CurrentUser => _userCredential?.User;

    public AuthService(FirebaseAuthClient firebaseAuth)
    {
        this._firebaseAuth = firebaseAuth;
    }

    public async Task SignUp(string email, string password)
    {
        _userCredential = await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);

    }

    public async Task Login(string email, string password)
    {
        _userCredential = await _firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
    }

    public void SignOut()
    {
        _userCredential = null;
        _firebaseAuth.SignOut();
    }
}
