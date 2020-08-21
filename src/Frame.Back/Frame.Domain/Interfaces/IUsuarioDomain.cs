using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain.Interfaces
{
    public interface IUsuarioDomain
    {
        Usuario CriarUsuario(string nome, string senha);
        Usuario ObterUsuarioValido(string nome, string senha);
    }
}
