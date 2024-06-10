using Application.DTO.User;
using AutoMapper;
using Core.Model.StaffModel;

namespace Infrastructure.Map;

internal partial class MainMapProfile
{
    partial void ApplyStaffMapping()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.Login,ex => ex.MapFrom(e => e.FirstName.Value))
            .ForMember(dto => dto.FirstName,ex => ex.MapFrom(e => e.FirstName.Value))
            .ForMember(dto => dto.LastName, ex => ex.MapFrom(e => e.LastName.Value))
            .ForMember(dto => dto.Login, ex => ex.MapFrom(e => e.EmployeeLogin.Value))
            .ForMember(dto => dto.Position, ex => ex.MapFrom(e => e.EmployeePosition.Value))
            .ForMember(dto => dto.Role, ex => ex.MapFrom(e => e.UserRole.Value))
            .ForMember(dto => dto.EmployeeId, ex => ex.MapFrom(e => e.UserId.Value));
    }
}