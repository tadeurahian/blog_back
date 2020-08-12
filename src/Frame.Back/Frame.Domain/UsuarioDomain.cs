using Frame.Domain.Interfaces;
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

        public void CriarUsuario(string nome, string senha)
        {
            _usuarioRepository.CriarUsuario(nome, senha);
        }

        public void ExcluirUsuario(int id)
        {
            _usuarioRepository.ExcluirUsuario(id);
        }
    }
}
