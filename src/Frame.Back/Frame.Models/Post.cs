using Frame.Util.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Ativo { get; set; }
        public TipoPost Tipo { get; set; }

        public Usuario UsuarioCriador { get; set; }
    }
}
