using Frame.Domain.Interfaces;
using Frame.Util.Enum;
using FrameRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain
{
    public class TextoDomain : ITextoDomain
    {
        private readonly ITextoRepository _textoRepository;

        public TextoDomain(ITextoRepository textoRepository)
        {
            _textoRepository = textoRepository;
        }

        public void CriarConteudo(string conteudo, int idPost)
        {
            CriarTexto(conteudo, TipoTexto.Texto, idPost);
        }

        public void CriarLink(string link, int idPost)
        {
            CriarTexto(link, TipoTexto.Link, idPost);
        }

        private void CriarTexto(string conteudo, TipoTexto tipo, int idPost)
        {
            _textoRepository.CriarTexto(conteudo, tipo, idPost);
        }
    }
}
