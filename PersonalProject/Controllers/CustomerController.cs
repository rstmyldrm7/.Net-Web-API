using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.ApiContract;
using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.ApplicationService.Service.Concrete;

namespace PersonalProject.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Create Customer
        /// </summary>
        [HttpPost("createCustomer")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<CreateCustomerResponse>))]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            var resp = await _customerService.CreateCustomer(request);
            return Ok(resp);
        }
    }
}
