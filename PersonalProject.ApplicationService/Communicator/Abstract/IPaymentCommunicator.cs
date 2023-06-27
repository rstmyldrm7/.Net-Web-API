using PersonalProject.ApplicationService.Communicator.Model.Request;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Abstract
{
    public interface IPaymentCommunicator
    {
        Task<GetTokenResponse> GetToken(GetTokenRequest request);
    }
}
