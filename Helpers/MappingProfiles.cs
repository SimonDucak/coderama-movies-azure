using AutoMapper;
using coderama_movies_server.Dto;
using coderama_movies_server.Models;

namespace coderama_movies_server.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<FavouriteMovie, FavouriteMovieDto>();
            CreateMap<FavouriteMovieDto, FavouriteMovie>();
        }
    }
}

