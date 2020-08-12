using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Models.Front
{
    public class RetornoPadrao<T> where T : class
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Resultado { get; set; }
    }
}
