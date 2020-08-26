using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Util.Enum;
using Frame.Util.Excecoes;
using FrameRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CriarTexto(conteudo, TipoTexto.Conteudo, idPost);
        }

        public void CriarLink(string link, int idPost)
        {
            CriarTexto(link, TipoTexto.Link, idPost);
        }

        public Texto ObterConteudoPorPost(int idPost)
        {
            return ObterTexto(idPost, TipoTexto.Conteudo);
        }

        public Texto ObterLinkPorPost (int idPost)
        {
            return ObterTexto(idPost, TipoTexto.Link);
        }

        private void CriarTexto(string conteudo, TipoTexto tipo, int idPost)
        {
            if(String.IsNullOrEmpty(conteudo))
            {
                if (tipo == TipoTexto.Conteudo)
                    throw new ErroConteudoVazioException("O conteudo não pode estar vazio");

                throw new ErroConteudoVazioException("O link não pode estar vazio");
            }                

            _textoRepository.CriarTexto(conteudo, tipo, idPost);
        }

        private Texto ObterTexto(int idPost, TipoTexto tipo)
        {
            return _textoRepository.ObterTextosPost(idPost)?.Where(texto => texto.Tipo == tipo).FirstOrDefault();
        }
    }
}
