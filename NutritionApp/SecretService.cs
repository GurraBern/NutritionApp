using Firebase.Auth;
using Firebase.Auth.Providers;
using RestSharp;

namespace NutritionApp;

public class SecretService
{
    private readonly IRestClient client;

    public SecretService(IRestClient client)
    {
        this.client = client;
    }

    public async Task<FirebaseAuthConfig> GetAuthConfig()
    {
        //TEMP - /authConfig/123 is the password to fetch authConfig
        var request = new RestRequest($"api/NutritionAuthentication/authConfig/123");
        var secretResponse = await client.PostAsync<SecretResponse>(request);
        var authConfig = new FirebaseAuthConfig()
        {
            ApiKey = secretResponse.ApiKey,
            AuthDomain = secretResponse.AuthDomain,
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
