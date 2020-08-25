using Frame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository.Interfaces
{
    public interface IPostRepository
    {
        int CriarPost(string titulo, string idUsuarioCriador);
        List<Post> ObterTodosOsPosts();
    }
}
