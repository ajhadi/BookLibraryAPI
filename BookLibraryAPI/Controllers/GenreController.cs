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

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var response = await _genreService.GetAllAsync();
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var response = await _genreService.GetByIdAsync(id);
            if (!response.Succeeded)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto createGenreDto)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreDto updateGenreDto)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
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
