using Api.Data;
using Api.Data.Entidades;
using AutoMapper;
using Licitaciones.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Api.Business.EntidadRepositorio;
using Microsoft.AspNetCore.Hosting;

namespace Licitaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ApiBaseController<Archivo, Mappers.ArchivosDto>
    {
        private ApiDbContext _context;
        public IWebHostEnvironment _enviroment;
        private IMapper _mapper;

        public ArchivoController( IWebHostEnvironment enviroment, ApiDbContext context, IMapper mapper, ArchivoRepositorio repository) : base(mapper, repository)
        {
            _context = context;
            _mapper = mapper;
            _enviroment = enviroment;
        }

        [HttpPost("Guardar")]
        public ActionResult Guardar(IFormFile file)
        {

            var objetoArchivo = new ArchivosDto()
            {
                Nombre = Path.GetFileName(file.FileName),
                Extension = Path.GetExtension(Path.GetFileName(file.FileName)),
                FechaCreacion = DateTime.Now
            };

            using (var ruta = new MemoryStream())
            {
                file.CopyTo(ruta);
                objetoArchivo.Contenido = ruta.ToArray();
            }
            var entidad = _mapper.Map<Archivo>(objetoArchivo);

            _context.Archivos.Add(entidad);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("cargarLogos")]
        public IActionResult CargarLogos()
        {
            var item = _repositorio.Seleccionar().Where(x => x.Extension.ToLower() == ".png" || x.Extension.ToLower() == ".jpg").ToList();
            return Ok(item);
        }

        [HttpGet("visualizar")]
        public IActionResult Visualizar(int id)
        {
            var item = _context.Archivos.Where(x => x.Id == id).FirstOrDefault();
            var entidad = _mapper.Map<ArchivosDto>(item);
            return Ok(entidad.Contenido);
        }

        [HttpDelete("eliminar")]
        public IActionResult Eliminar(int id)
        {
            var objetoEliminar = _context.Archivos.Where(x => x.Id == id).FirstOrDefault();
            if (objetoEliminar != null) {
                _context.Archivos.Remove(objetoEliminar);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
