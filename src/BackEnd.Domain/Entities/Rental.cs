using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Entities;

[Table("Rental", Schema = "challengedb")]
public class Rental : Entity
{
    public IEnumerable<Motorcycle>? Motorcycles { get; set; }
    
    public Guid? IdMotorcycle { get; set; }
    
    public IEnumerable<Couriers>? Couriers { get; set; }
    
    public Guid? IdCourier { get; set; }

    public RentalPlan? RentalPlan { get; set; }

    public Guid? IdRentalPlans { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime ExpectedEndDate { get; set; }

    public decimal TotalCost { get; set; }

    public string? Status { get; set; }


}
