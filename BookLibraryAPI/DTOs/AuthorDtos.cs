namespace BookLibraryAPI.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
    }
    public class CreateAuthorDto
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
    }
    public class UpdateAuthorDto
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
    }
    public class AuthorDetailDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
        public List<AuthorBookDto> Books { get; set; } = [];
    }

    public class AuthorBookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
