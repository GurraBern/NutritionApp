using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public NavigationService NavigationService { get; }

    public LoginViewModel(IAuthService authService, IToastService toastService, NavigationService navigationService)
    {
        this.authService = authService;
        this.toastService = toastService;
        NavigationService = navigationService;
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
            await NavigationService.NavigateToDashboard();

        IsBusy = false;
    }

    [RelayCommand]
    private async Task SignIn()
    {
        try
        {
            await authService.Login(Email, Password);

            if (authService.CurrentUser != null)
                await NavigationService.NavigateToDashboard();
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
                await NavigationService.NavigateToDashboard();
        }
        catch (Exception)
        {
            await toastService.MakeToast("Could not create account");
        }
    }
}