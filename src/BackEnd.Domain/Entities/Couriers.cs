using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Entities;

[Table("Couriers", Schema = "challengedb")]
public class Couriers : Entity
{

    public string? Name { get; set; }

    public string? Cnpj { get; set; }

    public DateTime DateBirth { get; set; }

    public string? LicenseDriverNumber { get; set; }

    public string? LicenseDriverType { get; set; }

    public bool Status { get; set; }

    [NotMapped]
    public Rental? Rental { get; set; }

    public Guid? IdRental { get; set; }


    public Couriers(string? name, string? cnpj, DateTime dateBirth, string? licenseDriverNumber, string? licenseDriverType, bool status)
    {
        ValidateModel(name, cnpj, dateBirth, licenseDriverNumber, licenseDriverType, status);
    }

     private void ValidateModel(string? name, string? cnpj, DateTime dateBirth, string? licenseDriverNumber, string? licenseDriverType, bool status)
    {
        EntityValidator.Validate(name!.Length > 50 || string.IsNullOrWhiteSpace(name), "Name can not be null or have less than 50 chars");
        EntityValidator.Validate(licenseDriverNumber!.Length > 20 || string.IsNullOrWhiteSpace(licenseDriverNumber), "Drive Number can not be null or have more than 20 chars");
        EntityValidator.Validate(string.IsNullOrWhiteSpace(cnpj), "CNPJ can not be null or empty");
        EntityValidator.Validate(cnpj!.Length != 14, "CNPJ needs to have 14 chars");
        EntityValidator.Validate(string.IsNullOrEmpty(licenseDriverType), "Driver Type can not be null");
        EntityValidator.Validate(!(licenseDriverType == "A" || licenseDriverType == "B" || licenseDriverType == "AB" ) , "Driver Type can not be null");
        EntityValidator.Validate(dateBirth == default , "Date Birth can not be null");

        Name = name;
        Cnpj = cnpj;
        DateBirth = dateBirth;
        LicenseDriverNumber = licenseDriverNumber;
        LicenseDriverType = licenseDriverType;
        Status = status;

    }


}
