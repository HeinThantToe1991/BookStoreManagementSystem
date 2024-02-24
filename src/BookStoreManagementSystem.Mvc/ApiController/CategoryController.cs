using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Interfaces.ViewModel;
using BookStoreManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BookStoreManagementSystem.Mvc.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public CategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpPost("add"), Authorize]
        public ActionResult<ReturnMessageViewModel<BookCategoryViewModel>> AddBookCategory(BookCategoryViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<BookCategoryViewModel>();
            if (viewModel == null)
            {
                return BadRequest("Category data is missing.");
            }
            try
            {
                data.Data = _bookCategoryService.Add(viewModel);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Category created successfully.";
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
        public ActionResult<ReturnMessageViewModel<BookCategoryViewModel>> UpdateBookCategory(BookCategoryViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<BookCategoryViewModel>();
            var categories = _bookCategoryService.GetBookCategoryById(viewModel.Id);
            if (categories == null)
            {
                data.Success = false;
                data.Message = "No record to update!.";
                return NotFound(data);
            }
            try
            {
                categories.CategoryName = viewModel.CategoryName;
                categories.Description = viewModel.Description;

                data.Data = _bookCategoryService.Update(categories);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = "Category updated successfully.";
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
        public ActionResult<ReturnMessageViewModel<BookCategoryViewModel>> DeleteBookCategory(string id)
        {
            var data = new ReturnMessageViewModel<BookCategoryViewModel>();
            try
            {
                _bookCategoryService.Delete(Guid.Parse(id));
                data.Success = true;
                data.Message = "Category deleted successfully.";
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
        public ActionResult<ReturnMessageViewModel<BookCategoryListViewModel>> GetBookCategories()
        {
            var data = new ReturnMessageViewModel<BookCategoryListViewModel>();
            var categories = _bookCategoryService.GetBookCategories();
            if (categories.Categories == null || categories.Categories.Count == 0)
            {
                data.Success = false;
                data.Message = "No record!.";
                return NotFound(data);
            }
            data.Success = true;
            data.Message = "Success";
            data.Data = categories;
            return Ok(JsonConvert.SerializeObject(data));
        }

        [HttpGet("id/{id}"), Authorize]
        public ActionResult<ReturnMessageViewModel<BookCategoryViewModel>> GetBookCategoriesById(string id)
        {
            var data = new ReturnMessageViewModel<BookCategoryViewModel>();
            try
            {

                var categories = _bookCategoryService.GetBookCategoryById(Guid.Parse(id));
                if (categories == null)
                {
                    data.Success = false;
                    data.Message = "No record!.";
                    return NotFound(data);
                }
                data.Success = true;
                data.Message = "Success";
                data.Data = categories;
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
        public ActionResult<ReturnMessageViewModel<BookCategoryViewModel>> GetBookCategoriesByName(string name)
        {
            var data = new ReturnMessageViewModel<BookCategoryViewModel>();
            try
            {
                var categories = _bookCategoryService.GetBookCategoryByName(name);
                if (categories == null)
                {
                    data.Success = false;
                    data.Message = "No record!.";
                    return NotFound(data);
                }
                data.Success = true;
                data.Message = "Success";
                data.Data = categories;
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
