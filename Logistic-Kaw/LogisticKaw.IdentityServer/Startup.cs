using LogisticKaw.Application;
using LogisticKaw.Application.Helpers;
using LogisticKaw.Application.Services;
using LogisticKaw.Infra.Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogisticKaw.IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationModule();
            services.AddInfraDapperModule();

            // Setting the static resources configuration 
            var builder = services.AddIdentityServer();
            builder.AddInMemoryClients(IdentityConfigurationHelper.Clients)
                .AddInMemoryIdentityResources(IdentityConfigurationHelper.IdentityResources)
                .AddInMemoryApiResources(IdentityConfigurationHelper.ApiResources)
                .AddInMemoryApiScopes(IdentityConfigurationHelper.ApiScopes);
            //.AddTestUsers(IdentityConfiguration.TestUsers);
            //builder.AddOperationalStore();
            //builder.AddClientStore();
            //builder.AddResourceStore();
            //builder.P
            builder.AddClientConfigurationValidator<ClientConfigurationValidator>();
            builder.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            builder.AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Setting the middleware of Identity Server
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
