using Microsoft.EntityFrameworkCore;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Communicator.Concrete;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.ApplicationService.Service.Concrete;
using PersonalProject.Domain;
using PersonalProject.Domain.Aggregate.Repositories;
using PersonalProject.Repository;
using PersonalProject.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using PersonalProject.ApplicationService.Authorization.Abstract;
using PersonalProject.ApplicationService.Authorization.Concrete;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {

        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(
                 this IServiceCollection services)
        { 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "CaseStudy for United Payment Company",
                    Contact = new OpenApiContact()
                    {
                        Email = "rustemy14@gmail.com",
                        Name = "Rüstem Yıldırım"
                    }
                });
                c.CustomSchemaIds(type => type.ToString());
            });

            services.AddDbContext<UPDbContext>(options =>
            {
                options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Personal;Integrated Security=SSPI;");
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IIdentityContext, IdentityContext>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IKimlikCommunicator, KimlikCommunicator>();
            services.AddScoped<IPaymentCommunicator, PaymentCommunicator>();
            services.AddScoped<IDbContextHandler, DbContextHandler>();
            services.AddHttpClient("user").SetHandlerLifetime(TimeSpan.FromSeconds(10));
            services.AddHttpClient("card-point", f => f.Timeout = TimeSpan.FromSeconds(10));
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            return services;
        }
    }
}