using System.Runtime.Serialization;

namespace Frame.Models.Front
{
    [DataContract]
    public class RequisicaoImagem
    {
        [DataMember(Name = "imagem")]
        public string Imagem { get; set; }
        [DataMember(Name = "mime")]
        public string Mime { get; set; }
        [DataMember(Name = "Titulo")]
        public string Titulo { get; set; }
    }
}