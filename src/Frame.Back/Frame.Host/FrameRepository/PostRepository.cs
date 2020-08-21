using Dapper;
using FrameRepository.Interfaces;
using FrameRepository.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        private const string INSERIR_POST = @"INSERT INTO Post(Titulo, IdUsuarioCriador)
                                              OUTPUT INSERTED.Id
                                              VALUES('{0}', {1})                                                
                                            ";

        public int CriarPost(string titulo, string idUsuarioCriador)
        {
            using(var db = CriarConexao())
            {
                return db.QuerySingle<int>(string.Format(INSERIR_POST, titulo, idUsuarioCriador));
            }
        }
    }
}
