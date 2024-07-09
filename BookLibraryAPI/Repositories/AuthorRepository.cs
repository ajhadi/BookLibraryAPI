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
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
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
            _context.Entry(existingAuthor).CurrentValues.SetValues(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
