using BackEnd.Domain.Dtos.Couriers;
using BackEnd.Domain.Entities;
using BackEnd.Infra.Repositories.Abstractions;
using Newtonsoft.Json;

namespace BackEnd.Infra.Repositories;

public class CourierRepository : ICourierRepository
{

    private readonly IRepositoryBase<Couriers> _repositoryBase;
    private readonly IUnitOfWork _uow;

    public CourierRepository(
            IRepositoryBase<Couriers> repositoryBase,
            IUnitOfWork uow
        )
    {
        _uow = uow;
        _repositoryBase = repositoryBase;
    }

    public async Task<string> Get()
    {

        return JsonConvert.SerializeObject(await _repositoryBase.Get());

    }

    public async Task<string> AddAsync(CreateCourierDto entity)
    {
        var courier = new Couriers(
            entity.Name,
            entity.Cnpj,
            entity.DateBirth,
            entity.LicenseDriverNumber,
            entity.LicenseDriverType,
            status: true);

        var alreadyExistCourier = await _repositoryBase.Get(x => x.Cnpj == entity.Cnpj || x.LicenseDriverNumber == entity.LicenseDriverNumber);

        if (alreadyExistCourier.Any())
            throw new Exception("Courier already exists");

        await _repositoryBase.AddAsync(courier);

        await _uow.CommitAsync();

        return JsonConvert.SerializeObject(courier);

    }
    
    public Task<string?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

}
