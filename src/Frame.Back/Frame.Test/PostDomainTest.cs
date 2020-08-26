using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Util.Excecoes;
using FrameRepository;
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
    public class PostDomainTest
    {
        private Mock<IPostRepository> _mockPostRepository;

        private IPostDomain _domain
        {
            get
            {
                return new PostDomain(_mockPostRepository.Object);
            }
        }

        [SetUp]
        public void InicializarMocks()
        {
            _mockPostRepository = new Mock<IPostRepository>();
        }

        [TestCase]
        public void DeveCriarPost()
        {
            _mockPostRepository.Setup(x => x.CriarPost("x", "y")).Returns(1);

            var idPost = _domain.CriarPost("x", "y");

            Assert.IsTrue(idPost == 1);
        }

        [TestCase]
        public void NaoDeveSerPermitidoPostSemTitulo()
        {
            Assert.Throws<ErroCriarPostSemTituloException>(() => _domain.CriarPost(String.Empty, "1"));
        }

        [TestCase]
        public void DeveObterTodosOsPosts()
        {
            _mockPostRepository.Setup(x => x.ObterTodosOsPosts()).Returns(new List<Post>() { new Post() { Id = 1 } });

            var retorno = _domain.ObterTodosOsPosts();

            Assert.IsTrue(retorno.Count != 0);
            Assert.IsTrue(retorno.FirstOrDefault().Id == 1);
        }        
    }
}
