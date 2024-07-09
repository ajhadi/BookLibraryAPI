using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<ServiceResponse<AuthorDetailDto>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<AuthorDto>>> GetAllAsync();
        Task<ServiceResponse<AuthorDto>> CreateAsync(CreateAuthorDto createAuthorDto);
        Task<ServiceResponse> UpdateAsync(int id, UpdateAuthorDto updateAuthorDto);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
