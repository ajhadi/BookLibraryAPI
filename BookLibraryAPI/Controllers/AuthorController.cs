using BookLibraryAPI.DTOs;
using BookLibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Retrieves all authors.
        /// </summary>
        /// <returns>A list of authors.</returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AuthorDto>>>> GetAuthors()
        {
            var response = await _authorService.GetAllAsync();
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific author by ID.
        /// </summary>
        /// <param name="id">The ID of the author.</param>
        /// <returns>The author with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AuthorDetailDto?>>> GetAuthor(int id)
        {
            var response = await _authorService.GetByIdAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates a new author.
        /// </summary>
        /// <param name="createAuthorDto">The data for the new author.</param>
        /// <returns>The created author.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AuthorDto>>> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ServiceResponse<AuthorDto>.Failure(HttpStatusCode.BadRequest, "Invalid data."));
            }

            var response = await _authorService.CreateAsync(createAuthorDto);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return CreatedAtAction(nameof(GetAuthor), new { id = response.Data?.Id }, response);
        }

        /// <summary>
        /// Updates an existing author by ID.
        /// </summary>
        /// <param name="id">The ID of the author to update.</param>
        /// <param name="updateAuthorDto">The updated author data.</param>
        /// <returns>No content on success.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse>> UpdateAuthor(int id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ServiceResponse<AuthorDto>.Failure(HttpStatusCode.BadRequest, "Invalid data."));
            }

            var getAuthorResponse = await _authorService.GetByIdAsync(id);
            if (!getAuthorResponse.Succeeded)
            {
                return StatusCode((int)getAuthorResponse.StatusCode, getAuthorResponse);
            }

            var response = await _authorService.UpdateAsync(id, updateAuthorDto);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an author by ID.
        /// </summary>
        /// <param name="id">The ID of the author to delete.</param>
        /// <returns>No content on success.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse>> DeleteAuthor(int id)
        {
            var getAuthorResponse = await _authorService.GetByIdAsync(id);
            if (!getAuthorResponse.Succeeded)
            {
                return StatusCode((int)getAuthorResponse.StatusCode, getAuthorResponse);
            }

            var response = await _authorService.DeleteAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return NoContent();
        }
    }
}
