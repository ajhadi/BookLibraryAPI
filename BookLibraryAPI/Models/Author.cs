namespace BookLibraryAPI.Models
{
    /// <summary>
    /// Represents an author in the book library system.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Gets or sets the unique identifier of the author.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the author.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the author.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the biography of the author.
        /// </summary>
        public string? Biography { get; set; }

        /// <summary>
        /// Gets or sets the list of books associated with the author.
        /// </summary>
        public List<BookAuthor> BookAuthors { get; set; } = new();
    }
}
