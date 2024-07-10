using BookLibraryAPI.DTOs;
using BookLibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>A list of books.</returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<BookDto>>>> GetBooks()
        {
            var response = await _bookService.GetAllAsync();
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific book by ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The book with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BookDto>>> GetBook(int id)
        {
            var response = await _bookService.GetByIdAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="createBookDto">The data for the new book.</param>
        /// <returns>The created book.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BookDto>>> CreateBook([FromBody] CreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ServiceResponse<BookDto>.Failure(HttpStatusCode.BadRequest, "Invalid data."));
            }

            var response = await _bookService.CreateAsync(createBookDto);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return CreatedAtAction(nameof(GetBook), new { id = response.Data?.Id }, response);
        }

        /// <summary>
        /// Updates an existing book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="updateBookDto">The updated book data.</param>
        /// <returns>Details of the update operation.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse>> UpdateBook(int id, [FromBody] UpdateBookDto updateBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ServiceResponse<BookDto>.Failure(HttpStatusCode.BadRequest, "Invalid data."));
            }

            var getBookResponse = await _bookService.GetByIdAsync(id);
            if (!getBookResponse.Succeeded)
            {
                return StatusCode((int)getBookResponse.StatusCode, getBookResponse);
            }

            var response = await _bookService.UpdateAsync(id, updateBookDto);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(ServiceResponse.Success(HttpStatusCode.OK, "Book updated successfully."));
        }

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>Details of the delete operation.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse>> DeleteBook(int id)
        {
            var getBookResponse = await _bookService.GetByIdAsync(id);
            if (!getBookResponse.Succeeded)
            {
                return StatusCode((int)getBookResponse.StatusCode, getBookResponse);
            }

            var response = await _bookService.DeleteAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(ServiceResponse.Success(HttpStatusCode.OK, "Book deleted successfully."));
        }
    }
}
