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
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("add"), Authorize]
        public ActionResult<ReturnMessageViewModel<SaleViewModel>> AddSale(SaleViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<SaleViewModel>();
            if (viewModel == null)
            {
                return BadRequest("Sale data is missing.");
            }
            try
            {
                data.Data = _saleService.Add(viewModel);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Sale created successfully.";
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
        public ActionResult<ReturnMessageViewModel<SaleViewModel>> UpdateSale(SaleViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<SaleViewModel>();
            var result = _saleService.GetSaleById(viewModel.Id);
            if (result == null)
            {
                data.Success = false;
                data.Message = "No record to update!.";
                return NotFound(data);
            }
            try
            {
                result.BookId = viewModel.BookId;
                result.CustomerId = viewModel.CustomerId;
                result.CustomerName = viewModel.CustomerName;
                result.Quantity = viewModel.Quantity;
                result.Discount = viewModel.Discount;
                result.Amount = viewModel.Amount;
                data.Data = _saleService.Update(result);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Sale updated successfully.";
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
        public ActionResult<ReturnMessageViewModel<SaleViewModel>> DeleteSale(string id)
        {
            var data = new ReturnMessageViewModel<SaleViewModel>();
            try
            {
                _saleService.Delete(Guid.Parse(id));
                data.Success = true;
                data.Message = "Sale deleted successfully.";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }
        }

        [HttpGet(), Authorize]
        public ActionResult<ReturnMessageViewModel<SaleListViewModel>> GetSale()
        {
            var data = new ReturnMessageViewModel<SaleListViewModel>();
            try
            {

                var result = _saleService.GetSales();
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

        [HttpGet("id/{id}"), Authorize]
        public ActionResult<ReturnMessageViewModel<SaleViewModel>> GetSaleById(string id)
        {
            var data = new ReturnMessageViewModel<SaleViewModel>();
            try
            {

                var result = _saleService.GetSaleById(Guid.Parse(id));
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

        [HttpGet("customerId/{customerId}"), Authorize]
        public ActionResult<ReturnMessageViewModel<SaleViewModel>> GetSaleByName(string customerId)
        {
            var data = new ReturnMessageViewModel<SaleViewModel>();
            try
            {
                var result = _saleService.GetSaleByCustomerId(Guid.Parse(customerId));
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


        [HttpGet("calculate/{customerId}"), Authorize]
        public ActionResult<ReturnMessageViewModel<SaleViewModel>> CalculateAmount(SaleViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<SaleViewModel>();
            try
            {

                var result = _saleService.CalculateAmount(viewModel);
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
