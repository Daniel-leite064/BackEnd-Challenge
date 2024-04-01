using BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.EntityMapping;

public class NotificationsMap : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.IdCourier).IsRequired();
        builder.Property(x => x.IdOrder).IsRequired();
        builder.Property(x => x.DateNotification).IsRequired().HasColumnType("date");

    }
}
