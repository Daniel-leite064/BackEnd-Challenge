using Microsoft.EntityFrameworkCore;
using BackEnd.Infra.Context;
using BackEnd.Infra.Repositories;
using BackEnd.Infra.Repositories.Abstractions;
using BackEnd.Api.Services.Abstractions;
using BackEnd.Api.Services;
using Amazon.SQS;

namespace BackEnd.Api.AppServiceConfig;

public static class AppConfig
{
    public static IServiceCollection AddConfig(
        this IServiceCollection _services,
        IConfiguration _configuration
    ) {
        string conn = _configuration.GetConnectionString("DefaultConnection")!;

        _services.AddDbContext<PgContext>(options =>
                options.UseNpgsql(conn)
        );

        _services.AddDefaultAWSOptions(_configuration.GetAWSOptions());
        _services.AddAWSService<IAmazonSQS>(); 
        _services.AddScoped<IAmazonS3Service, AmazonS3Service>();
   
        _services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        _services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        _services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        _services.AddScoped<ICourierRepository, CourierRepository>();
        

        return _services;

    }

}
