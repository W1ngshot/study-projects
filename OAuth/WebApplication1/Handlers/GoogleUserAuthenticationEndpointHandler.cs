using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApplication1.Handlers;

public class GoogleUserAuthenticationEndpointHandler
{
    private readonly HttpClient _httpClient;
    
    public GoogleUserAuthenticationEndpointHandler()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://www.googleapis.com/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<GoogleGetUserInfoResponse> Handle(string request)
    {
        GoogleGetUserInfoResponse googleUser;
        using (_httpClient)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request);

            var response = await _httpClient.GetAsync("oauth2/v1/userinfo?alt=json");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if(!response.IsSuccessStatusCode)
                throw new Exception("INCORRECT_AUTH_TOKEN");

            googleUser = JsonConvert.DeserializeObject<GoogleGetUserInfoResponse>(responseContent)!;
        }

        return googleUser;
    }
}

public class GoogleGetUserInfoResponse
{
    [JsonProperty("given_name")]
    public string? GivenName { get; set; }
    [JsonProperty("verified_email")]
    public bool VerifiedEmail { get; set; }
    public string? Picture { get; set; }
    public string? Locale { get; set; }
}