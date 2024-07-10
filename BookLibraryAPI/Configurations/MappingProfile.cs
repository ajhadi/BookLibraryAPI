using AutoMapper;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Models;
using LibraryManagementAPI.DTOs;

namespace BookLibraryAPI.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Genre mappings
            CreateMap<Genre, GenreDto>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();

            // Author mappings
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorDetailDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Book)));

            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();

            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author)))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.Genre)));

            CreateMap<Book, AuthorBookDto>();

            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
}
