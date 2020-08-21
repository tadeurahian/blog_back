using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain.Interfaces
{
    public interface IImagemDomain
    {
        void CriarImagem(string imagem, string mime, string titulo, int idPost);
    }
}
