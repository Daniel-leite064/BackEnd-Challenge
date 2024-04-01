namespace BackEnd.Domain.Dtos.Couriers;

public class CreateCourierDto
{

    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public DateTime DateBirth { get; set; }
    public string? LicenseDriverNumber { get; set; }
    public string? LicenseDriverType { get; set; }


}
