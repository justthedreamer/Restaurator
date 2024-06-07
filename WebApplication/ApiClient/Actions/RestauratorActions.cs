namespace Razor_App.ApiClient.Actions;

public static class RestauratorActions
{
    public static string GetOwnerProfile(Guid ownerId) => $"/owner/{ownerId}";
    public static string RegisterUser = "/sign-up";
    public static string OwnerSignIn = "/owner/sign-in";
    public static string EmployeeSignIn = "/employee/sign-in";
}