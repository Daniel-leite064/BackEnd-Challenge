using BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.EntityMapping;

public class CouriersMap : IEntityTypeConfiguration<Couriers>
{
    public void Configure(EntityTypeBuilder<Couriers> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Cnpj).IsRequired();
        builder.Property(x => x.DateBirth).IsRequired().HasColumnType("date");
        builder.Property(x => x.LicenseDriverType).HasMaxLength(2).IsRequired();
        builder.Property(x => x.LicenseDriverNumber).HasMaxLength(20).IsRequired();

        builder.HasIndex(x => x.Cnpj).IsUnique();
        builder.HasIndex(x => x.LicenseDriverNumber).IsUnique();

    }
}
