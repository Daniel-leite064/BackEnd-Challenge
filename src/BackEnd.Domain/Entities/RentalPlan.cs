using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Entities;


[Table("Rental_Plan", Schema = "challengedb")]
public class RentalPlan : Entity
{

    public int Plan { get; set; }

    public string? Description { get; set; }

    public decimal CostPerDay { get; set; }

    public RentalPlan(int plan, string description, decimal costPerDay)
    {
        Plan = plan;
        Description = description;
        CostPerDay = costPerDay;
    }

}
