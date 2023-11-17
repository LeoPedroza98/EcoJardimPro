using AutoMapper;
using EcoJardimProject.Domain.DTOs;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.Data.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, UsuarioDTO>();
                config.CreateMap<UsuarioDTO, Usuario>();
                config.CreateMap<Usuario, LoginDTO>();
            });
            return mappingConfig;
        }
    }
}
