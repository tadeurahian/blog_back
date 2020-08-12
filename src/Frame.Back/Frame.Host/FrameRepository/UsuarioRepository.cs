using Dapper;
using FrameRepository.Interfaces;
using FrameRepository.Util;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FrameRepository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        #region SQL's

        private readonly string INSERIR_USUARIO = @"INSERT INTO Usuario(Nome, Senha)
                                                    VALUES ('{0}', '{1}')";

        private readonly string EXCLUIR_USUARIO = @"UPDATE Usuario
                                                   SET Ativo = 0
                                                   WHERE Id = {0}";
        #endregion


        public void CriarUsuario(string nome, string senha)
        {            
            using(var db = CriarConexao())
            {
                db.Execute(string.Format(INSERIR_USUARIO, nome, senha));
            }
        }

        public void ExcluirUsuario(int id)
        {
            using (var db = CriarConexao())
            {
                db.Execute(string.Format(EXCLUIR_USUARIO, id));
            }
        }
    }
}
