using Api.Business.EntidadRepositorio;
using Api.Data;
using Api.Data.Entidades;
using AutoMapper;
using Licitaciones.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ApiBaseController<Instituciones, InstitucionesDto>
    {
        public InstitucionController(IMapper mapper, InstitucionesRepositorio repository,  ApiDbContext context) : base(mapper, repository)
        {

        }
    }
}
