using BackEnd.Domain.Dtos.Motorcycle;

namespace BackEnd.Infra.Repositories;

public interface IMotorcycleRepository
{

    Task<string> Get();

    Task<string> AddAsync(CreateMotorcycleDto entity);

    Task<string> FindByPlate(string plate);

    Task<string> PatchAsync(Guid id ,UpdateMotorcycleDto entity);

    Task<string?> DeleteAsync(Guid id);

}
