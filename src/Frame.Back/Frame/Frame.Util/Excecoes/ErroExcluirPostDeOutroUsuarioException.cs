using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Util.Excecoes
{
    public class ErroExcluirPostDeOutroUsuarioException : Exception
    {
        public ErroExcluirPostDeOutroUsuarioException() : base("Apenas é possível excluir posts que você criou!") { }
    }
}
