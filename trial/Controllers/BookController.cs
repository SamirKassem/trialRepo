using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using trial.Data.Models;
using trial.Data.Services;
using trial.Data.ViewModels;

namespace trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BooksService _booksService;
        public BookController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM bookVM)
        {
            _booksService.AddBook(bookVM);
            return Ok();
        }


        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            List<Book> books = _booksService.GetAllBooks();
            return Ok(books);
        }


        [HttpGet("get-book-by-id/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            Book book = _booksService.GetBookById(Id);
            return Ok(book);
        }


        [HttpPut("update-book-by-id/{Id}")]
        public IActionResult UpdateBookById(int Id, BookVM bookVM)
        {
            Book book = _booksService.UpdateBookById(Id, bookVM);
            return Ok(book);
        }

        [HttpDelete("delete-book-by-id/{Id}")]
        public IActionResult DeleteBookById(int Id)
        {
            _booksService.DeleteBookById(Id);
            return Ok();
        }
    }
}
