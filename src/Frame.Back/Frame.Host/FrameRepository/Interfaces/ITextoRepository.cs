using Frame.Util.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository.Interfaces
{
    public interface ITextoRepository
    {
        void CriarTexto(string conteudo, TipoTexto tipo, int idPost);
    }
}
