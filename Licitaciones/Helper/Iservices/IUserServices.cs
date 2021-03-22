using Api.Data;
using Api.Data.Entities;
using Licitaciones.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Licitaciones.Helper.Iservices
{
    public interface IUserServices
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        void CambiarContrasena(UsuariosDto usuariosDto);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
    }
}
