using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository.Interfaces
{
    public interface IUsuarioRepository 
    {
        void CriarUsuario(string nome, string senha)
        void ExcluirUsuario(int id);
    }
}
