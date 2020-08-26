using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Models.Front;
using Frame.Orq.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.Orq
{
    public class PostOrq : IPostOrq
    {
        private readonly IPostDomain _postDomain;
        private readonly ITextoDomain _textoDomain;
        private readonly IImagemDomain _imagemDomain;

        public PostOrq(IPostDomain postDomain, ITextoDomain textoDomain, IImagemDomain imagemDomain)
        {
            _postDomain = postDomain;
            _textoDomain = textoDomain;
            _imagemDomain = imagemDomain;
        }

        public void CriarPost(List<RequisicaoImagem> imagens, string texto, string titulo, string link, string idUsuario)
        {
            var idPost = _postDomain.CriarPost(titulo, idUsuario);

            _textoDomain.CriarConteudo(texto, idPost);

            if (!string.IsNullOrEmpty(link))
            {
                _textoDomain.CriarLink(link, idPost);
            }

            if (imagens.Count != 0)
            {
                imagens.ForEach(imagem => _imagemDomain.CriarImagem(imagem.Imagem, imagem.Mime, imagem.Titulo, idPost));
            }
        }

        public List<PostFront> ObterPosts()
        {
            var posts = _postDomain.ObterTodosOsPosts();

            ObterRelacionamentos(posts);

            return posts.Select(post => new PostFront()
            {
                Titulo = post.Titulo,
                IdCriador = post.Usuario.Id,
                Conteudo = post.Conteudo?.Conteudo,
                Link = post.Link?.Conteudo,
                Imagens = post.Imagens?.Select(imagem => imagem.LinkBlob).ToList()
            }).ToList();
        }

        private void ObterRelacionamentos(List<Post> posts)
        {
            posts.ForEach(post =>
            {
                post.Conteudo = _textoDomain.ObterConteudoPorPost(post.Id);
                post.Link = _textoDomain.ObterLinkPorPost(post.Id);
                post.Imagens = _imagemDomain.ObterImagensPorPost(post.Id);
            });
        }
    }
}
