using System;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Business.InterfazRepositorio
{
    public interface IinterfazGenerica<T> where T : class
    {
        IQueryable<T> Seleccionar();
        IQueryable<T> Buscar(Expression<Func<T, bool>> predicado);
        void Agregar(T entidad);
        void Eliminar(T entidad);
        void Editar(T entidad);
        void Guardar();
    }
}
