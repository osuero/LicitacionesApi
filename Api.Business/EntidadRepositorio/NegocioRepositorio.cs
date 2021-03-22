using Api.Business.Repositorios;
using Api.Data;
using Api.Data.Entidades;


namespace Api.Business.EntidadRepositorio
{
    public class NegocioRepositorio: RepositorioGenerico<InformacionNegocio>
    {
        
        public NegocioRepositorio(ApiDbContext _context):base(_context)
        { 
        
        }
    }
}
