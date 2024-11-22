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

        /*
         var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("NombreUsuario", nombreUsuario),
                new Claim("UsuarioId", usuarioId)
            };

            string? secret = _config["JWTConfig:Secret"]
                ?? throw new ExcepcionInesperadaControlada("Error en la configuracion de JWT");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityTokenHandler()
                .WriteToken(new JwtSecurityToken(
                    claims: claims, 
                    expires: DateTime.UtcNow.AddHours(1), 
                    signingCredentials: creds
                ));

         */

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
