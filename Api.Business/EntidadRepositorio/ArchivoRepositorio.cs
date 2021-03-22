using Api.Business.Repositorios;
using Api.Data;
using Api.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Business.EntidadRepositorio
{
    public class ArchivoRepositorio : RepositorioGenerico<Archivo>
    {

        public ArchivoRepositorio(ApiDbContext _context) : base(_context)
        {

        }
    }
}
