using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string LinkBlob { get; set; }

        public Post Post { get; set; }
    }
}
