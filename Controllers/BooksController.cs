using LibraryManangementSys.Entities;
using LibraryManangementSys.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManangementSys.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/v{version:LibraryManangementSys v1}")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        //Task 1 JSON Patch and Data formating
        [HttpPatch("GetBookDetailsPatchRequest")]
        public async Task<IActionResult> GetBookDetailsPatchRequest(int id,JsonPatchDocument document)
        {
             await _booksRepository.GetBookDetailsPatchRequest(id,document);
            return Ok(NoContent());
        }

        
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books= await _booksRepository.GetAllBooks();
            return Ok(books);
        }
      //Task 1  //X-Include-details
        [HttpGet("GetBookByID")]
        public async Task<IActionResult> GetBookByID(int id, [FromHeader(Name ="X-Include-Details")] bool includeDetails=false)
        {
            var books = await _booksRepository.GetBookByID(id);
            if(books==null) return NotFound();
            if(includeDetails)
            {
                return Ok(books);
            }
            return Ok(new {books.Title,books.Author});
        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(BookEntity book)
        {
            var bookDetails = await _booksRepository.AddBook(book);
            return Ok(bookDetails);
        }


    }
}
