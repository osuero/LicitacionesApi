using Api.Business.Repositorios;
using Api.Data;
using Api.Data.Entities;

namespace Api.Business.EntidadRepositorio
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>
    {
        public UsuarioRepositorio(ApiDbContext _context) : base(_context)
        {
        }
    }
}
