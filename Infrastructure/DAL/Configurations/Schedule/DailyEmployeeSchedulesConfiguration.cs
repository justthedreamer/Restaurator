using Core.Model.ScheduleModel;
using Core.ValueObject.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Schedule;

public class DailyEmployeeSchedulesConfiguration : IEntityTypeConfiguration<DailyEmployeeSchedule>
{
    public void Configure(EntityTypeBuilder<DailyEmployeeSchedule> builder)
    {
        builder.Property(x => x.DailyEmployeeScheduleId)
            .HasConversion(x => x.Value, x => new DailyEmployeeScheduleId(x));

        builder.HasKey(x => x.DailyEmployeeScheduleId);

        builder.Property(x => x.DailyScheduleDate)
            .HasConversion(x => x.Value, x => new DailyScheduleDate(x));

        builder.HasMany(x => x.EmployeeSchedules)
            .WithOne();
    }
}