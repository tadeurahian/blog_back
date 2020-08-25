using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Frame.Models.Front
{
    [DataContract]
    public class RetornoPosts
    {
        [DataMember(Name = "posts")]
        public List<PostFront> Posts { get; set; }
    }
}
