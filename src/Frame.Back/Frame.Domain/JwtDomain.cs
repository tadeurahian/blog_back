using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Util;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Frame.Domain
{
    public class JwtDomain : IJwtDomain
    {
        public string GerarToken(Usuario usuario)
        {
            var handler = new JwtSecurityTokenHandler();
            var segredoEmBytes = Encoding.ASCII.GetBytes(Constantes.JWT.CHAVE);

            var config = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.PrimarySid, usuario.Id.ToString())
                }),                
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(segredoEmBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            

            return handler.WriteToken(handler.CreateToken(config));
        }
    }
}
