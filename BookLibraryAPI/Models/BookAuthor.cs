namespace BookLibraryAPI.Models
{
    /// <summary>
    /// Represents the association between a book and an author.
    /// </summary>
    public class BookAuthor
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the book associated with the author.
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the author.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the author associated with the book.
        /// </summary>
        public Author Author { get; set; }
    }
}
