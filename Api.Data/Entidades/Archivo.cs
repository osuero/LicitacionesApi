using Api.Data.Comunes;
using System;

namespace Api.Data.Entidades
{
    public class Archivo : PropiedadesComunes
    {
        public string Nombre { get; set; }
        public byte[] Contenido { get; set; }
        public string Extension { get; set;  }
        public DateTime FechaCreacion { get; set; }
        public int Peso { get; set; }
    }
}
