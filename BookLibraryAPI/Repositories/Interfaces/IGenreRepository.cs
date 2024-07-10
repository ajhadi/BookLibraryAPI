using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAsync(int id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<IEnumerable<Genre>> GetByIdsAsync(IEnumerable<int> ids);
        Task<Genre> AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(int id);
    }
}
