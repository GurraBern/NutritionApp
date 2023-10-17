using Firebase.Auth;
using Firebase.Auth.Providers;
using RestSharp;

namespace NutritionApp.Services.AuthService;

//Remove Class
public class SecretService
{
    private readonly IRestClient client;

    public SecretService(IRestClient client)
    {
        this.client = client;
    }

    public async Task<FirebaseAuthConfig> GetAuthConfig(string password)
    {
        var request = new RestRequest($"api/NutritionAuthentication/authConfig/{password}");
        //var secretResponse = await client.PostAsync<SecretResponse>(request);
        var authConfig = new FirebaseAuthConfig()
        {
            ApiKey = "AIzaSyAmS3ko0evWICq43ICyLqlmM3HJqNZpfDg",
            AuthDomain = "nutritiontracker-f8aba.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        };

        return authConfig;
    }

    private class SecretResponse
    {
        public string ApiKey { get; set; }
        public string AuthDomain { get; set; }
    }
}
