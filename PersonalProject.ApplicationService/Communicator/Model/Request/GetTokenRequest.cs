using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Model.Request
{
    public class GetTokenRequest
    {
        public string ApiKey { get; set; }
        public string Email { get; set; }
        public string Lang { get; set; }
    }
}
