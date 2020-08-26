using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Util.Excecoes
{
    public class ErroConteudoVazioException : Exception
    {
        public ErroConteudoVazioException(string mensagem) : base(mensagem) { }
    }
}
