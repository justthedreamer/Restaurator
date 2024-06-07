using Application.DTO.User;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.StaffModel;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal class GetEmployeeProfileHandler(RestauratorDbContext dbContext,IMapper mapper) : IQueryHandler<GetEmployeeProfile,EmployeeDto>
{
    public async Task<EmployeeDto> HandleAsync(GetEmployeeProfile query)
    {
        var employee = await dbContext.Employees.SingleOrDefaultAsync(e => e.UserId.Value == query.EmployeeId);

        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        var profile = mapper.Map<Employee, EmployeeDto>(employee);
        return profile;
    }
}