using Api.Data.Entidades;
using Api.Data.Entities;
using AutoMapper;

namespace Licitaciones.Mappers.MapperPerfiles
{
    public class MapperPerfil : Profile
    {
        public MapperPerfil()
        {
            CreateMap<NegocioDto, InformacionNegocio>().ReverseMap();
            CreateMap<RepresentanteDto, InformacionRepresentante>().ReverseMap();
            CreateMap<UsuariosDto, Usuario>().ReverseMap();
            CreateMap<ArchivosDto, Archivo>().ReverseMap();
        }
    }
}
