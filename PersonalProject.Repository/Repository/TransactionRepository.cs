using PersonalProject.Domain.Aggregate.Repositories;
using PersonalProject.Domain.Aggregate;
using PersonalProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Repository.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(UPDbContext context) : base(context)
        {
        }
    }
}
