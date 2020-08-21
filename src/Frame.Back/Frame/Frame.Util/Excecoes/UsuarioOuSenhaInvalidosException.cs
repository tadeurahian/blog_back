using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Util.Excecoes
{
    public class UsuarioOuSenhaInvalidosException : Exception
    {
        public UsuarioOuSenhaInvalidosException() : base("Usuário ou senha inválidos") { }
    }
}
