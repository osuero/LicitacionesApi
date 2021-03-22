using Api.Data.Comunes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Entidades
{
    public class Instituciones : PropiedadesComunes
    {
        public string Nombre { get; set; }
        public string NombreContacto { get; set; }
        public string Contacto { get; set; }
        public byte[] Logo { get; set; }
        public string Extension { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
