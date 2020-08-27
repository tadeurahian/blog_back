using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain.Interfaces
{
    public interface IPostDomain
    {
        int CriarPost(string titulo, string idUsuario);
        List<Post> ObterTodosOsPosts();

        void DeletarPost(int idUsuario, int idPost);
    }
}
