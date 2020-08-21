using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Util.Excecoes
{
    public class ErroCriarUsuarioComMesmoNomeException : Exception
    {
        public ErroCriarUsuarioComMesmoNomeException() : base("Já existe um usuário com esse nome.") { }
    }
}
