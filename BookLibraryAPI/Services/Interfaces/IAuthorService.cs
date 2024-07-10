using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Services.Interfaces
{
    /// <summary>
    /// Interface for the service managing author operations.
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Retrieves an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to retrieve.</param>
        /// <returns>A <see cref="ServiceResponse{AuthorDetailDto}"/> containing the details of the author with the specified ID, or an error response if not found.</returns>
        Task<ServiceResponse<AuthorDetailDto>> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all authors.
        /// </summary>
        /// <returns>A <see cref="ServiceResponse{IEnumerable{AuthorDto}}"/> containing a list of all authors.</returns>
        Task<ServiceResponse<IEnumerable<AuthorDto>>> GetAllAsync();

        /// <summary>
        /// Creates a new author.
        /// </summary>
        /// <param name="createAuthorDto">The data transfer object containing the details of the author to create.</param>
        /// <returns>A <see cref="ServiceResponse{AuthorDto}"/> containing the details of the created author.</returns>
        Task<ServiceResponse<AuthorDto>> CreateAsync(CreateAuthorDto createAuthorDto);

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="id">The ID of the author to update.</param>
        /// <param name="updateAuthorDto">The data transfer object containing the updated details of the author.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating the result of the update operation.</returns>
        Task<ServiceResponse> UpdateAsync(int id, UpdateAuthorDto updateAuthorDto);

        /// <summary>
        /// Deletes an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to delete.</param>
        /// <returns>A <see cref="ServiceResponse"/> indicating the result of the delete operation.</returns>
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
