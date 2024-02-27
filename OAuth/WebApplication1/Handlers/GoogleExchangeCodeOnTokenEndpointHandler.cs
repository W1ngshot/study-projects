using System.Net.Http.Headers;

namespace WebApplication1.Handlers;

public class GoogleExchangeCodeOnTokenEndpointHandler
{
    private readonly HttpClient _httpClient;
    private readonly IConfigurationSection _googleConfiguration;

    public GoogleExchangeCodeOnTokenEndpointHandler(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://oauth2.googleapis.com/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _googleConfiguration = configuration.GetSection("Authentication:Google");
    }

    public async Task<string> Handle(string request)
    {
        using (_httpClient)
        {
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "client_id", _googleConfiguration["ClientId"]! },
                { "client_secret", _googleConfiguration["ClientSecret"]! },
                { "code", request },
                // TODO: Заменить здесь и в Google Auth Console redirect uri на frontend-страницу авторизации, вызывать эндпойнт с фронтенда
                { "redirect_uri", "https://localhost:7035/auth/google-code-token" }
            };
            var content = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync("token", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            return response.IsSuccessStatusCode 
                ? responseContent 
                : throw new Exception("INVALID_AUTH_CODE");
        }
    }
}