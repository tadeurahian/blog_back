using Frame.Domain.Interfaces;
using Frame.Models.Front;
using Frame.Orq.Interfaces;
using System;
using System.Collections.Generic;
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

            if (!string.IsNullOrEmpty(texto))
            {
                _textoDomain.CriarConteudo(texto, idPost);
            }

            if (!string.IsNullOrEmpty(link))
            {
                _textoDomain.CriarLink(link, idPost);
            }

            if (imagens.Count != 0)
            {
                imagens.ForEach(imagem => _imagemDomain.CriarImagem(imagem.Imagem, imagem.Mime, imagem.Titulo, idPost));
            }
        }
    }
}
