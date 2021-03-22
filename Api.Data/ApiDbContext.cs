using Api.Data.Entidades;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApiDbContext: DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {


        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<InformacionNegocio> Negocio { get; set; }
        public DbSet<InformacionRepresentante> Representante { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Instituciones> Instituciones { get; set; }
    }
}
