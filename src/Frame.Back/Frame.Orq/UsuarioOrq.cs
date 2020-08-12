using Frame.Domain;
using Frame.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Orq
{
    public class UsuarioOrq : IUsuarioOrq
    {
        private readonly IUsuarioDomain _usuarioDomain;

        public UsuarioOrq(IUsuarioDomain usuarioDomain)
        {
            _usuarioDomain = usuarioDomain;
        }

        public void CriarUsuario(string nome, string senha)
        {
            _usuarioDomain.CriarUsuario(nome, senha);
        }

        public void ExcluirUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
