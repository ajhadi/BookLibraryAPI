using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Models;
using LibraryManagementAPI.DTOs;

namespace BookLibraryAPI.Configurations
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between data transfer objects (DTOs) and entity models.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class and sets up the mapping configurations.
        /// </summary>
        public MappingProfile()
        {
            // Genre mappings
            CreateMap<Genre, GenreDto>()
                .ReverseMap();

            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();

            // Author mappings
            CreateMap<Author, AuthorDto>()
                .ReverseMap();

            CreateMap<Author, AuthorDetailDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Book)));

            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();

            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author)))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.Genre)));

            CreateMap<Book, AuthorBookDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.CoverImageUrl));

            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
}
