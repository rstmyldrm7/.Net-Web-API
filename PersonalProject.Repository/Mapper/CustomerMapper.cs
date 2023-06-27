using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.Domain.Aggregate;

namespace PersonalProject.Repository.Mapper
{
    public class CustomerMapper : BaseEntityMap<Customer>
    {
        protected override void Map(EntityTypeBuilder<Customer> eb)
        {
        }
    }
}
