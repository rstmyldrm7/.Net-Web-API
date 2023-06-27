using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.Domain;
using PersonalProject.Domain.Aggregate;
using PersonalProject.Domain.Aggregate.Repositories;
using PersonalProject.Repository.Repositories;

namespace PersonalProject.Repository.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(UPDbContext context) : base(context)
        {
        }
    }
}
