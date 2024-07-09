namespace BookLibraryAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
        public List<Book> Books { get; set; } = [];
    }
}
