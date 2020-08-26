using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Util.Excecoes
{
    public class CamposVaziosCriarUsuariosException : Exception
    {
        public CamposVaziosCriarUsuariosException() : base("Todos os campos são obrigatórios!") { }
    }
}
