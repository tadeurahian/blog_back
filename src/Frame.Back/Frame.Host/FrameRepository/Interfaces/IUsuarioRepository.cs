using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository.Interfaces
{
    public interface IUsuarioRepository 
    {
        Usuario CriarUsuario(string nome, string senha);        
        Usuario ObterUsuarioPorNomeESenha(string nome, string senha);
        Usuario ObterUsuarioPorNome(string nome);
    }
}
