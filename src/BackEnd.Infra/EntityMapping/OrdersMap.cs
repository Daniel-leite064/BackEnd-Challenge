using BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.EntityMapping;

public class OrdersMap : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreationDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.RideCost).IsRequired();
        builder.Property(x => x.Status).IsRequired();

    }
}
