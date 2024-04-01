using BackEnd.Domain.Dtos.Couriers;

namespace BackEnd.Infra.Repositories.Abstractions;

public interface ICourierRepository
{
    Task<string> Get();

    Task<string> AddAsync(CreateCourierDto entity);

    // Task<string> PatchAsync(Guid id ,UpdateMotorcycleDto entity);

    Task<string?> DeleteAsync(Guid id);

}
