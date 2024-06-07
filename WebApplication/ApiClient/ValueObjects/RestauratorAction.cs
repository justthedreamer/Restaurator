namespace Razor_App.ApiClient.Actions;

public record RestauratorAction
{
    public string Value { get; }

    public RestauratorAction(string value)
    {
        Value = value;
    }

    public static implicit operator RestauratorAction(string value) => new(value);
    public static implicit operator string(RestauratorAction restauratorAction) => restauratorAction.Value;
}