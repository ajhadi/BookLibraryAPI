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
            CreateMap<Genre, GenreDto>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorDetailDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
            CreateMap<Book, BookDto>();
            CreateMap<Book, AuthorBookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
}
