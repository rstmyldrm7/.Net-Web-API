using Microsoft.AspNetCore.Mvc;
using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApiContract;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.ApplicationService.Communicator.Model.Response;

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
        /// Create Customer
        /// </summary>
        [HttpGet("token")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<GetTokenResponse>))]
        public async Task<IActionResult> Token()
        {
            var resp = await _transactionService.GetToken();
            return Ok(resp);
        }
    }
}
