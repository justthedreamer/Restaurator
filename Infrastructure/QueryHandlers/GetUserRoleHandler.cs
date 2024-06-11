using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetUserRoleHandler(RestauratorDbContext dbContext) : IQueryHandler<GetUserRole,UserRole>
{
    public async Task<UserRole> HandleAsync(GetUserRole query)
    {
        var userId = new UserId(query.UserId);

        var employee = await dbContext.Employees.SingleOrDefaultAsync(e => e.UserId == userId);

        if (employee is not null)
        {
            return employee.UserRole;
        }

        var owner = await dbContext.Owners.SingleOrDefaultAsync(o => o.UserId == userId);

        if (owner is not null)
        {
            return owner.UserRole;
        }

        throw new UserNotFoundException();
    }
}