using Microsoft.AspNetCore.Mvc;
using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApiContract;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.ApplicationService.Communicator.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace PersonalProject.Controllers
{
    [Route("transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        /// <summary>
        /// Get Token
        /// </summary>
        [HttpGet("token")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<GetTokenResponse>))]
        public async Task<IActionResult> Token()
        {
            var resp = await _transactionService.GetToken();
            return Ok(resp);
        }
        /// <summary>
        /// Sale Credit Card
        /// </summary>
        [HttpPost("sale/creditCard")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<NonSecurePaymentResponse>))]
        public async Task<IActionResult> SaleCreditCard(SaleCardRequest request)
        {          
            var resp = await _transactionService.SaleCreditCard(request);
            return Ok(resp);
        }
    }
}
