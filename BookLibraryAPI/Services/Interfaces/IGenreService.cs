using BookLibraryAPI.DTOs;
using LibraryManagementAPI.DTOs;

namespace BookLibraryAPI.Services.Interfaces
{
    public interface IGenreService
    {
        Task<ServiceResponse<GenreDto>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<GenreDto>>> GetAllAsync();
        Task<ServiceResponse<GenreDto>> CreateAsync(CreateGenreDto createGenreDto);
        Task<ServiceResponse> UpdateAsync(int id, UpdateGenreDto updateGenreDto);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}