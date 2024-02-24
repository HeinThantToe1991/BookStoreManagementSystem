using Microsoft.AspNetCore.Mvc;
using BookStoreManagementSystem.Domain;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System;
using Newtonsoft.Json;

namespace BookStoreManagementSystem.Mvc.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookStoreController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add"),Authorize]
        public ActionResult<ReturnMessageViewModel<BookViewModel>> AddBook(BookViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<BookViewModel>();
            if (viewModel == null)
            {
                return BadRequest(" data is missing.");
            }
            try
            {
                data.Data = _bookService.Add(viewModel);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message =" created successfully.";
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
        public ActionResult<ReturnMessageViewModel<BookViewModel>> UpdateBook(BookViewModel viewModel)
        {
            var data = new ReturnMessageViewModel<BookViewModel>();
            var result = _bookService.GetBookById(viewModel.Id);
            if (result == null)
            {
                data.Success = false;
                data.Message = "No record to update!.";
                return NotFound(data);
            }
            try
            {
                result.AuthorId = viewModel.AuthorId;
                result.Description = viewModel.Description;
                result.BookCategoriesId = viewModel.BookCategoriesId;
                result.BookName = viewModel.BookName;
                data.Data = _bookService.Update(result);
                if (data.Data.Id == Guid.Empty)
                {
                    data.Success = false;
                    data.Message = "Sorry, please try again.!";
                    return BadRequest(data);
                }
                data.Success = true;
                data.Message = " updated successfully.";
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
        public ActionResult<ReturnMessageViewModel<BookViewModel>> DeleteBook(string id)
        {
            var data = new ReturnMessageViewModel<BookViewModel>();
            try
            {
                _bookService.Delete(Guid.Parse(id));
                data.Success = true;
                data.Message = " deleted successfully.";
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, data);
            }
        }

        [HttpGet,Authorize]
        public ActionResult<ReturnMessageViewModel<BookListViewModel>> GetBooks()
        {
            var data = new ReturnMessageViewModel<BookListViewModel>();
            var result = _bookService.GetBook();
            if (result.Books == null || result.Books.Count == 0)
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
        public ActionResult<ReturnMessageViewModel<BookViewModel>> GetBookById(string id)
        {
            var data = new ReturnMessageViewModel<BookViewModel>();
            try
            {
           
                var categories = _bookService.GetBookById(Guid.Parse(id));
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
        public ActionResult<ReturnMessageViewModel<BookListViewModel>> GetBookByName(string name)
        {
            var data = new ReturnMessageViewModel<BookListViewModel>();
            try
            {
                var result = _bookService.GetBookByName(name);
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
