using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(b => b.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var book =  await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(b => b.Author)
                .Include(b => b.BookGenres)
                .ThenInclude(b => b.Genre)
                .ToListAsync();
            return book;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateAsync(Book book, List<int> newAuthorIds, List<int> newGenreIds)
        {
            var existingBook = await _context.Books
                .Include(b => b.BookAuthors)
                .Include(b => b.BookGenres)
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            if (existingBook != null)
            {
                _context.Entry(existingBook).CurrentValues.SetValues(book);

                _context.BookAuthors.RemoveRange(existingBook.BookAuthors);
                _context.BookGenres.RemoveRange(existingBook.BookGenres);

                var newBookAuthors = newAuthorIds.Select(authorId => new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = authorId
                }).ToList();

                var newBookGenres = newGenreIds.Select(genreId => new BookGenre
                {
                    BookId = book.Id,
                    GenreId = genreId
                }).ToList();

                _context.BookAuthors.AddRange(newBookAuthors);
                _context.BookGenres.AddRange(newBookGenres);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.BookAuthors)
                .Include(b => b.BookGenres)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book != null)
            {
                _context.BookAuthors.RemoveRange(book.BookAuthors);
                _context.BookGenres.RemoveRange(book.BookGenres);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
