using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using BookLibraryAPI.Services.Interfaces;
using System.Net;

namespace BookLibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IGenreRepository genreRepository, IMapper mapper, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
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
                return ServiceResponse<IEnumerable<BookDto>>.Success(bookDtos, HttpStatusCode.OK, "All books retrieved successfully.");
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
                return ServiceResponse<BookDto>.Success(bookDto, HttpStatusCode.OK, "Book retrieved successfully.");
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
                var selectedAuthors = await _authorRepository.GetByIdsAsync(createBookDto.AuthorIds);
                var authorIdsFound = selectedAuthors.Select(a => a.Id).ToHashSet();
                var authorIdsRequested = createBookDto.AuthorIds.ToHashSet();

                var missingAuthorIds = authorIdsRequested.Except(authorIdsFound).ToList();
                if (missingAuthorIds.Any())
                {
                    return ServiceResponse<BookDto>.Failure(HttpStatusCode.BadRequest, $"The following author IDs were not found: {string.Join(", ", missingAuthorIds)}");
                }

                var selectedGenres = await _genreRepository.GetByIdsAsync(createBookDto.GenreIds);
                var genreIdsFound = selectedGenres.Select(g => g.Id).ToHashSet();
                var genreIdsRequested = createBookDto.GenreIds.ToHashSet();

                var missingGenreIds = genreIdsRequested.Except(genreIdsFound).ToList();
                if (missingGenreIds.Any())
                {
                    return ServiceResponse<BookDto>.Failure(HttpStatusCode.BadRequest, $"The following genre IDs were not found: {string.Join(", ", missingGenreIds)}");
                }

                var book = _mapper.Map<Book>(createBookDto);

                var bookAuthors = createBookDto.AuthorIds.Select(authorId => new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = authorId
                }).ToList();

                var bookGenres = createBookDto.GenreIds.Select(genreId => new BookGenre
                {
                    BookId = book.Id,
                    GenreId = genreId
                }).ToList();

                book.BookAuthors = bookAuthors;
                book.BookGenres = bookGenres;

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

                var selectedAuthors = await _authorRepository.GetByIdsAsync(updateBookDto.AuthorIds);
                var authorIdsFound = selectedAuthors.Select(a => a.Id).ToHashSet();
                var authorIdsRequested = updateBookDto.AuthorIds.ToHashSet();

                var missingAuthorIds = authorIdsRequested.Except(authorIdsFound).ToList();
                if (missingAuthorIds.Any())
                {
                    return ServiceResponse.Failure(HttpStatusCode.BadRequest, $"The following author IDs were not found: {string.Join(", ", missingAuthorIds)}");
                }

                var selectedGenres = await _genreRepository.GetByIdsAsync(updateBookDto.GenreIds);
                var genreIdsFound = selectedGenres.Select(g => g.Id).ToHashSet();
                var genreIdsRequested = updateBookDto.GenreIds.ToHashSet();

                var missingGenreIds = genreIdsRequested.Except(genreIdsFound).ToList();
                if (missingGenreIds.Any())
                {
                    return ServiceResponse.Failure(HttpStatusCode.BadRequest, $"The following genre IDs were not found: {string.Join(", ", missingGenreIds)}");
                }

                var book = _mapper.Map<Book>(updateBookDto);
                book.Id = id;

                await _bookRepository.UpdateAsync(book, updateBookDto.AuthorIds, updateBookDto.GenreIds);
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
