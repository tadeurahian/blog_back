using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Orq
{
    public interface IUsuarioOrq
    {
        void CriarUsuario(string nome, string senha);
        void ExcluirUsuario(int id);
    }
}
