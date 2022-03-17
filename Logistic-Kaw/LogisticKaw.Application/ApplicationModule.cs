using IdentityServer4.Validation;
using LogisticKaw.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticKaw.Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            //services.AddTransient<Interface, Implementation>();
            //services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
        }
    }
}
