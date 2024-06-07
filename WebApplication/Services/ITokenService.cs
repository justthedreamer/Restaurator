namespace Razor_App.Services;

public interface ITokenService
{
    void SetAccessToken(string token);
    string GetAccessToken();
}