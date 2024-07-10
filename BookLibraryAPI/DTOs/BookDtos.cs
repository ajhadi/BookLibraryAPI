using LibraryManagementAPI.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing a book.
    /// </summary>
    public class BookDto
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
        /// Gets or sets the publisher of the book.
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
        /// Gets or sets the list of authors of the book.
        /// </summary>
        public List<AuthorDto> Authors { get; set; } = new();

        /// <summary>
        /// Gets or sets the list of genres associated with the book.
        /// </summary>
        public List<GenreDto> Genres { get; set; } = new();
    }

    /// <summary>
    /// Data Transfer Object (DTO) for creating a new book.
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>
        /// Gets or sets the title of the book to be created.
        /// </summary>
        [Required]
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the book to be created.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the book to be created.
        /// </summary>
        public string? Publisher { get; set; }

        /// <summary>
        /// Gets or sets the URL of the cover image for the book to be created.
        /// </summary>
        public string? CoverImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book to be created.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the publication date of the book to be created.
        /// </summary>
        public DateOnly PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the list of author IDs associated with the book to be created.
        /// </summary>
        public List<int> AuthorIds { get; set; } = new();

        /// <summary>
        /// Gets or sets the list of genre IDs associated with the book to be created.
        /// </summary>
        public List<int> GenreIds { get; set; } = new();
    }

    /// <summary>
    /// Data Transfer Object (DTO) for updating an existing book.
    /// </summary>
    public class UpdateBookDto
    {
        /// <summary>
        /// Gets or sets the title of the book to be updated.
        /// </summary>
        [Required]
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the book to be updated.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the book to be updated.
        /// </summary>
        public string? Publisher { get; set; }

        /// <summary>
        /// Gets or sets the URL of the cover image for the book to be updated.
        /// </summary>
        public string? CoverImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book to be updated.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the publication date of the book to be updated.
        /// </summary>
        public DateOnly PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the list of author IDs associated with the book to be updated.
        /// </summary>
        public List<int> AuthorIds { get; set; } = new();

        /// <summary>
        /// Gets or sets the list of genre IDs associated with the book to be updated.
        /// </summary>
        public List<int> GenreIds { get; set; } = new();
    }
}
