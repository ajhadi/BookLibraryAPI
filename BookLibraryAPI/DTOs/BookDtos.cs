using LibraryManagementAPI.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public string? CoverImageUrl { get; set; }
        public int PageCount { get; set; }
        public DateOnly PublicationDate { get; set; }
        public List<AuthorBookDto> Authors { get; set; } = new();
        public List<GenreDto> Genres { get; set; } = new();
    }
    public class CreateBookDto
    {
        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public string? CoverImageUrl { get; set; }
        public int PageCount { get; set; }
        public DateOnly PublicationDate { get; set; }
        public List<int> AuthorIds { get; set; } = new();
        public List<int> GenreIds { get; set; } = new();
    }
    public class UpdateBookDto
    {
        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public string? CoverImageUrl { get; set; }
        public int PageCount { get; set; }
        public DateOnly PublicationDate { get; set; }
        public List<int> AuthorIds { get; set; } = new();
        public List<int> GenreIds { get; set; } = new();
    }
}
