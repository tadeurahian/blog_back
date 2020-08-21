using Dapper;
using FrameRepository.Interfaces;
using FrameRepository.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameRepository
{
    public class ImagemRepository : BaseRepository, IImagemRepository
    {
        private const string INSERIR_IMAGEM = @"INSERT INTO Imagem(Titulo, LinkBlob, IdPost)
                                                VALUES('{0}', '{1}', {2})";

        public void CriarImagem(string uriImagem, string titulo, int idPost)
        {
            using(var db = CriarConexao())
            {
                db.Execute(string.Format(INSERIR_IMAGEM, uriImagem, titulo, idPost));
            }            
        }
    }
}
