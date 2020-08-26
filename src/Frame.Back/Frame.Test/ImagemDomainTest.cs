using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Models;
using FrameRepository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.Test
{    
    [TestFixture]
    public class ImagemDomainTest
    {
        private Mock<IBlobRepository> _mockBlob;
        private Mock<IImagemRepository> _mockImagemRepository;

        private IImagemDomain _domain
        {
            get
            {
                return new ImagemDomain(_mockBlob.Object, _mockImagemRepository.Object);
            }
        }

        [SetUp]
        public void InicializarMocks()
        {
            _mockBlob = new Mock<IBlobRepository>();
            _mockImagemRepository = new Mock<IImagemRepository>();
        }

        [TestCase]
        public void DeveObterImagensPosts()
        {
            _mockImagemRepository.Setup(x => x.ObterImagensPorPost(1)).Returns(new List<Imagem>() { new Imagem() { Id = 1 } });

            var retorno = _domain.ObterImagensPorPost(1);

            Assert.IsTrue(retorno.Count == 1);
            Assert.IsTrue(retorno.FirstOrDefault().Id == 1);
        }

        [TestCase]
        public void DeveRetornarListaVaziaQuandoNaoHouverImagens()
        {
            _mockImagemRepository.Setup(x => x.ObterImagensPorPost(1)).Returns(new List<Imagem>() { });

            var retorno = _domain.ObterImagensPorPost(1);

            Assert.IsTrue(retorno.Count == 0);
        }
    }
}
