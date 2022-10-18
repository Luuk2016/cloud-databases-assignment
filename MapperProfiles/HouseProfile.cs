
using AutoMapper;
using LKenselaar.CloudDatabases.API.Models;
using LKenselaar.CloudDatabases.API.Models.DTO;

namespace LKenselaar.CloudDatabases
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseResponseDTO>();
            CreateMap<HouseResponseDTO, House>();
        }
    }
}