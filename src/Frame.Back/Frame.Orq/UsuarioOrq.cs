using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Models.Front;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Orq
{
    public class UsuarioOrq : IUsuarioOrq
    {
        private readonly IUsuarioDomain _usuarioDomain;
        private readonly IJwtDomain _jwtDomain;

        public UsuarioOrq(IUsuarioDomain usuarioDomain, IJwtDomain jwtDomain)
        {
            _usuarioDomain = usuarioDomain;
            _jwtDomain = jwtDomain;
        }

        public RetornoAutenticacao AutenticarUsuario(string nome, string senha)
        {
            return GerarRetorno(_usuarioDomain.ObterUsuarioValido(nome, senha));
        }

        public RetornoAutenticacao CriarUsuario(string nome, string senha)
        {            
            return GerarRetorno(_usuarioDomain.CriarUsuario(nome, senha));
        }        

        private RetornoAutenticacao GerarRetorno(Usuario usuario)
        {
            return new RetornoAutenticacao()
            {
                Usuario = usuario,
                Token = _jwtDomain.GerarToken(usuario)
            };
        }
    }
}
