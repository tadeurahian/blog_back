using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Util.Enum;
using Frame.Util.Excecoes;
using FrameRepository;
using FrameRepository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Test
{
    [TestFixture]
    public class TextoDomainTest
    {
        private Mock<ITextoRepository> _mockTextoRepository;

        private ITextoDomain _domain
        {
            get
            {
                return new TextoDomain(_mockTextoRepository.Object);
            }
        }

        [SetUp]
        public void InicializarMocks()
        {
            _mockTextoRepository = new Mock<ITextoRepository>();
        }

        [TestCase]
        public void DeveCriarConteudo()
        {
            _mockTextoRepository.Setup(x => x.CriarTexto("teste", TipoTexto.Conteudo, 1));

            Assert.DoesNotThrow(() => _domain.CriarConteudo("teste", 1));
        }

        [TestCase]
        public void DeveCriarLink()
        {
            _mockTextoRepository.Setup(x => x.CriarTexto("teste", TipoTexto.Link, 1));

            Assert.DoesNotThrow(() => _domain.CriarLink("teste", 1));
        }

        [TestCase]
        public void NaoDeveCriarConteudoVazio()
        {
            _mockTextoRepository.Setup(x => x.CriarTexto(String.Empty, TipoTexto.Link, 1));

            Assert.Throws<ErroConteudoVazioException>(() => _domain.CriarConteudo(String.Empty, 1));
        }

        [TestCase]
        public void NaoDeveCriarLinkVazio()
        {
            _mockTextoRepository.Setup(x => x.CriarTexto(String.Empty, TipoTexto.Link, 1));

            Assert.Throws<ErroConteudoVazioException>(() => _domain.CriarLink(String.Empty, 1));
        }

        [TestCase]
        public void DeveObterConteudo()
        {
            _mockTextoRepository.Setup(x => x.ObterTextosPost(1)).Returns(new List<Models.Texto>()
            {
                new Models.Texto()
                {
                    IdPost = 1,
                    Tipo = TipoTexto.Conteudo
                }
            });

            var retorno = _domain.ObterConteudoPorPost(1);

            Assert.IsTrue(retorno != null);
            Assert.IsTrue(retorno.Tipo == TipoTexto.Conteudo);
        }

        [TestCase]
        public void DeveObterLink()
        {
            _mockTextoRepository.Setup(x => x.ObterTextosPost(1)).Returns(new List<Models.Texto>()
            {
                new Models.Texto()
                {
                    IdPost = 1,
                    Tipo = TipoTexto.Link
                }
            });

            var retorno = _domain.ObterLinkPorPost(1);

            Assert.IsTrue(retorno != null);
            Assert.IsTrue(retorno.Tipo == TipoTexto.Link);
        }
    }
}
