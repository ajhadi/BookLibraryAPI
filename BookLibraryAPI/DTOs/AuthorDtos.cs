namespace BookLibraryAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing an author.
    /// </summary>
    public class AuthorDto
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
    }

    /// <summary>
    /// Data Transfer Object (DTO) for creating a new author.
    /// </summary>
    public class CreateAuthorDto
    {
        /// <summary>
        /// Gets or sets the first name of the author to be created.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the author to be created.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the biography of the author to be created.
        /// </summary>
        public string? Biography { get; set; }
    }

    /// <summary>
    /// Data Transfer Object (DTO) for updating an existing author.
    /// </summary>
    public class UpdateAuthorDto
    {
        /// <summary>
        /// Gets or sets the first name of the author to be updated.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the author to be updated.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the biography of the author to be updated.
        /// </summary>
        public string? Biography { get; set; }
    }

    /// <summary>
    /// Data Transfer Object (DTO) for detailed author information, including related books.
    /// </summary>
    public class AuthorDetailDto
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
        /// Gets or sets the list of books authored by the author.
        /// </summary>
        public List<AuthorBookDto> Books { get; set; } = [];
    }

    /// <summary>
    /// Data Transfer Object (DTO) for representing a book authored by an author.
    /// </summary>
    public class AuthorBookDto
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
        /// Gets or sets the description of the book.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the book's cover image.
        /// </summary>
        public string? CoverImageUrl { get; set; }
    }
}
