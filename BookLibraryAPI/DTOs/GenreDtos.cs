namespace LibraryManagementAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing a genre.
    /// </summary>
    public class GenreDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the genre.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        public required string Name { get; set; }
    }

    /// <summary>
    /// Data Transfer Object (DTO) for creating a new genre.
    /// </summary>
    public class CreateGenreDto
    {
        /// <summary>
        /// Gets or sets the name of the genre to be created.
        /// </summary>
        public required string Name { get; set; }
    }

    /// <summary>
    /// Data Transfer Object (DTO) for updating an existing genre.
    /// </summary>
    public class UpdateGenreDto
    {
        /// <summary>
        /// Gets or sets the name of the genre to be updated.
        /// </summary>
        public required string Name { get; set; }
    }
}
