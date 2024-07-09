using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<ServiceResponse<IEnumerable<BookDto>>> GetAllAsync();
        Task<ServiceResponse<BookDto>> GetByIdAsync(int id);
        Task<ServiceResponse<BookDto>> CreateAsync(CreateBookDto createBookDto);
        Task<ServiceResponse> UpdateAsync(int id, UpdateBookDto updateBookDto);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
