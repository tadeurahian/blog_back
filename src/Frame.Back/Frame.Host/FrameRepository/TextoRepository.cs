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
    public class TextoRepository : BaseRepository, ITextoRepository
    {
        private const string INSERIR_TEXTO = @"INSERT INTO dbo.Texto (Tipo, IdPost, Conteudo)
                                               VALUES ({0}, {1}, '{2}')";

        private const string OBTER_TEXTOS_POST = @"SELECT * FROM dbo.Texto 
                                                   WHERE IdPost = {0}";
                                                                        
        public void CriarTexto(string conteudo, TipoTexto tipo, int idPost)
        {
            using (var db = CriarConexao())
            {                
                db.Execute(string.Format(INSERIR_TEXTO, (int)tipo, idPost, conteudo));
            }
        }

        public List<Texto> ObterTextosPost(int idPost)
        {
            using(var db = CriarConexao())
            {
                return db.Query<Texto>(string.Format(OBTER_TEXTOS_POST, idPost)).ToList();
            }
        }
    }
}
