using BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.EntityMapping;

public class MotorcyclesMap : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Year);
        builder.Property(x => x.Model).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LicensePlate).HasMaxLength(10).IsRequired();

        builder.HasIndex(x => x.LicensePlate).IsUnique();

        builder.HasData(
            new Motorcycle(2022, "CB 300F Twister", "JTY-1906", status: true),
            new Motorcycle(2015, "CB 500F", "MNF-3564", status: true),
            new Motorcycle(2022, "Forza 350", "KKH-9067", status: true)
        );

    }
}
