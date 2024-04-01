using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Entities;

[Table("Motorcycle", Schema = "challengedb")]
public class Motorcycle : Entity
{
    public int Year { get; set; }

    public string? Model { get; set; }

    public string? LicensePlate { get; set; }

    public bool? Status { get; set; }

    [NotMapped]
    public Rental? Rental { get; set; }

    [NotMapped]
    public Guid? IdRental { get; set; }

    public Motorcycle() { }

    public Motorcycle(int year, string? model, string? licensePlate, bool status)
    {
        ValidateModel(year, model, licensePlate, status);

    }

    private void ValidateModel(int year, string? model, string? licensePlate, bool status)
    {
        EntityValidator.Validate(year < 1900 || year > 2200, "Year must be between 1900 and 2200");
        EntityValidator.Validate(string.IsNullOrEmpty(model), "Model can not be null");
        EntityValidator.Validate(string.IsNullOrEmpty(licensePlate), "LicensePlate can not be null");
        EntityValidator.Validate(licensePlate!.Length > 10, "LicensePlate characters can not be higher than 10");

        Year = year;
        Model = model;
        LicensePlate = licensePlate;
        Status = status;

    }


}
