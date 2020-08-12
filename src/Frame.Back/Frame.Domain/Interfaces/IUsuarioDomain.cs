using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain.Interfaces
{
    public interface IUsuarioDomain
    {
        void CriarUsuario(string nome, string senha);
        void ExcluirUsuario(int id);
    }
}
