using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitaciones.Mappers
{
    public class UsuariosDto
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Restringido { get; set; }
        public bool Eliminado { get; set; }
    }
}
