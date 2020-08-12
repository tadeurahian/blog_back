using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Frame.Models.Front
{
    [DataContract]
    public class RequisicaoCriarUsuario
    {
        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "senha")]
        public string Senha { get; set; }
    }
}
