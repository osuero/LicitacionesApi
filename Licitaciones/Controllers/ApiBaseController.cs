using Api.Data.Comunes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Api.Business.Repositorios;
using Licitaciones.Helper;

namespace Licitaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<T, TD> : ControllerBase
      where T : PropiedadesComunes
      where TD : class
    {
        protected readonly RepositorioGenerico<T> _repositorio;
        protected readonly IMapper _mapper;

        public ApiBaseController(IMapper mapper, RepositorioGenerico<T> repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public List<T> Get()
        {
            var result = _repositorio.Seleccionar();
            return result.ToList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public string Get(int id)
        {
            var objectEntity = _repositorio.Buscar(x => x.Id == id);

            return objectEntity.ToString();
        }

        [HttpPost]
        [Authorize]
        public void Post([FromBody] TD body)
        {
            var resource = _mapper.Map<T>(body);

            _repositorio.Agregar(resource);
        }

        [HttpPut]
        [Authorize]
        public void Put([FromBody] T value)
        {
            _repositorio.Editar(value);

        }

        [HttpDelete]
        [Authorize]
        public void Delete([FromBody] T value)
        {
            _repositorio.Eliminar(value);
        }
    }
}
