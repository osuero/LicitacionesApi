using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitaciones.Mappers
{
    public class ArchivosDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Contenido { get; set; }
        public string Extension { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Peso { get; set; }
    }
}
