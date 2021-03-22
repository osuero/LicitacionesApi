using Api.Data.Comunes;

namespace Api.Data.Entidades
{
    public class InformacionNegocio: PropiedadesComunes
    {
        public string RazonSocial { get; set; }
        public string NombreJuridico { get; set; }
        public string Identificacion { get; set; }
        public string RegistroProveedor { get; set; }
        public string DomicilioLegal { get; set; }
    }
}
