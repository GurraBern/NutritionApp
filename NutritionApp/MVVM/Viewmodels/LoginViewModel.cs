using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutritionApp.Services.AuthService;

namespace NutritionApp.MVVM.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    //private readonly IToastService _toastService;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;
    private readonly IAuthService authService;

    public LoginViewModel(IAuthService authService)
    {
        //Initialize();
        this.authService = authService;
    }

    //public async void Initialize()
    //{
    //    await AutoLogin();
    //}

    public async Task AutoLogin()
    {
        IsBusy = true;
        string savedEmail = await SecureStorage.Default.GetAsync("oauth_token_email");
        string savedPassword = await SecureStorage.Default.GetAsync("oauth_token_password");

        if (string.IsNullOrEmpty(savedEmail) || string.IsNullOrEmpty(savedPassword))
        {
            IsBusy = false;
            return;
        }

        Email = savedEmail;
        Password = savedPassword;

        var user = await authService.Login(savedEmail, savedPassword);

        if (user != null)
            await Shell.Current.GoToAsync("//Home");

        IsBusy = false;
    }

    [RelayCommand]
    private async Task SignIn()
    {
        var user = await authService.Login(Email, Password);

        if (user != null)
            await Shell.Current.GoToAsync("//MainPage");
        //else
        //    await _toastService.MakeToast("Email or password is incorrect");
    }

    [RelayCommand]
    private async Task SignUp()
    {
        var user = await authService.SignUp(Email, Password);

        if (user != null)
            await Shell.Current.GoToAsync("//MainPage");
        //else
        //    await _toastService.MakeToast("Email or password is incorrect");
    }

    //[RelayCommand]
    //private async Task NavigateToSignUpPage() => await Shell.Current.GoToAsync(nameof(SignupPage));
}