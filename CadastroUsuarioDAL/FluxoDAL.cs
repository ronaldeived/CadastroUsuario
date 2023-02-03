using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioDAL
{
    public class FluxoDAL : BaseDAL
    {
        public decimal VerificaNacionalidade(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                connection.Open();
                command = new SqlCommand(@"select ID_PAIS from PROCESSO P
                    INNER JOIN CIDADE C ON C.ID_CIDADE = P.ID_CIDADE
                    INNER JOIN ESTADO E ON E.ID_ESTADO = C.ID_ESTADO
                where ID_PROCESSO = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.CommandType = CommandType.Text;
                decimal id_pais = 0;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    id_pais = Convert.ToDecimal(reader["ID_PAIS"]);
                }
                connection.Close();
                return id_pais;
            }
        }

        public bool EncaminhaGerente(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                command = new SqlCommand(@"update PROCESSO set ID_STATUS = @Status
                where ID_PROCESSO = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Status", 1);
                connection.Open();
                int cont = command.ExecuteNonQuery();
                connection.Close();

                if (cont > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool EncaminhaControleRisco(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                command = new SqlCommand(@"update PROCESSO set ID_STATUS = @Status
                where ID_PROCESSO = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Status", 6);
                connection.Open();
                int cont = command.ExecuteNonQuery();
                connection.Close();

                if (cont > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool EncaminhaCorrecao(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                command = new SqlCommand(@"update PROCESSO set ID_STATUS = @Status
                where ID_PROCESSO = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Status", 5);
                connection.Open();
                int cont = command.ExecuteNonQuery();
                connection.Close();

                if (cont > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool Aprovar(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                command = new SqlCommand(@"update PROCESSO set ID_STATUS = @Status
                where ID_PROCESSO = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Status", 3);
                connection.Open();
                int cont = command.ExecuteNonQuery();
                connection.Close();

                if (cont > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool Reprovar(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                command = new SqlCommand(@"update PROCESSO set ID_STATUS = @Status
                where ID_PROCESSO = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Status", 2);
                connection.Open();
                int cont = command.ExecuteNonQuery();
                connection.Close();

                if (cont > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
