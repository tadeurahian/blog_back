using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository.Interfaces
{
    public interface IImagemRepository
    {
        void CriarImagem(string uriImagem, string titulo, int idPost);
        List<Imagem> ObterImagensPorPost(int idPost);
    }
}
