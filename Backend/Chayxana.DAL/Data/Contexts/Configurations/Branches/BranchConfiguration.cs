using Chayxana.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chayxana.DAL.Data.Contexts.Confiurations.Branches;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");

        builder.HasKey(b => b.Id); 

        builder.Property(b => b.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(b => b.Address)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(b => b.Password)
            .HasMaxLength(8)
            .IsRequired();

        builder.HasIndex(b => b.PhoneNumber)
            .IsUnique();

        builder.HasMany(b => b.Rooms)
            .WithOne(r => r.Branch)
            .HasForeignKey(r => r.BranchId);

        builder.HasMany(b => b.Employees)
            .WithOne(e => e.Branch)
            .HasForeignKey(e => e.BranchId);

        builder.HasMany(b => b.Feedbacks)
            .WithOne(f => f.Branch)
            .HasForeignKey(f => f.BranchId);
    }
}
