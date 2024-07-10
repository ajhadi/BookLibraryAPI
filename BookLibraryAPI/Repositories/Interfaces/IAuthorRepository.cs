using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the repository managing author data.
    /// </summary>
    public interface IAuthorRepository
    {
        /// <summary>
        /// Retrieves an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to retrieve.</param>
        /// <returns>The author with the specified ID, or <c>null</c> if not found.</returns>
        Task<Author?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all authors.
        /// </summary>
        /// <returns>A collection of all authors.</returns>
        Task<IEnumerable<Author>> GetAllAsync();

        /// <summary>
        /// Retrieves authors by a list of IDs.
        /// </summary>
        /// <param name="ids">A list of author IDs to retrieve.</param>
        /// <returns>A collection of authors that match the specified IDs.</returns>
        Task<IEnumerable<Author>> GetByIdsAsync(IEnumerable<int> ids);

        /// <summary>
        /// Adds a new author.
        /// </summary>
        /// <param name="author">The author to add.</param>
        /// <returns>The added author.</returns>
        Task<Author> AddAsync(Author author);

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="author">The author to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Author author);

        /// <summary>
        /// Deletes an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
