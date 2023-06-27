using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public void SetStatus(bool value)
        {
            Status = value;
        }
    }
}
