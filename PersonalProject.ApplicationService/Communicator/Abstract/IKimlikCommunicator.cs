using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Abstract
{
    public interface IKimlikCommunicator
    {
       Task<bool>  VerifyIdentity(long IdentityNumber, string Name, string Surname, DateTime BirthYear);
    }
}
