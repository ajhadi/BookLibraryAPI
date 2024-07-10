using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> AddAsync(Book book);
        Task UpdateAsync(Book book, List<int> newAuthorIds, List<int> newGenreIds);
        Task DeleteAsync(int id);
    }
}
