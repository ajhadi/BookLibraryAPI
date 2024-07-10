using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using BookLibraryAPI.Services.Interfaces;
using LibraryManagementAPI.DTOs;
using System.Net;

namespace BookLibraryAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;

        public GenreService(IGenreRepository genreRepository, IMapper mapper, ILogger<GenreService> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<GenreDto>> GetByIdAsync(int id)
        {
            try
            {
                var genre = await _genreRepository.GetByIdAsync(id);
                if (genre == null)
                {
                    _logger.LogWarning($"Genre with ID {id} not found.");
                    return ServiceResponse<GenreDto>.Failure(HttpStatusCode.NotFound, "Genre not found.");
                }
                var genreDto = _mapper.Map<GenreDto>(genre);
                _logger.LogInformation($"Successfully retrieved genre with ID {id}.");
                return ServiceResponse<GenreDto>.Success(genreDto, HttpStatusCode.OK, "Genre retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving genre with ID {id}.");
                return ServiceResponse<GenreDto>.Failure(HttpStatusCode.InternalServerError, "An error occurred while retrieving the genre.");
            }
        }

        public async Task<ServiceResponse<IEnumerable<GenreDto>>> GetAllAsync()
        {
            try
            {
                var genres = await _genreRepository.GetAllAsync();
                var genreDtos = _mapper.Map<IEnumerable<GenreDto>>(genres);
                _logger.LogInformation("Successfully retrieved all genres.");
                return ServiceResponse<IEnumerable<GenreDto>>.Success(genreDtos, HttpStatusCode.OK, "All genres retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all genres.");
                return ServiceResponse<IEnumerable<GenreDto>>.Failure(HttpStatusCode.InternalServerError, "An error occurred while retrieving genres.");
            }
        }

        public async Task<ServiceResponse<GenreDto>> CreateAsync(CreateGenreDto createGenreDto)
        {
            try
            {
                var genre = _mapper.Map<Genre>(createGenreDto);
                var createdGenre = await _genreRepository.AddAsync(genre);
                var genreDto = _mapper.Map<GenreDto>(createdGenre);
                _logger.LogInformation($"Genre created successfully with ID {createdGenre.Id}.");
                return ServiceResponse<GenreDto>.Success(genreDto, HttpStatusCode.Created, "Genre created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the genre.");
                return ServiceResponse<GenreDto>.Failure(HttpStatusCode.InternalServerError, "An error occurred while creating the genre.");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int id, UpdateGenreDto updateGenreDto)
        {
            try
            {
                var genre = await _genreRepository.GetByIdAsync(id);
                if (genre == null)
                {
                    _logger.LogWarning($"Genre with ID {id} not found for update.");
                    return ServiceResponse.Failure(HttpStatusCode.NotFound, "Genre not found.");
                }
                _mapper.Map(updateGenreDto, genre);
                await _genreRepository.UpdateAsync(genre);
                _logger.LogInformation($"Genre updated successfully with ID {id}.");
                return ServiceResponse.Success(HttpStatusCode.NoContent, "Genre updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating genre with ID {id}.");
                return ServiceResponse.Failure(HttpStatusCode.InternalServerError, "An error occurred while updating the genre.");
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            try
            {
                var genre = await _genreRepository.GetByIdAsync(id);
                if (genre == null)
                {
                    _logger.LogWarning($"Genre with ID {id} not found for deletion.");
                    return ServiceResponse.Failure(HttpStatusCode.NotFound, "Genre not found.");
                }

                await _genreRepository.DeleteAsync(id);
                _logger.LogInformation($"Genre deleted successfully with ID {id}.");
                return ServiceResponse.Success(HttpStatusCode.NoContent, "Genre deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting genre with ID {id}.");
                return ServiceResponse.Failure(HttpStatusCode.InternalServerError, "An error occurred while deleting the genre.");
            }
        }
    }
}
