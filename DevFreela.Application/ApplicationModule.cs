using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application {
    public static class ApplicationModule 
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            //RegisterServicesFromAssemblyContaining vai adicionar todos os serviçoes que estão implementando o IRequest e IRequestHandler do Assembly
            //Não tem a necessidade de adicionar um por um
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());
            services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();

            return services;
        }
    }
}
