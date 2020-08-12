using Frame.Util.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Models
{
    public class Texto
    {
        public int Id { get; set; }
        public TipoTexto Tipo { get; set; }
        public string TextoOuLink { get; set; }

        public Post Post { get; set; }

    }
}
