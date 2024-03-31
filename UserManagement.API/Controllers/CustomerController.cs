using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Customers.Requests;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, CustomerRequestPostModel CustomerPostModel)
        {
            var result = await _service.CreateAsync(cancellationToken, CustomerPostModel);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _service.GetAsync(cancellationToken,id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, int id)
        {
            var result = await _service.DeleteAsync(cancellationToken, id);
            return Ok(result);
        }
    }
}
