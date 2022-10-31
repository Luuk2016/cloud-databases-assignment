using AutoMapper;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.MapperProfiles
{
    public class MortgageProfile : Profile
    {
        public MortgageProfile()
        {
            CreateMap<Mortgage, MortgageResponseDTO>();
        }
    }
}