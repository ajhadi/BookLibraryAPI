using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using BookLibraryAPI.Services.Interfaces;
using System.Net;

namespace BookLibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorService> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<AuthorDetailDto>> GetByIdAsync(int id)
        {
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                if (author == null)
                {
                    _logger.LogWarning($"Author with ID {id} not found.");
                    return ServiceResponse<AuthorDetailDto>.Failure(HttpStatusCode.NotFound, "Author not found.");
                }

                var authorDetailDto = _mapper.Map<AuthorDetailDto>(author);

                _logger.LogInformation($"Successfully retrieved author with ID {id}.");
                return ServiceResponse<AuthorDetailDto>.Success(authorDetailDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving author with ID {id}.");
                return ServiceResponse<AuthorDetailDto>.Failure(HttpStatusCode.InternalServerError, "An error occurred while retrieving the author.");
            }
        }

        public async Task<ServiceResponse<IEnumerable<AuthorDto>>> GetAllAsync()
        {
            try
            {
                var authors = await _authorRepository.GetAllAsync();
                var authorDtos = _mapper.Map<IEnumerable<AuthorDto>>(authors);
                _logger.LogInformation("Successfully retrieved all authors.");
                return ServiceResponse<IEnumerable<AuthorDto>>.Success(authorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all authors.");
                return ServiceResponse<IEnumerable<AuthorDto>>.Failure(HttpStatusCode.InternalServerError, "An error occurred while retrieving authors.");
            }
        }

        public async Task<ServiceResponse<AuthorDto>> CreateAsync(CreateAuthorDto createAuthorDto)
        {
            try
            {
                var author = _mapper.Map<Author>(createAuthorDto);
                var createdAuthor = await _authorRepository.AddAsync(author);
                var authorDto = _mapper.Map<AuthorDto>(createdAuthor);
                _logger.LogInformation($"Author created successfully with ID {createdAuthor.Id}.");
                return ServiceResponse<AuthorDto>.Success(authorDto, HttpStatusCode.Created, "Author created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the author.");
                return ServiceResponse<AuthorDto>.Failure(HttpStatusCode.InternalServerError, "An error occurred while creating the author.");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int id, UpdateAuthorDto updateAuthorDto)
        {
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                if (author == null)
                {
                    _logger.LogWarning($"Author with ID {id} not found for update.");
                    return ServiceResponse.Failure(HttpStatusCode.NotFound, "Author not found.");
                }
                var originalAuthor = _mapper.Map<Author>(author);
                if (AreAuthorsEqual(author, originalAuthor))
                {
                    _logger.LogInformation($"No changes detected for author with ID {id}.");
                    return ServiceResponse.Success(HttpStatusCode.NoContent, "No changes detected.");
                }
                _mapper.Map(updateAuthorDto, author);
                await _authorRepository.UpdateAsync(author);
                _logger.LogInformation($"Author updated successfully with ID {id}.");
                return ServiceResponse.Success(HttpStatusCode.NoContent, "Author updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating author with ID {id}.");
                return ServiceResponse.Failure(HttpStatusCode.InternalServerError, "An error occurred while updating the author.");
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                if (author == null)
                {
                    _logger.LogWarning($"Author with ID {id} not found for deletion.");
                    return ServiceResponse.Failure(HttpStatusCode.NotFound, "Author not found.");
                }

                await _authorRepository.DeleteAsync(id);
                _logger.LogInformation($"Author deleted successfully with ID {id}.");
                return ServiceResponse.Success(HttpStatusCode.NoContent, "Author deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting author with ID {id}.");
                return ServiceResponse.Failure(HttpStatusCode.InternalServerError, "An error occurred while deleting the author.");
            }
        }
        private bool AreAuthorsEqual(Author a1, Author a2)
        {
            return a1.FirstName == a2.FirstName &&
                   a1.LastName == a2.LastName &&
                   a1.Biography == a2.Biography;
        }
    }
}
