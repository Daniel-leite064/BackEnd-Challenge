using BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.EntityMapping;

public class RentalPlansMap : IEntityTypeConfiguration<RentalPlan>
{

    public void Configure(EntityTypeBuilder<RentalPlan> builder) {
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Plan);
        builder.Property(x => x.Description);
        builder.Property(x => x.CostPerDay);

        builder.HasIndex(x => x.Plan).IsUnique();

        builder.HasData(
            new RentalPlan(1, "7 days", 30),
            new RentalPlan(2, "15 days", 28),
            new RentalPlan(3, "30 days", 22)
        );

    }

}
