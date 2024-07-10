namespace BookLibraryAPI.Models
{
    /// <summary>
    /// Represents a genre in the book library system.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Gets or sets the unique identifier of the genre.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of book-genre associations.
        /// </summary>
        public List<BookGenre> BookGenres { get; set; } = new();
    }
}
