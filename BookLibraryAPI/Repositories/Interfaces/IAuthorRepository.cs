using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author?> GetByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task<IEnumerable<Author>> GetByIdsAsync(IEnumerable<int> ids);
        Task<Author> AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
