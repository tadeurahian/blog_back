using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository.Interfaces
{
    public interface IBlobRepository
    {
        string Adicionar(string dadosBase64, string mimeType, string titulo);
    }
}
