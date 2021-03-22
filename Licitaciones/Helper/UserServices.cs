using Api.Data;
using Api.Data.Entities;
using AutoMapper;
using Licitaciones.Helper.Iservices;
using Licitaciones.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Licitaciones.Helper
{
    public class UserService : IUserServices
    {
        private readonly AppSettings _appSettings;
        private readonly ApiDbContext _context;
        private IMapper _mapper;
        public UserService(IOptions<AppSettings> appSettings, ApiDbContext context, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        private List<Usuario> _users = new List<Usuario>
        {
            new Usuario { Id = 1, PrimerNombre = "Test", SegundoNombre = "User", NombreUsuario = "test", Contrasena = "test" }
        };

        public IConfiguration Configuration { get; }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _users.SingleOrDefault(x => x.NombreUsuario == model.NombreUsuario && x.Contrasena == model.Contrasena);
            var user = _context.Usuario.SingleOrDefault(x => x.NombreUsuario == model.Username && x.Contrasena == model.Password && x.Eliminado == false);
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public void CambiarContrasena(UsuariosDto usuario) 
        {
            var entidad = _mapper.Map<Usuario>(usuario);

            //_repositorio.Editar(entity);
            _context.Entry(entidad).State = EntityState.Modified;
            _context.SaveChanges();
         
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuario.FirstOrDefault(x => x.Id == id);
        }
        private string generateJwtToken(Usuario user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public void generar()
        {
            //PdfDocument document = new PdfDocument();
            var itemImage = _context.Archivos.Where(x => x.Extension.ToLower() == ".png" || x.Extension.ToLower() == ".jpg").FirstOrDefault();

            var itemPDF = _context.Archivos.Where(x => x.Extension.ToLower() == ".pdf").FirstOrDefault();

            string strType = itemPDF.Extension;
            MemoryStream ms = new MemoryStream(itemPDF.Contenido);
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            //Document doc = new Document(PageSize.LETTER).Add(itemPDF.Contenido);
            StreamReader sr = new StreamReader(ms);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                line.Replace("Titulo", "hola octavio ya lo lograste");
            }



        }
    }
}