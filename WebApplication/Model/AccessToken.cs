namespace Razor_App.Model;

public sealed record AccessToken(string Value)
{
    public static implicit operator AccessToken(string value) => new(value);
    public static implicit operator string(AccessToken accessToken) => accessToken.Value;
}