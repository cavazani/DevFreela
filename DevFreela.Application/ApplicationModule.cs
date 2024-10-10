using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application {
    public static class ApplicationModule 
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services
                .AddServices()
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            //RegisterServicesFromAssemblyContaining vai adicionar todos os serviçoes que estão implementando o IRequest e IRequestHandler do Assembly
            //Não tem a necessidade de adicionar um por um
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            return services;
        }
    }
}
