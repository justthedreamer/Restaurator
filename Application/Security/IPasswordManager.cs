namespace Application.Security;

/// <summary>
/// Password Manager interface
/// </summary>
public interface IPasswordManager
{
    /// <summary>
    /// Hash given password
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <returns>Hashed password</returns>
    string Secure(string password);
    /// <summary>
    /// Validate given password
    /// </summary>
    /// <param name="password">Given password</param>
    /// <param name="securePassword">Secure password</param>
    /// <returns>True or false</returns>
    bool Validate(string password, string securePassword);
}