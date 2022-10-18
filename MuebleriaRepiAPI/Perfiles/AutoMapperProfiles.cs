using AutoMapper;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Perfiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categorium, CategoriumDTO>();
        }
    }
}
