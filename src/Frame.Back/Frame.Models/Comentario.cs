using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Ativo { get; set; }

        public Post Post { get; set; }
        public Usuario UsuarioCriador { get; set; }
        public Comentario ComentarioOriginal { get; set; }
    }
}
