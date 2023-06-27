using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Communicator.Concrete;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.ApplicationService.Service.Concrete;
using PersonalProject.Domain;
using PersonalProject.Domain.Aggregate.Repositories;
using PersonalProject.Repository;
using PersonalProject.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDbContext<UPDbContext>(options =>
            {
                options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Personal;Integrated Security=SSPI;");
            });
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IKimlikCommunicator, KimlikCommunicator>();
            services.AddScoped<IPaymentCommunicator, PaymentCommunicator>();
            services.AddScoped<IDbContextHandler, DbContextHandler>();
            services.AddHttpClient("user").SetHandlerLifetime(TimeSpan.FromSeconds(10));
            services.AddHttpClient("card-point", f => f.Timeout = TimeSpan.FromSeconds(10));
            //services.AddHttpClient<IHttpClientFactory>();
            return services;
        }
    }
}