using Razor_App.ApiClient.Actions;
using Razor_App.Model;

namespace Razor_App.ApiClient.Abstraction;

public interface IRestauratorApiClient
{
    public Task<HttpResponseMessage> HandleGetAsync(RestauratorAction action, AccessToken? accessToken);


    public Task<HttpResponseMessage> HandlePostAsync(RestauratorAction action, HttpContent? content,
        AccessToken? accessToken);


    public Task<HttpResponse> HandleUpdateAsync(RestauratorAction action, AccessToken? accessToken);


    public Task<HttpResponse> HandleDeleteAsync(RestauratorAction action, AccessToken? accessToken);

    public Task<AccessToken> GetAccessTokenFromResponseAsync(HttpResponseMessage responseMessage);
}