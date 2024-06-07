using Core.Model.StaffModel;
using Core.ValueObject.Common;

namespace Core.Repositories;

/// <summary>
/// Owner repository interface
/// </summary>
public interface IOwnerRepository
{
    /// <summary>
    /// Get owner by its Email Address
    /// </summary>
    /// <param name="email">Emaill address</param>
    /// <returns>Owner or null if not found.</returns>
    Task<Owner?> GetOwnerByEmailAsync(Email email);

    /// <summary>
    /// Register new account
    /// </summary>
    /// <param name="owner">Owner instance</param>
    Task RegisterAccountAsync(Owner owner);

    /// <summary>
    /// Update owner profile
    /// </summary>
    /// <param name="owner">Owner instance</param>
    Task UpdateOwnerAsync(Owner owner);
}