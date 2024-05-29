using Core.ValueObject.Common;

namespace Core.Model.StaffModel;
/// <summary>
/// Represents user login credentials.
/// </summary>
public class Credentials
{
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    /// <summary>
    /// Change Password.
    /// </summary>
    /// <param name="password">New password</param>
    internal void ChangePassword(Password password) => Password = password;
    /// <summary>
    /// Changes Email.
    /// </summary>
    /// <param name="email">New email</param>
    internal void ChangeEmail(Email email) => Email = email;
    
    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Credentials()
    {
        
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="email">Email address</param>
    /// <param name="password">Password</param>
    public Credentials(Email email, Password password)
    {
        Email = email;
        Password = password;
    }
}