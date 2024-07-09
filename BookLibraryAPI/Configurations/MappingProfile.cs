using AutoMapper;
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
        }
    }
}
