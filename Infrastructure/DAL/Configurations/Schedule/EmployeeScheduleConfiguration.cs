using Core.Model.ScheduleModel;
using Core.ValueObject.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Schedule;

public class EmployeeScheduleConfiguration : IEntityTypeConfiguration<EmployeeSchedule>
{
    public void Configure(EntityTypeBuilder<EmployeeSchedule> builder)
    {
        builder.Property(x => x.EmployeeScheduleId)
            .HasConversion(x => x.Value, x => new EmployeeScheduleId(x));

        builder.HasKey(x => x.EmployeeScheduleId);

        builder.Property(x => x.ScheduleState)
            .HasConversion(x => x.Value, x => new ScheduleState(x));

        builder.HasOne(x => x.Employee)
            .WithMany();

        builder.Property(x => x.From)
            .HasConversion(x => x.Value, x => new EmployeeScheduleDate(x));
        
        builder.Property(x => x.To)
            .HasConversion(x => x.Value, x => new EmployeeScheduleDate(x));
    }
}