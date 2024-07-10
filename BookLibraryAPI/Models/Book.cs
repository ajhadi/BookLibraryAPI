namespace BookLibraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public string? CoverImageUrl { get; set; }
        public int PageCount { get; set; }
        public DateOnly PublicationDate { get; set; }
        public List<BookAuthor> BookAuthors { get; set; } = [];
        public List<BookGenre> BookGenres { get; set; } = [];
    }
}
