namespace BookLibraryAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<BookGenre> BookGenres { get; set; } = [];
    }
}
