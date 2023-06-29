using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalProject.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Repository.Mapper
{
    public class TransactionMapper : BaseEntityMap<Transaction>
    {
        protected override void Map(EntityTypeBuilder<Transaction> eb)
        {
        }
    }
}
