using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FrameRepository.Util
{
    public class BaseRepository
    {
        private readonly string CHAVE_CONEXAO = "Server=tcp:framework-teste.database.windows.net,1433;Initial Catalog=blogdb;Persist Security Info=False;User ID=tadeurahian;Password=@79135208#trsrb$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected IDbConnection CriarConexao()
        {
            return new SqlConnection(CHAVE_CONEXAO);
        }
    }
}
