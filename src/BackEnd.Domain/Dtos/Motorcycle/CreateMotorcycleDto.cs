using System.Text.Json.Serialization;

namespace BackEnd.Domain.Dtos.Motorcycle;

public class CreateMotorcycleDto
{
    public int Year { get; set; }
    public string? Model { get; set; }
    public string? LicensePlate { get; set; }

}
