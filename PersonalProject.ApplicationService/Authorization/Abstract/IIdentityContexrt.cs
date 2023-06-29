using PersonalProject.ApplicationService.Authorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Authorization.Abstract
{
    public interface IIdentityContext
    {
        IdentityModel GetInfo(string token);
    }
}
