using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using BookLibraryAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BookLibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, IMapper mapper, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<IEnumerable<BookDto>>> GetAllAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllAsync();
                var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);
                _logger.LogInformation("Successfully retrieved all books.");
                return ServiceResponse<IEnumerable<BookDto>>.Success(bookDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all books.");
                return ServiceResponse<IEnumerable<BookDto>>.Failure(HttpStatusCode.InternalServerError, "An error occurred while retrieving books.");
            }
        }

        public async Task<ServiceResponse<BookDto>> GetByIdAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found.");
                    return ServiceResponse<BookDto>.Failure(HttpStatusCode.NotFound, "Book not found.");
                }

                var bookDto = _mapper.Map<BookDto>(book);
                _logger.LogInformation($"Successfully retrieved book with ID {id}.");
                return ServiceResponse<BookDto>.Success(bookDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving book with ID {id}.");
                return ServiceResponse<BookDto>.Failure(HttpStatusCode.InternalServerError, "An error occurred while retrieving the book.");
            }
        }

        public async Task<ServiceResponse<BookDto>> CreateAsync(CreateBookDto createBookDto)
        {
            try
            {
                var book = _mapper.Map<Book>(createBookDto);
                var createdBook = await _bookRepository.AddAsync(book);
                var bookDto = _mapper.Map<BookDto>(createdBook);
                _logger.LogInformation($"Book created successfully with ID {createdBook.Id}.");
                return ServiceResponse<BookDto>.Success(bookDto, HttpStatusCode.Created, "Book created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the book.");
                return ServiceResponse<BookDto>.Failure(HttpStatusCode.InternalServerError, "An error occurred while creating the book.");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int id, UpdateBookDto updateBookDto)
        {
            try
            {
                var existingBook = await _bookRepository.GetByIdAsync(id);
                if (existingBook == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found for update.");
                    return ServiceResponse.Failure(HttpStatusCode.NotFound, "Book not found.");
                }

                var book = _mapper.Map(updateBookDto, existingBook);
                await _bookRepository.UpdateAsync(book);
                _logger.LogInformation($"Book updated successfully with ID {id}.");
                return ServiceResponse.Success(HttpStatusCode.NoContent, "Book updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating book with ID {id}.");
                return ServiceResponse.Failure(HttpStatusCode.InternalServerError, "An error occurred while updating the book.");
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found for deletion.");
                    return ServiceResponse.Failure(HttpStatusCode.NotFound, "Book not found.");
                }

                await _bookRepository.DeleteAsync(id);
                _logger.LogInformation($"Book deleted successfully with ID {id}.");
                return ServiceResponse.Success(HttpStatusCode.NoContent, "Book deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting book with ID {id}.");
                return ServiceResponse.Failure(HttpStatusCode.InternalServerError, "An error occurred while deleting the book.");
            }
        }
    }
}
