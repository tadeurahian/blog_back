using Frame.Models.Front;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Orq
{
    public interface IUsuarioOrq
    {
        RetornoAutenticacao CriarUsuario(string nome, string senha);        
        RetornoAutenticacao AutenticarUsuario(string nome, string senha);
    }
}
