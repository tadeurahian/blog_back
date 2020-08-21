using Frame.Domain.Interfaces;
using Frame.Models;
using Frame.Util.Excecoes;
using FrameRepository;
using FrameRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain
{
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomain(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario CriarUsuario(string nome, string senha)
        {
            var usuarioComMesmoNome = _usuarioRepository.ObterUsuarioPorNome(nome);

            if (usuarioComMesmoNome != null)
            {
                throw new ErroCriarUsuarioComMesmoNomeException();
            }

            return _usuarioRepository.CriarUsuario(nome, senha);
        }

        public Usuario ObterUsuarioValido(string nome, string senha)
        {
            var usuario = _usuarioRepository.ObterUsuarioPorNomeESenha(nome, senha);

            if (usuario == null)
                throw new UsuarioOuSenhaInvalidosException();

            return usuario;
        }
    }
}
