using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioDAL
{
    public class CidadeDAL : BaseDAL
    { 
        public List<Pais> GetListaPais()
        {
            using (connection = new SqlConnection(stringDB))
            {
                List<Pais> paises = new List<Pais>();
                command = new SqlCommand(@"Select * FROM PAIS", connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var pais = new Pais();

                    pais.Id_Pais = Convert.ToInt32(reader["ID_PAIS"]);
                    pais.Nome = reader["NOME"].ToString();
                    paises.Add(pais);
                }
                return paises;
            }
        }

        public List<Estado> GetListaEstado(decimal id_Pais)
        {
            using (connection = new SqlConnection(stringDB))
            {
                List<Estado> estados = new List<Estado>();
                command = new SqlCommand(@"Select * FROM ESTADO WHERE ID_PAIS = @id", connection);
                command.Parameters.AddWithValue("@id", id_Pais);
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var estado = new Estado();

                    estado.Id_Pais = Convert.ToInt32(reader["ID_PAIS"]);
                    estado.Id_Estado = Convert.ToInt32(reader["ID_ESTADO"]);
                    estado.Nome = reader["NOME"].ToString();
                    estados.Add(estado);
                }
                return estados;
            }
        }


        public List<Cidade> GetListaCidade(decimal id_Estado)
        {
            using (connection = new SqlConnection(stringDB))
            {
                List<Cidade> cidades = new List<Cidade>();
                command = new SqlCommand(@"Select * FROM CIDADE WHERE ID_ESTADO = @id", connection);
                command.Parameters.AddWithValue("@id", id_Estado);
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cidade = new Cidade();

                    cidade.Id_Estado = Convert.ToInt32(reader["ID_ESTADO"]);
                    cidade.Id_Cidade = Convert.ToInt32(reader["ID_CIDADE"]);
                    cidade.Nome = reader["NOME"].ToString();
                    cidades.Add(cidade);
                }
                return cidades;
            }

        }

        public int GetIdEstado(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                connection.Open();
                command = new SqlCommand(@"SELECT * FROM ESTADO E
                    INNER JOIN CIDADE C ON  C.ID_ESTADO = E.ID_ESTADO
                WHERE C.ID_CIDADE = @id", connection);

                command.Parameters.AddWithValue("@id", id);
                command.CommandType = CommandType.Text;
                var id_estado = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id_estado = Convert.ToInt32(reader["ID_ESTADO"]);
                }
                connection.Close();
                return id_estado;
            }
        }
        public int GetIdPais(decimal id)
        {
            using (connection = new SqlConnection(stringDB))
            {
                Processo processo = new Processo();
                connection.Open();
                command = new SqlCommand(@"SELECT * FROM ESTADO E
                    INNER JOIN CIDADE C ON  C.ID_ESTADO = E.ID_ESTADO
                WHERE C.ID_CIDADE = @id", connection);

                command.Parameters.AddWithValue("@id", id);
                command.CommandType = CommandType.Text;
                var id_pais = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id_pais = Convert.ToInt32(reader["ID_PAIS"]);

                }
                connection.Close();
                return id_pais;
            }
        }

        public string GetNomeCidade(decimal id_cidade)
        {
            using (connection = new SqlConnection(stringDB))
            {
                connection.Open();
                command = new SqlCommand(@"SELECT C.NOME FROM PROCESSO P
                    INNER JOIN CIDADE C ON  C.ID_CIDADE = P.ID_CIDADE
                WHERE C.ID_CIDADE = @id", connection);

                command.Parameters.AddWithValue("@id", id_cidade);
                command.CommandType = CommandType.Text;
                string nome = null;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nome = reader["NOME"].ToString();
                }
                connection.Close();
                return nome;
            }
        }

        public string GetNomeEstado(decimal id_cidade)
        {
            using (connection = new SqlConnection(stringDB))
            {
                connection.Open();
                command = new SqlCommand(@"SELECT E.NOME FROM ESTADO E
                    INNER JOIN CIDADE C ON  C.ID_ESTADO = E.ID_ESTADO
                WHERE C.ID_CIDADE = @id", connection);

                command.Parameters.AddWithValue("@id", id_cidade);
                command.CommandType = CommandType.Text;
                string nome = null;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nome = reader["NOME"].ToString();
                }
                connection.Close();
                return nome;
            }
        }
        public string GetNomePais(decimal id_cidade)
        {
            using (connection = new SqlConnection(stringDB))
            {
                Processo processo = new Processo();
                connection.Open();
                command = new SqlCommand(@"SELECT P.NOME FROM ESTADO E
                    INNER JOIN CIDADE C ON  C.ID_ESTADO = E.ID_ESTADO
                    INNER JOIN PAIS P ON P.ID_PAIS = E.ID_PAIS
                WHERE C.ID_CIDADE = @id", connection);

                command.Parameters.AddWithValue("@id", id_cidade);
                command.CommandType = CommandType.Text;
                string nome = null;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nome = reader["NOME"].ToString();
                }
                connection.Close();
                return nome;
            }
        }
    }
}
