using CustomerService.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Data.DtoMappings;
using CustomerService.Domain.Entities;
using CustomerService.Domain.Interfaces;
using CustomerService.Domain.Filter;
using CustomerService.Domain.Services;

namespace CustomerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        private readonly IUriService _uriService;
        public CustomersController(ICustomerRepository customerRepo,  IUriService uriService)
        {
            _customerRepo = customerRepo;
            _uriService = uriService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerNewDto customerDto)
        {
            try
            {
                var customer = Mapping.Mapper.Map<Customer>(customerDto);
                await _customerRepo.AddAsync(customer);
                await _customerRepo.SaveChangesAsync();
                return Ok(customer);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id,CustomerUpdateDto customerDto )
        {
            try
            {

                var customer = await _customerRepo.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                var updatedCustomer = Mapping.Mapper.Map<Customer>(customerDto);
                updatedCustomer.Id = customer.Id;
                updatedCustomer.CreatedAt = customer.CreatedAt;
                updatedCustomer.ModifiedAt = DateTime.UtcNow;
                _customerRepo.Update(updatedCustomer);
                await _customerRepo.SaveChangesAsync();
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            try
            {
              var customer = await _customerRepo.GetByIdAsync(id);
                if(customer == null)
                {
                    return NotFound();
                }
                 _customerRepo.Delete(customer);
                await _customerRepo.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult>GetAllCustomers([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var route = Request.Path.Value;
                var pagedCustomersData = await _customerRepo.GetAllAsync(filter, route, _uriService);

                return Ok(pagedCustomersData);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
