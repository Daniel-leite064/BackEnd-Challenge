namespace BackEnd.Infra.Repositories;

public interface IUnitOfWork
{

    Task CommitAsync();

}
