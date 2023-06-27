using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.ApiContract.Response;

namespace PersonalProject.ApiContract.Request
{
    public class CreateCustomerRequest : IRequest<ResponseBase<CreateCustomerResponse>>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public long IdentityNo { get; set; }
    }
}
