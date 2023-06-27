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
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IKimlikCommunicator, KimlikCommunicator>();
            services.AddScoped<IDbContextHandler , DbContextHandler>();
            return services;
        }
    }
}