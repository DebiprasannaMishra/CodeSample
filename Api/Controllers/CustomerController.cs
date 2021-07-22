using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository context)
        {
            customerRepository = context;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                return customerRepository.GetAllCustomers();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                return customerRepository.GetCustomer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            try
            {
                return customerRepository.AddCustomer(customer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpPut]
        public ActionResult<Customer> Put([FromBody] Customer customer)
        {
            try
            {
                return customerRepository.UpdateCustomer(customer);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Customer> Delete(int id)
        {
            try
            {
                return customerRepository.DeleteCustomerById(id);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }

        }

    }
}
