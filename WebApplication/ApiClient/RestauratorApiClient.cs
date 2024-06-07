using System.Net.Http.Headers;
using Newtonsoft.Json;
using Razor_App.ApiClient.Abstraction;
using Razor_App.ApiClient.Actions;
using Razor_App.Model;

namespace Razor_App.ApiClient;

internal class RestauratorApiClient : IRestauratorApiClient
{
    private const string ApiPath = "http://localhost:5180";

    
    /// <summary>
    /// Handle restaurant api get method.
    /// </summary>
    /// <param name="action">Restaurant api action</param>
    /// <param name="accessToken">Access token</param>
    /// <returns><see cref="HttpResponse"/></returns>
    public async Task<HttpResponseMessage> HandleGetAsync(RestauratorAction action, AccessToken? accessToken)
    {
        var path = ApiPath + action;

        var httpClient = new HttpClient();

        if (accessToken is not null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await httpClient.GetAsync(path);
        return response;
    }

    public async Task<HttpResponseMessage> HandlePostAsync(RestauratorAction action, HttpContent? content,
        AccessToken? accessToken)
    {
        var path = ApiPath + action;

        var httpClient = new HttpClient();

        if (accessToken is not null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await httpClient.PostAsync(path, content);
        return response;
    }

    public async Task<HttpResponse> HandleUpdateAsync(RestauratorAction action, AccessToken? accessToken)
    {
        var path = ApiPath + action;
        throw new NotImplementedException();
    }

    public async Task<HttpResponse> HandleDeleteAsync(RestauratorAction action, AccessToken? accessToken)
    {
        var path = ApiPath + action;

        throw new NotImplementedException();
    }

    public async Task<AccessToken> GetAccessTokenFromResponseAsync(HttpResponseMessage responseMessage)
    {
        var responseContent = await responseMessage.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
        
        return new AccessToken(responseObject!.AccessToken);
    }

    private class LoginResponse()
    {
        public string AccessToken { get; set; }
    }
}