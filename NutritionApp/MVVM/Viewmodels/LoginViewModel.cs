using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutritionApp.MVVM.Views;
using NutritionApp.Services;

namespace NutritionApp.MVVM.ViewModels;

public partial class LoginViewModel : BaseViewModel, IAsyncInitialization
{
    private readonly IToastService toastService;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    private readonly IAuthService authService;
    public Task Initialization { get; private set; }

    public LoginViewModel(IAuthService authService, IToastService toastService)
    {
        this.authService = authService;
        this.toastService = toastService;
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
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

        IsBusy = false;
    }

    [RelayCommand]
    private async Task SignIn()
    {
        try
        {
            await authService.Login(Email, Password);

            if (authService.CurrentUser != null)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        catch (Exception)
        {
            await toastService.MakeToast("Email or password is incorrect");
        }
    }

    [RelayCommand]
    private async Task SignUp()
    {
        try
        {
            await authService.SignUp(Email, Password);

            if (authService.CurrentUser != null)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        catch (Exception)
        {
            await toastService.MakeToast("Could not create account");
        }
    }
}