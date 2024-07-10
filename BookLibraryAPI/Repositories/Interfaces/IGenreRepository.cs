using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the repository managing genre data.
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Retrieves a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre to retrieve.</param>
        /// <returns>The genre with the specified ID, or <c>null</c> if not found.</returns>
        Task<Genre?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all genres.
        /// </summary>
        /// <returns>A collection of all genres.</returns>
        Task<IEnumerable<Genre>> GetAllAsync();

        /// <summary>
        /// Retrieves genres by a list of IDs.
        /// </summary>
        /// <param name="ids">A list of genre IDs to retrieve.</param>
        /// <returns>A collection of genres that match the specified IDs.</returns>
        Task<IEnumerable<Genre>> GetByIdsAsync(IEnumerable<int> ids);

        /// <summary>
        /// Adds a new genre.
        /// </summary>
        /// <param name="genre">The genre to add.</param>
        /// <returns>The added genre.</returns>
        Task<Genre> AddAsync(Genre genre);

        /// <summary>
        /// Updates an existing genre.
        /// </summary>
        /// <param name="genre">The genre to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Genre genre);

        /// <summary>
        /// Deletes a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
