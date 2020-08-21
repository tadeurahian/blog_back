using Frame.Models.Front;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Orq.Interfaces
{
    public interface IPostOrq
    {
        void CriarPost(List<RequisicaoImagem> imagens, string texto, string titulo, string link, string idUsuario);
    }
}
