using AutoMapper;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestDTO, User>();
            CreateMap<User, CreateUserResponseDTO>();
        }
    }
}