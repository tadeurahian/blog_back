using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Frame.Test
{
    [TestFixture]
    public class JwtDomainTest
    {
        public readonly Usuario UsuarioMock = new Usuario()
        {
            Id = 1,
            Nome = "Tadeu Rahian"
        };

        private IJwtDomain _domain
        {
            get
            {
                return new JwtDomain();
            }
        }

        [TestCase]
        public void DeveObterTokenParaUsuario()
        {
            var token = _domain.GerarToken(UsuarioMock);

            Assert.IsFalse(string.IsNullOrEmpty(token));
        }

        [TestCase]
        public void DeveGerarOsClaimsCorretamente()
        {
            var token = _domain.GerarToken(UsuarioMock);
            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptografado = handler.ReadJwtToken(token);

            Assert.IsTrue(tokenDescriptografado.Claims.Where(claim => claim.Type == "primarysid").FirstOrDefault().Value == UsuarioMock.Id.ToString());
        }
    }
}
