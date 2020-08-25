using Frame.Domain.Interfaces;
using Frame.Models;
using FrameRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain
{
    public class PostDomain : IPostDomain
    {
        private readonly IPostRepository _postRepository;

        public PostDomain(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public int CriarPost(string titulo, string idUsuario)
        {
            return _postRepository.CriarPost(titulo, idUsuario);
        }

        public List<Post> ObterTodosOsPosts()
        {
            return _postRepository.ObterTodosOsPosts();
        }
    }
}
