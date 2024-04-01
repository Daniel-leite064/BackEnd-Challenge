using BackEnd.Domain.Dtos.Motorcycle;
using BackEnd.Domain.Entities;
using Newtonsoft.Json;

namespace BackEnd.Infra.Repositories;

public class MotorcycleRepository : IMotorcycleRepository
{

    private readonly IRepositoryBase<Motorcycle> _repositoryBase;
    private readonly IUnitOfWork _uow;

    public MotorcycleRepository(
            IRepositoryBase<Motorcycle> repositoryBase,
            IUnitOfWork unitOfWork
        )
    {
        _repositoryBase = repositoryBase;
        _uow = unitOfWork;
    }

    public async Task<string> Get()
    {

        return JsonConvert.SerializeObject(await _repositoryBase.Get());

    }

    public async Task<string> AddAsync(CreateMotorcycleDto entity)
    {
        var motorcycle = new Motorcycle(entity.Year, entity.Model, entity.LicensePlate, status: true);

        var alreadyExistMotorcycle = await _repositoryBase.Get(x => x.LicensePlate == entity.LicensePlate);

        if (alreadyExistMotorcycle.Any())
            throw new Exception("Motorcycle already exists");

        await _repositoryBase.AddAsync(motorcycle);

        await _uow.CommitAsync();

        return JsonConvert.SerializeObject(motorcycle);

    }

    public async Task<string> FindByPlate(string plate)
    {
        return JsonConvert.SerializeObject(await _repositoryBase.Get(e => e.LicensePlate == plate));
    }

    public async Task<string> PatchAsync(Guid id, UpdateMotorcycleDto entity)
    {
        if (id == Guid.Empty) throw new Exception("No ID was provided");

        var alreadyExistMotorcycle = await _repositoryBase.Get(x => x.Id == id);

        if (!alreadyExistMotorcycle.Any()) throw new Exception("No Motorcycle found");

        var motorcycle = alreadyExistMotorcycle.FirstOrDefault();

        motorcycle!.LicensePlate = entity.LicensePlate;

        await _repositoryBase.Update(motorcycle);
        await _uow.CommitAsync();

        return JsonConvert.SerializeObject(motorcycle);

    }

    public async Task<string?> DeleteAsync(Guid id)
    {
        if (id == Guid.Empty) throw new Exception("No ID was provided");

        var alreadyExistMotorcycle = await _repositoryBase.Get(x => x.Id == id);

        if (!alreadyExistMotorcycle.Any()) throw new Exception("No Motorcycle found");

        var motorcycle = alreadyExistMotorcycle.FirstOrDefault();

        if (motorcycle!.Rental is not null) {
            return default;
        }

        await _repositoryBase.Delete(motorcycle);
        await _uow.CommitAsync();

        return JsonConvert.SerializeObject(motorcycle);

    }

}
