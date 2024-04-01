using BackEnd.Infra.Context;

namespace BackEnd.Infra.Repositories;

public class UnitOfWork : IUnitOfWork , IDisposable
{

    private readonly PgContext _context;

    public UnitOfWork(PgContext context)=> _context = context;

    public async Task CommitAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
    
}
