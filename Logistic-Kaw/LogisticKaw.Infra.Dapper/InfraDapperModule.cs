using LogisticKaw.Domain.Adapters;
using LogisticKaw.Domain.Interfaces;
using LogisticKaw.Infra.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace LogisticKaw.Infra.Dapper
{
    public static class InfraDapperModule
    {
        public static void AddInfraDapperModule(this IServiceCollection services)
        {
            //services.AddTransient<Interface, Implementation>();
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
