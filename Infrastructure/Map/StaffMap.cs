using Application.DTO.User;
using AutoMapper;
using Core.Model.StaffModel;

namespace Infrastructure.Map;

internal partial class RestauratorMap
{
    partial void InitializeStaffMapping()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.Login, ex => ex.MapFrom(e => e.EmployeeLogin))
            .ForMember(dto => dto.Position, ex => ex.MapFrom(e => e.EmployeePosition))
            .ForMember(dto => dto.Role, ex => ex.MapFrom(e => e.UserRole));
    }
}