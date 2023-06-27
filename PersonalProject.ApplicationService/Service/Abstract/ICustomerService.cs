using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.ApiContract;
using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;

namespace PersonalProject.ApplicationService.Service.Abstract
{
    public interface ICustomerService
    {
        Task<ResponseBase<CreateCustomerResponse>> CreateCustomer(CreateCustomerRequest request);
    }
}
