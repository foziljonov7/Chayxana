using Chayxana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chayxana.DAL.Data.Contexts.Confiurations.Users;

public class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
{
    public void Configure(EntityTypeBuilder<Revenue> builder)
    {
        builder.ToTable("revenues");

        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Employee)
            .WithMany(r => r.Revenues)
            .HasForeignKey(r => r.EmployeeId)
            .IsRequired();

        builder.Property(r => r.Amount)
            .IsRequired();
    }
}
