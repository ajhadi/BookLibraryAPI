using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Services.Interfaces;
using LibraryManagementAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all genres.
        /// </summary>
        /// <returns>A list of genres.</returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GenreDto>>>> GetGenres()
        {
            var response = await _genreService.GetAllAsync();
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific genre by ID.
        /// </summary>
        /// <param name="id">The ID of the genre.</param>
        /// <returns>The genre with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GenreDto>>> GetGenre(int id)
        {
            var response = await _genreService.GetByIdAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates a new genre.
        /// </summary>
        /// <param name="createGenreDto">The data for the new genre.</param>
        /// <returns>The created genre.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GenreDto>>> CreateGenre([FromBody] CreateGenreDto createGenreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ServiceResponse<GenreDto>.Failure(HttpStatusCode.BadRequest, "Invalid data."));
            }

            var response = await _genreService.CreateAsync(createGenreDto);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return CreatedAtAction(nameof(GetGenre), new { id = response.Data.Id }, response);
        }

        /// <summary>
        /// Updates an existing genre by ID.
        /// </summary>
        /// <param name="id">The ID of the genre to update.</param>
        /// <param name="updateGenreDto">The updated genre data.</param>
        /// <returns>No content on success.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse>> UpdateGenre(int id, [FromBody] UpdateGenreDto updateGenreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ServiceResponse<GenreDto>.Failure(HttpStatusCode.BadRequest, "Invalid data."));
            }

            var getGenreResponse = await _genreService.GetByIdAsync(id);
            if (!getGenreResponse.Succeeded)
            {
                return StatusCode((int)getGenreResponse.StatusCode, getGenreResponse);
            }

            var response = await _genreService.UpdateAsync(id, updateGenreDto);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a genre by ID.
        /// </summary>
        /// <param name="id">The ID of the genre to delete.</param>
        /// <returns>No content on success.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse>> DeleteGenre(int id)
        {
            var getGenreResponse = await _genreService.GetByIdAsync(id);
            if (!getGenreResponse.Succeeded)
            {
                return StatusCode((int)getGenreResponse.StatusCode, getGenreResponse);
            }

            var response = await _genreService.DeleteAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return NoContent();
        }
    }
}
