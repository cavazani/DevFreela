using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Infrastructure {
    public static class InfrastructureModule 
    {
        //Utilizando padrão Repository
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        { 
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }

        //Utilizando padrão Repository
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DevFreelaCs");

            services.AddDbContext<DevFreelaDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {  
            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
