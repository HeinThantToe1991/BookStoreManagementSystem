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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add"), Authorize]
        public ActionResult<ReturnMessageViewModel<AuthorViewModel>> AddAuthor(AuthorViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<AuthorViewModel>();
            if (viewModel == null)
            {
                return BadRequest("Author data is missing.");
            }
            try
            {
                data.Data = _authorService.Add(viewModel);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Author created successfully.";
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
        public ActionResult<ReturnMessageViewModel<AuthorViewModel>> UpdateAuthor(AuthorViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<AuthorViewModel>();
            var categories = _authorService.GetAuthorById(viewModel.Id);
            if (categories == null)
            {
                data.Success = false;
                data.Message = "No record to update!.";
                return NotFound(data);
            }
            try
            {
                categories.Name = viewModel.Name;
                categories.Description = viewModel.Description;

                data.Data = _authorService.Update(categories);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Author updated successfully.";
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
        public ActionResult<ReturnMessageViewModel<AuthorViewModel>> DeleteAuthor(string id)
        {
            var data = new ReturnMessageViewModel<AuthorViewModel>();
            try
            {
                _authorService.Delete(Guid.Parse(id));
                data.Success = true;
                data.Message = "Author deleted successfully.";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }
        }
        
        [HttpGet("id/{id}"), Authorize]
        public ActionResult<ReturnMessageViewModel<AuthorViewModel>> GetAuthorById(string id)
        {
            var data = new ReturnMessageViewModel<AuthorViewModel>();
            try
            {

                var result = _authorService.GetAuthorById(Guid.Parse(id));
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
        public ActionResult<ReturnMessageViewModel<AuthorListViewModel>> GetAuthorByName(string name)
        {
            var data = new ReturnMessageViewModel<AuthorListViewModel>();
            try
            {
                var result = _authorService.GetAuthorByName(name);
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
