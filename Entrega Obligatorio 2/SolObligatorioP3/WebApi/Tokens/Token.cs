using Compartido.DTOs.Usuarios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Tokens
{
    public class Token
    {
        private readonly string _secret;
        public Token(IConfiguration config)
        {
            _secret = config.GetValue<string>("JWT:secret");
        }


        public string Crear(UsuarioDTO dto)
        {
            byte[] clave = Encoding.ASCII.GetBytes(_secret);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();  

            //Se incluye un claim para el email
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, dto.Email),
                    new Claim(ClaimTypes.Role, dto.RolUsuario),
                    new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
