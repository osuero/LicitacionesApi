using Api.Data.Comunes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Entidades
{
    public class Licitacion : PropiedadesComunes
    {
        public string Titulo { get; set; }
        public string Codigo { get; set; }
        public string Institucion { get; set; }
        public Archivo Logo { get; set; }
        public List<Archivo> Adjuntos { get; set; }
        public bool Completada { get; set; }
        public bool Ganada { get; set; }
    }
}
