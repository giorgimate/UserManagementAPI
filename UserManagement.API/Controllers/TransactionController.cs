using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Transaction.Interfaces;
using UserManagement.Application.Transaction.Requests;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, TransactionRequestPostModel transactionPostModel)
        {
            var result = await _service.CreateAsync(cancellationToken, transactionPostModel);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(cancellationToken);
            return Ok(result);
        }
    }
}
