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
                                                            p.Ativo,
                                                            u.Id,
                                                            u.Nome
                                                        FROM Post p
                                                        INNER JOIN Usuario AS u ON p.IdUsuarioCriador = u.Id
                                                        WHERE p.Ativo = 1
                                                        ORDER BY p.Id DESC
                                                        ";

        private const string OBTER_POST_COM_USUARIO = @"
                                                        SELECT
                                                            p.Id,
                                                            p.Titulo,
                                                            p.Ativo,
                                                            u.Id,
                                                            u.Nome
                                                        FROM Post p
                                                        INNER JOIN Usuario AS u ON p.IdUsuarioCriador = u.Id
                                                        WHERE p.Ativo = 1
                                                        AND p.Id = {0}
                                                        ORDER BY p.Id DESC
                                                        ";

        private const string EXCLUIR_POST = @"UPDATE Post SET Ativo = 0
                                              WHERE Id = {0}";

        public int CriarPost(string titulo, string idUsuarioCriador)
        {
            using (var db = CriarConexao())
            {
                return db.QuerySingle<int>(string.Format(INSERIR_POST, titulo, idUsuarioCriador));
            }
        }

        public void ExcluirPost(int idPost)
        {
            using (var db = CriarConexao())
            {
                db.Execute(string.Format(EXCLUIR_POST, idPost));
            }
        }

        public List<Post> ObterTodosOsPosts()
        {
            using (var db = CriarConexao())
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

        public Post ObterPost(int idPost)
        {
            using (var db = CriarConexao())
            {
                return db.Query<Post, Usuario, Post>
                    (string.Format(OBTER_POST_COM_USUARIO, idPost),
                    (post, usuario) =>
                    {
                        post.Usuario = usuario;

                        return post;
                    },
                    splitOn: "Id").FirstOrDefault();
            }
        }
    }
}
