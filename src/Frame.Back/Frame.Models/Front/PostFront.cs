using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

namespace Frame.Models.Front
{
    [DataContract]
    public class PostFront
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "idCriador")]
        public int IdCriador { get; set; }
        [DataMember(Name = "nomeCriador")]
        public string NomeCriador { get; set; }
        [DataMember(Name = "titulo")]
        public string Titulo { get; set; }
        [DataMember(Name = "conteudo")]
        public string Conteudo { get; set; }
        [DataMember(Name = "link")]
        public string Link { get; set; }
        [DataMember(Name = "imagens")]
        public List<string> Imagens { get; set; }
    }
}