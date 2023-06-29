using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Service.Abstract
{
    public interface ITransactionService
    {
        Task<GetTokenResponse> GetToken();
        Task<NonSecurePaymentResponse> SaleCreditCard(SaleCardRequest request);
    }
}
