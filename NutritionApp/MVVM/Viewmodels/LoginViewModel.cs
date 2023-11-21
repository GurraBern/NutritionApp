using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Views;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class LoginViewModel : BaseViewModel, IAsyncInitialization
{
    //private readonly IToastService _toastService;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    private readonly IAuthService authService;
    public Task Initialization { get; private set; }

    public LoginViewModel(IAuthService authService)
    {
        this.authService = authService;

        Initialization = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await AutoLogin();
    }

    public async Task AutoLogin()
    {
        await authService.TryAutoLogin();

        if (authService.CurrentUser != null)
            await Shell.Current.GoToAsync(nameof(MainPage));

        IsBusy = false;
    }

    [RelayCommand]
    private async Task SignIn()
    {
        await authService.Login(Email, Password);

        if (authService.CurrentUser != null)
            await Shell.Current.GoToAsync(nameof(MainPage));
        //else
        //    await _toastService.MakeToast("Email or password is incorrect");
    }

    [RelayCommand]
    private async Task SignUp()
    {
        await authService.SignUp(Email, Password);

        if (authService.CurrentUser != null)
            await Shell.Current.GoToAsync(nameof(MainPage));
        //else
        //    await _toastService.MakeToast("Email or password is incorrect");
    }

    //[RelayCommand]
    //private async Task NavigateToSignUpPage() => await Shell.Current.GoToAsync(nameof(SignupPage));
}