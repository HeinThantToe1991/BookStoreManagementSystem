using System;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStoreManagementSystem.Mvc.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add"), Authorize]
        public ActionResult<ReturnMessageViewModel<CustomerViewModel>> AddCustomer(CustomerViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<CustomerViewModel>();
            if (viewModel == null)
            {
                return BadRequest("Customer data is missing.");
            }
            try
            {
                data.Data = _customerService.Add(viewModel);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Customer created successfully.";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }
        }

        [HttpPut("update"), Authorize]
        public ActionResult<ReturnMessageViewModel<CustomerViewModel>> UpdateCustomer(CustomerViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<CustomerViewModel>();
            var categories = _customerService.GetCustomerById(viewModel.Id);
            if (categories == null)
            {
                data.Success = false;
                data.Message = "No record to update!.";
                return NotFound(data);
            }
            try
            {
                categories.CustomerName = viewModel.CustomerName;
                categories.PhoneNumber = viewModel.PhoneNumber;

                data.Data = _customerService.Update(categories);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Customer updated successfully.";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }
        }
        [HttpDelete("delete/{id}"), Authorize]
        public ActionResult<ReturnMessageViewModel<CustomerViewModel>> DeleteCustomer(string id)
        {
            var data = new ReturnMessageViewModel<CustomerViewModel>();
            try
            {
                _customerService.Delete(Guid.Parse(id));
                data.Success = true;
                data.Message = "Customer deleted successfully.";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }
        }

        [HttpGet, Authorize]
        public ActionResult<ReturnMessageViewModel<CustomerListViewModel>> GetCategories()
        {
            var data = new ReturnMessageViewModel<CustomerListViewModel>();
            var result = _customerService.GetCustomers();
            if (result.Customers == null || result.Customers.Count == 0)
            {
                data.Success = false;
                data.Message = "No record!.";
                return NotFound(data);
            }
            data.Success = true;
            data.Message = "Success";
            data.Data = result;
            return Ok(JsonConvert.SerializeObject(data));
        }

        [HttpGet("id/{id}"), Authorize]
        public ActionResult<ReturnMessageViewModel<CustomerViewModel>> GetCustomerById(string id)
        {
            var data = new ReturnMessageViewModel<CustomerViewModel>();
            try
            {

                var result = _customerService.GetCustomerById(Guid.Parse(id));
                if (result == null)
                {
                    data.Success = false;
                    data.Message = "No record!.";
                    return NotFound(data);
                }
                data.Success = true;
                data.Message = "Success";
                data.Data = result;
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }

        }

        [HttpGet("name/{name}"), Authorize]
        public ActionResult<ReturnMessageViewModel<CustomerListViewModel>> GetCustomerByName(string name)
        {
            var data = new ReturnMessageViewModel<CustomerListViewModel>();
            try
            {
                var result = _customerService.GetCustomerByName(name);
                if (result == null)
                {
                    data.Success = false;
                    data.Message = "No record!.";
                    return NotFound(data);
                }
                data.Success = true;
                data.Message = "Success";
                data.Data = result;
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }

        }

    }
}
