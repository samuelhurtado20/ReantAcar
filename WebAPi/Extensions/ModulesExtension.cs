using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebAPi.Data.Interceptors;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;
using WebAPi.Repositories;
using WebAPi.Services;

namespace WebAPi.Extensions;

public static class ModulesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(TimeProvider.System);
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
        return services;
    }

    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}