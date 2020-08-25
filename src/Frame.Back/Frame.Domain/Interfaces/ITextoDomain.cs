using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain.Interfaces
{
    public interface ITextoDomain
    {
        void CriarConteudo(string conteudo, int idPost);
        void CriarLink(string link, int idPost);
        Texto ObterConteudoPorPost(int idPost);
        Texto ObterLinkPorPost(int idPost);
    }
}
