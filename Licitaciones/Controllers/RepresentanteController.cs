using Api.Business.EntidadRepositorio;
using Api.Data.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Licitaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentanteController : ApiBaseController<InformacionRepresentante, Mappers.NegocioDto>
    {
        public RepresentanteController(IMapper mapper, RepresentanteRepositorio repository) : base(mapper, repository)
        {

        }
    }
}
