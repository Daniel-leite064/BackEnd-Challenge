using BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.EntityMapping;

public class RentalsMap : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.StartDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.EndDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.ExpectedEndDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.TotalCost).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(10).IsRequired();

        builder.HasMany(x => x.Motorcycles)
                    .WithOne(x => x.Rental)
                    .HasForeignKey(x => x.IdRental)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(false);

        builder.HasMany(x => x.Couriers)
                    .WithOne(x => x.Rental)
                    .HasForeignKey(x => x.IdRental)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(false);
                    
    }
}
