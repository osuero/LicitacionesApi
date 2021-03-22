using Api.Business.InterfazRepositorio;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Business.Repositorios
{
    public class RepositorioGenerico<T> : IinterfazGenerica<T> where T : class
    {
        protected readonly ApiDbContext _context;
        private readonly DbSet<T> _set;

        public RepositorioGenerico(ApiDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Agregar(T entidad)
        {
            _set.Add(entidad);
            Guardar();
        }

        public IQueryable<T> Seleccionar()
        {
            IQueryable<T> query = _set;
            return query;
        }

        public IQueryable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            IQueryable<T> query = _set.Where(predicado);
            return query;
        }

        public void Editar(T entidad)
        {
           _context.Entry(entidad).State = EntityState.Modified;
            Guardar();
        }

        public void Eliminar(T entidad)
        {
            _set.Remove(entidad);
            Guardar();
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }
    }
}
