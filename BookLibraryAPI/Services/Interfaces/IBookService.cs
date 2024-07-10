using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Services.Interfaces
{
    /// <summary>
    /// Interface for the service managing book operations.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>A <see cref="ServiceResponse{IEnumerable{BookDto}}"/> containing a list of all books.</returns>
        Task<ServiceResponse<IEnumerable<BookDto>>> GetAllAsync();

        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>A <see cref="ServiceResponse{BookDto}"/> containing the details of the book with the specified ID, or an error response if not found.</returns>
        Task<ServiceResponse<BookDto>> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="createBookDto">The data transfer object containing the details of the book to create.</param>
        /// <returns>A <see cref="ServiceResponse{BookDto}"/> containing the details of the created book.</returns>
        Task<ServiceResponse<BookDto>> CreateAsync(CreateBookDto createBookDto);

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="updateBookDto">The data transfer object containing the updated details of the book.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating the result of the update operation.</returns>
        Task<ServiceResponse> UpdateAsync(int id, UpdateBookDto updateBookDto);

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating the result of the delete operation.</returns>
        Task<ServiceResponse> DeleteAsync(int id);
    }
}