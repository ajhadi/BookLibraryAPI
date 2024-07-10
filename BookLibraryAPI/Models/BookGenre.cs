namespace BookLibraryAPI.Models
{
    /// <summary>
    /// Represents the association between a book and a genre.
    /// </summary>
    public class BookGenre
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the book associated with the genre.
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the genre.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Gets or sets the genre associated with the book.
        /// </summary>
        public Genre Genre { get; set; }
    }
}
