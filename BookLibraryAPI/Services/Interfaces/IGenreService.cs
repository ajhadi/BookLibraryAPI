using BookLibraryAPI.DTOs;
using LibraryManagementAPI.DTOs;

namespace BookLibraryAPI.Services.Interfaces
{
    /// <summary>
    /// Interface for the service managing genre operations.
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Retrieves a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre to retrieve.</param>
        /// <returns>A <see cref="ServiceResponse{GenreDto}"/> containing the details of the genre with the specified ID, or an error response if not found.</returns>
        Task<ServiceResponse<GenreDto>> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all genres.
        /// </summary>
        /// <returns>A <see cref="ServiceResponse{IEnumerable{GenreDto}}"/> containing a list of all genres.</returns>
        Task<ServiceResponse<IEnumerable<GenreDto>>> GetAllAsync();

        /// <summary>
        /// Creates a new genre.
        /// </summary>
        /// <param name="createGenreDto">The data transfer object containing the details of the genre to create.</param>
        /// <returns>A <see cref="ServiceResponse{GenreDto}"/> containing the details of the created genre.</returns>
        Task<ServiceResponse<GenreDto>> CreateAsync(CreateGenreDto createGenreDto);

        /// <summary>
        /// Updates an existing genre.
        /// </summary>
        /// <param name="id">The ID of the genre to update.</param>
        /// <param name="updateGenreDto">The data transfer object containing the updated details of the genre.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating the result of the update operation.</returns>
        Task<ServiceResponse> UpdateAsync(int id, UpdateGenreDto updateGenreDto);

        /// <summary>
        /// Deletes a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre to delete.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating the result of the delete operation.</returns>
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
