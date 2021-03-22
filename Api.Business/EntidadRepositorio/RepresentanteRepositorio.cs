using Api.Business.Repositorios;
using Api.Data;
using Api.Data.Entidades;

namespace Api.Business.EntidadRepositorio
{
    public class RepresentanteRepositorio : RepositorioGenerico<InformacionRepresentante>
    {
        public RepresentanteRepositorio(ApiDbContext _context) : base(_context)
        {

        }
    }
}
