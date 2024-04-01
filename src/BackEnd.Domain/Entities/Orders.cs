using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Entities;

[Table("Orders", Schema = "challengedb")]
public class Orders : Entity
{

    [ForeignKey("Couriers")]
    public Guid IdCourier { get; set; }

    public DateTime CreationDate { get; set; }

    public decimal RideCost { get; set; }

    public string? Status { get; set; }

}
