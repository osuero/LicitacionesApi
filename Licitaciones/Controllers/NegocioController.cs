using Api.Business.EntidadRepositorio;
using Api.Data.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Licitaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ApiBaseController<InformacionNegocio, Mappers.NegocioDto>
    {
        public NegocioController(IMapper mapper, NegocioRepositorio repository) : base(mapper, repository)
        {

        }
    }
}
