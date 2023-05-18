using Employee.Management.Application.Contracts.Persistence;
using Employee.Management.Persistence.DataBaseContext;
using Employee.Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Persistence;

public static class PersistenceServiceRegistration
{

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<EmployeeDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("EmployeeConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
}
