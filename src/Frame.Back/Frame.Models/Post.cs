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
        public int IdUsuarioCriador { get; set; }

        public Usuario Usuario { get; set; }

        public Texto Conteudo { get; set; }
        public Texto Link { get; set; }
        public List<Imagem> Imagens { get; set; }

    }
}
