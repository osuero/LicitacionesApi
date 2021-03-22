using Microsoft.AspNetCore.Http;
using System;

namespace Licitaciones.Mappers
{
    public class InstitucionesDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreContacto { get; set; }
        public string Contacto { get; set; }
        public string Extension { get; set; }
        public IFormFile file { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
