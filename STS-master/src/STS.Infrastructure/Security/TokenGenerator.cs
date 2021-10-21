using Microsoft.IdentityModel.Tokens;
using STS.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace STS.Infrastructure.Security
{
    public static class TokenGenerator
    {
        public static Token TokenConfig { get; set; }

        public static string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = TokenConfig.ValidoEm,
                Issuer = TokenConfig.Emissor,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nome.ToString()),
                    new Claim(ClaimTypes.Role, user.Grupo.ToString())
                }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(TokenConfig.ExpiracaoEmMinutos),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenConfig.ObterChave()), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}
