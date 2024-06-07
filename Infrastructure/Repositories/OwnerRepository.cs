using Core.Model.StaffModel;
using Core.Repositories;
using Core.ValueObject.Common;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Owner repository implementation
/// </summary>
internal sealed class OwnerRepository(RestauratorDbContext dbContext) : IOwnerRepository
{
    private readonly DbSet<Owner> _owners = dbContext.Owners;

    /// <summary>
    /// Get owner by its Email Address
    /// </summary>
    /// <param name="email">Emaill address</param>
    /// <returns>Owner or null if not found.</returns>
    public async Task<Owner?> GetOwnerByEmailAsync(Email email)
    {
        var owner = await _owners.SingleOrDefaultAsync(x => x.Credentials.Email == email);
        return owner;
    }

    /// <summary>
    /// Register new account
    /// </summary>
    /// <param name="owner">Owner instance</param>
    public async Task RegisterAccountAsync(Owner owner)
    {
        _owners.Add(owner);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateOwnerAsync(Owner owner)
    {
        _owners.Update(owner);
        await dbContext.SaveChangesAsync();
    }
}