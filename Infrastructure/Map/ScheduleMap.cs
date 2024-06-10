using Application.DTO;
using Core.Model.ScheduleModel;

namespace Infrastructure.Map;

internal partial class MainMapProfile
{
    partial void ApplySchedulesMapping()
    {
        CreateMap<EmployeeSchedule, EmployeeScheduleDto>()
            .ForMember(dto => dto.EmployeeId, ex => ex.MapFrom(e => e.Employee.UserId))
            .ForMember(dto => dto.EmployeeName, ex => ex.MapFrom(e => $"{e.Employee.FirstName.Value} {e.Employee.LastName.Value}"));
        
        CreateMap<(DailyEmployeeSchedule, IEnumerable<EmployeeScheduleDto>), DailyEmployeeScheduleDto>()
            .ForMember(dto => dto.EmployeeSchedules, ex => ex.MapFrom(source => source.Item2))
            .ForMember(dto => dto.Id, ex => ex.MapFrom(source => source.Item1.DailyEmployeeScheduleId));

    }
}