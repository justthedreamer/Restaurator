using Application.Security;
using Core.Model.StaffModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Infrastructure.Security;

public class PasswordManager(IPasswordHasher<User> passwordHasher) : IPasswordManager
{
    /// <summary>
    /// Hash password
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <returns></returns>
    public string Secure(string password)
    {
        return passwordHasher.HashPassword(default!, password);
    }

    /// <summary>
    /// Validate given password
    /// </summary>
    /// <param name="password">Password</param>
    /// <param name="securedPassword">Hashed password</param>
    /// <returns></returns>
    public bool Validate(string password, string securedPassword)
    {
        return passwordHasher.VerifyHashedPassword(default!, securedPassword, password) ==
               PasswordVerificationResult.Success;
    }
}