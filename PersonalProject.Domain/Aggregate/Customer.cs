using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.Domain.Entities;

namespace PersonalProject.Domain.Aggregate
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public Customer(string name, string surname, DateTime birthDate, long identityNo, bool identityNoVerified)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            IdentityNo = identityNo;
            IdentityNoVerified = identityNoVerified;
        }

        public void SetIdentityNoVerified(bool value)
        {
            IdentityNoVerified = value;
        }
    }
}
