using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                    .ThenInclude(a => a.Book)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Authors
                .AsNoTracking()
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<Author> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAsync(Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(author.Id);

            if (existingAuthor == null)
                throw new InvalidOperationException($"Author with ID {author.Id} not found.");

            _context.Entry(existingAuthor).CurrentValues.SetValues(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var author = await _context.Authors
                    .Include(a => a.BookAuthors)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (author == null)
                    throw new InvalidOperationException($"Author with ID {id} not found.");

                _context.BookAuthors.RemoveRange(author.BookAuthors);
                _context.Authors.Remove(author);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException("An error occurred while deleting the author.", ex);
            }
        }

    }
}
