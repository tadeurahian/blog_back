using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Frame.Models.Front
{
    [DataContract]
    public class RequisicaoCriarPost
    {
        [DataMember(Name = "titulo")]
        public string Titulo { get; set; }
        [DataMember(Name = "texto")]
        public string Texto { get; set; }
        [DataMember(Name = "imagens")]
        public List<RequisicaoImagem> Imagens { get; set; }
        [DataMember(Name = "link")]
        public string Link { get; set; }
    }
}
