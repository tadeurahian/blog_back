using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Util.Excecoes
{
    public class ErroCriarPostSemTituloException : Exception
    {
        public ErroCriarPostSemTituloException() : base("O título do post é obrigatório.") { }
    }
}
