using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> AddAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Genres
                .AsNoTracking()
                .Where(g => ids.Contains(g.Id))
                .ToListAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            var existingGenre = await _context.Genres.FindAsync(genre.Id);
            if (existingGenre == null)
                throw new InvalidOperationException($"Genre with ID {genre.Id} not found.");
            _context.Entry(existingGenre).CurrentValues.SetValues(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                throw new InvalidOperationException($"Genre with ID {id} not found.");
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
