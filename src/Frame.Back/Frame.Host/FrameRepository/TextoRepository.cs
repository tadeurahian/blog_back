using Dapper;
using Frame.Util.Enum;
using FrameRepository.Interfaces;
using FrameRepository.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository
{
    public class TextoRepository : BaseRepository, ITextoRepository
    {
        private const string INSERIR_TEXTO = @"INSERT INTO dbo.Texto (Tipo, IdPost, Conteudo)
                                               VALUES ({0}, {1}, '{2}')";
                                                                        
        public void CriarTexto(string conteudo, TipoTexto tipo, int idPost)
        {
            using (var db = CriarConexao())
            {                
                db.Execute(string.Format(INSERIR_TEXTO, (int)tipo, idPost, conteudo));
            }
        }
    }
}
