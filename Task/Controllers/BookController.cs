using Microsoft.AspNetCore.Mvc;
using Services.Books;

namespace Task.Controllers
{
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [Route("v1/Books/GetAll")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = _bookService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Exception occured {0}");
                return BadRequest(ex);
            }
        }

        [Route("v1/Books/GetAllByPublisherAuthorThenTitle")]
        [HttpGet]
        public IActionResult GetAllBooksByPublisherAuthorThenTitle()
        {
            try
            {
                var result = _bookService.GetByPublisherAuthorThenTitle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Exception occured {0}");
                return BadRequest(ex);
            }
        }

        [Route("v1/Books/GetAllByAuthorThenTitle")]
        [HttpGet]
        public IActionResult GetAllBooksByAuthorThenTitle()
        {
            try
            {
                var result = _bookService.GetByAuthorThenTitle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Exception occured {0}");
                return BadRequest(ex);
            }
        }

        [Route("v1/Books/TotalPrice")]
        [HttpGet]
        public IActionResult GetTotalPrice()
        {
            try
            {
                var result = _bookService.GetTotalPrice();
                return Ok($"Total price is {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Exception occured {0}");
                return BadRequest(ex);
            }
        }
    }
}
