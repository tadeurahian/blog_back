using Dapper;
using Frame.Models;
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

        private const string BUSCAR_USUARIO_POR_NOME_E_SENHA = @"SELECT U.Nome, U.Id 
                                                                 FROM USUARIO U 
                                                                 WHERE U.Nome = '{0}' and U.Senha = '{1}'";

        private const string BUSCAR_USUARIO_POR_NOME = @"SELECT U.Nome, U.Id 
                                                                 FROM USUARIO U 
                                                                 WHERE U.Nome = '{0}'";
        #endregion


        public Usuario CriarUsuario(string nome, string senha)
        {            
            using(var db = CriarConexao())
            {
                db.Execute(string.Format(INSERIR_USUARIO, nome, senha));

                return ObterUsuarioPorNome(nome);
            }
        }

        public Usuario ObterUsuarioPorNomeESenha(string nome, string senha)
        {
            using(var db = CriarConexao())
            {
                return db.QueryFirstOrDefault<Usuario>(string.Format(BUSCAR_USUARIO_POR_NOME_E_SENHA, nome, senha));
            }
        }

        public Usuario ObterUsuarioPorNome(string nome)
        {
            using (var db = CriarConexao())
            {
                return db.QueryFirstOrDefault<Usuario>(string.Format(BUSCAR_USUARIO_POR_NOME, nome));
            }
        }
    }
}
