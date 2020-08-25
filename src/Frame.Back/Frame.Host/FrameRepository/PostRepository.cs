using Dapper;
using Frame.Models;
using Frame.Util.Enum;
using FrameRepository.Interfaces;
using FrameRepository.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameRepository
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        private const string INSERIR_POST = @"INSERT INTO Post(Titulo, IdUsuarioCriador)
                                              OUTPUT INSERTED.Id
                                              VALUES('{0}', {1})                                                
                                            ";

        private const string OBTER_POSTS_COM_USUARIOS = @"
                                                        SELECT
                                                            p.Id,
                                                            p.Titulo,
                                                            u.Id,
                                                            u.Nome
                                                        FROM Post p
                                                        INNER JOIN Usuario AS u ON p.IdUsuarioCriador = u.Id
                                                        ";

        public int CriarPost(string titulo, string idUsuarioCriador)
        {
            using(var db = CriarConexao())
            {
                return db.QuerySingle<int>(string.Format(INSERIR_POST, titulo, idUsuarioCriador));
            }
        }

        public List<Post> ObterTodosOsPosts()
        {
            using(var db = CriarConexao())
            {
                return db.Query<Post, Usuario, Post>
                    (OBTER_POSTS_COM_USUARIOS,
                    (post, usuario) =>
                    {
                        post.Usuario = usuario;

                        return post;
                    },
                    splitOn: "Id").ToList();
            }
        }
    }
}
