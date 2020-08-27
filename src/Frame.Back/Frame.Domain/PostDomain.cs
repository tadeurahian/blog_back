using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Util.Excecoes;
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
            if(String.IsNullOrEmpty(titulo))
            {
                throw new ErroCriarPostSemTituloException();
            }

            return _postRepository.CriarPost(titulo, idUsuario);
        }

        public void DeletarPost(int idUsuario, int idPost)
        {
            var post = ObterPost(idPost);

            if (post == null || !post.Ativo)
                return;

            if(idUsuario != post.Usuario.Id)
            {
                throw new ErroExcluirPostDeOutroUsuarioException();
            }

            _postRepository.ExcluirPost(idPost);
        }

        public List<Post> ObterTodosOsPosts()
        {
            return _postRepository.ObterTodosOsPosts();
        }

        public Post ObterPost(int idPost)
        {
            return _postRepository.ObterPost(idPost);
        }
    }
}
