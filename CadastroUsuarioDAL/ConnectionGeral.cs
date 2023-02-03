using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioDAL
{
    public class ConnectionGeral
    {
        private string stringConnection = @"Data Source=BRPC003828;Initial Catalog=CADASTRO_USUARIO;Persist Security Info=True;User ID=sa;Password=Gftbr!2020";

        public DataSet ReturnDataSet(string Sql)
        {
            SqlConnection connection = new SqlConnection(stringConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Sql, stringConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            connection.Close();
            return dataSet;
        }
    }
}
