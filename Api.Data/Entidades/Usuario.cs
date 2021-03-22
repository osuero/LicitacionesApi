using Api.Data.Comunes;

namespace Api.Data.Entities
{
    public class Usuario : PropiedadesComunes
    {
        public string PrimerNombre { get; set; } 
        public string SegundoNombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Restringido { get; set; }
        public bool Eliminado { get; set; }
    }
}
