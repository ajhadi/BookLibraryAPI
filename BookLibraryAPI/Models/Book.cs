namespace BookLibraryAPI.Models
{
    /// <summary>
    /// Represents a book in the book library system.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the book.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the publisher of the book.
        /// </summary>
        public string? Publisher { get; set; }

        /// <summary>
        /// Gets or sets the URL of the book's cover image.
        /// </summary>
        public string? CoverImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the publication date of the book.
        /// </summary>
        public DateOnly PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the list of book-author associations.
        /// </summary>
        public List<BookAuthor> BookAuthors { get; set; } = new();

        /// <summary>
        /// Gets or sets the list of book-genre associations.
        /// </summary>
        public List<BookGenre> BookGenres { get; set; } = new();
    }
}
