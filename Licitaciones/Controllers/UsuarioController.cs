using Api.Business.EntidadRepositorio;
using Api.Data;
using Api.Data.Entities;
using AutoMapper;
using System.Linq;
using Licitaciones.Helper;
using Licitaciones.Helper.Iservices;
using Microsoft.AspNetCore.Mvc;
using Licitaciones.Mappers;

namespace Licitaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ApiBaseController<Usuario, Mappers.UsuariosDto>
    {
        private IUserServices _userService;
        private UsuarioRepositorio _usuarioRepositorio;
        private ApiDbContext _context;
        private IMapper _mapper;
        public UsuarioController(IMapper mapper, UsuarioRepositorio repository, IUserServices userService, ApiDbContext context) : base(mapper, repository)
        {
            _userService = userService;
            _usuarioRepositorio = repository;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Nombre Usuario or contrasena no es correcto" });
            return Ok(response);
        }

       
        [HttpGet("ValidarUsuario")]
        public IActionResult ValidarUsuario(string usuario) 
        {
            var response = _context.Usuario.Where(x => x.NombreUsuario == usuario && x.Contrasena == null ).FirstOrDefault();
            var entity = _mapper.Map<UsuariosDto>(response);
            return Ok(entity);
        }

        
        [HttpPut("actualizarcontrasena")]
        public IActionResult ActualizarContrasena(UsuariosDto usuario)
        {
            var entidad = _mapper.Map<Usuario>(usuario);
            _userService.CambiarContrasena(usuario);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll().Where(x=>x.Eliminado == false);
            return Ok(users);
        }
    }
}