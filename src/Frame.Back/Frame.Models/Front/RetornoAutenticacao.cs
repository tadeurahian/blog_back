using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Models.Front
{
    public class RetornoAutenticacao
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
