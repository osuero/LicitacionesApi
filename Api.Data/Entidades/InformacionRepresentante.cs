using Api.Data.Comunes;

namespace Api.Data.Entidades
{
    public class InformacionRepresentante : PropiedadesComunes
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string OtrosContactos { get; set; }
        public string Direccion {get;set;}
        public string Correo { get; set; }
    }
}
