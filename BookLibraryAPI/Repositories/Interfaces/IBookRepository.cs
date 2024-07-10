using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the repository managing book data.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID, or <c>null</c> if not found.</returns>
        Task<Book?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>A collection of all books.</returns>
        Task<IEnumerable<Book>> GetAllAsync();

        /// <summary>
        /// Adds a new book.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <returns>The added book.</returns>
        Task<Book> AddAsync(Book book);

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <param name="newAuthorIds">A list of IDs of authors to be associated with the book.</param>
        /// <param name="newGenreIds">A list of IDs of genres to be associated with the book.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Book book, List<int> newAuthorIds, List<int> newGenreIds);

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
