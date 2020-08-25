using Dapper;
using Frame.Models;
using FrameRepository.Interfaces;
using FrameRepository.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace FrameRepository
{
    public class ImagemRepository : BaseRepository, IImagemRepository
    {
        private const string INSERIR_IMAGEM = @"INSERT INTO Imagem(Titulo, LinkBlob, IdPost)
                                                VALUES('{0}', '{1}', {2})";

        private const string OBTER_IMAGENS_POR_POST = @"SELECT * FROM Imagem WHERE IdPost = {0}";

        public void CriarImagem(string uriImagem, string titulo, int idPost)
        {
            using(var db = CriarConexao())
            {
                db.Execute(string.Format(INSERIR_IMAGEM, titulo, uriImagem, idPost));
            }            
        }

        public List<Imagem> ObterImagensPorPost(int idPost)
        {
            using(var db = CriarConexao())
            {
                return db.Query<Imagem>(string.Format(OBTER_IMAGENS_POR_POST, idPost)).ToList();
            }
        }
    }
}
