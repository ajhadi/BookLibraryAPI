namespace LibraryManagementAPI.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class CreateGenreDto
    {
        public required string Name { get; set; }
    }

    public class UpdateGenreDto
    {
        public required string Name { get; set; }
    }
}
