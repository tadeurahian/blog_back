using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Util.Excecoes;
using FrameRepository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Test
{
    [TestFixture]
    public class UsuarioDomainTest
    {
        private Mock<IUsuarioRepository> _mockUsuario;

        private IUsuarioDomain _domain 
        {
            get
            {
                return new UsuarioDomain(_mockUsuario.Object);
            }
        }

        [SetUp]
        public void InicializarMocks()
        {
            _mockUsuario = new Mock<IUsuarioRepository>();
        }

        [TestCase]
        public void DeveCriarUsuario()
        {
            _mockUsuario.Setup(x => x.CriarUsuario("teste", "teste")).Returns(new Models.Usuario() { Id = 1, Nome = "Tadeu" });

            var usuario = _domain.CriarUsuario("teste", "teste");

            Assert.IsNotNull(usuario);
            Assert.IsTrue(usuario.Id == 1);
            Assert.IsTrue(usuario.Nome == "Tadeu");
        }

        [TestCase]
        public void NaoDeveCriarUsuarioComNomesIguais()
        {            
            _mockUsuario.Setup(x => x.ObterUsuarioPorNome("Tadeu")).Returns(new Models.Usuario() { Id = 1, Nome = "Tadeu" });

            Assert.Throws<ErroCriarUsuarioComMesmoNomeException>(() => _domain.CriarUsuario("Tadeu", "teste"));            
        }

        [TestCase]
        public void DeveExibirErroQuandoUsuarioOuSenhaInvalidos()
        {
            Assert.Throws<UsuarioOuSenhaInvalidosException>(() => _domain.ObterUsuarioValido("teste", "teste"));
        }
    }
}
