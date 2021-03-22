using Api.Data.Entities;

namespace Api.Data
{

    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Usuario user, string token)
        {
            Id = user.Id;
            FirstName = user.PrimerNombre;
            LastName = user.SegundoNombre;
            Username = user.NombreUsuario;
            Token = token;
        }
    }
}
