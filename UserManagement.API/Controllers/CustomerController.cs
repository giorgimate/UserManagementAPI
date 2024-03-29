using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> CreateAsync(CancellationToken cancellationToken, CustomerRequestPostModel CustomerPostModel)
        {
            await _service.CreateAsync(cancellationToken, CustomerPostModel);
            return Ok();
        }
    }
}
