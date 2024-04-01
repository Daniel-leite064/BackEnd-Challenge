using System.ComponentModel.DataAnnotations.Schema;
namespace BackEnd.Domain.Entities;

[Table("Notification", Schema = "challengedb")]
public class Notification : Entity
{

    public DateTime DateNotification { get; set; }

    public Guid IdOrder { get; set; }

    public Guid IdCourier { get; set; }

}
