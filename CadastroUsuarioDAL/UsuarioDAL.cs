using CadastroUsuarioModels;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CadastroUsuarioDAL
{
    public class UsuarioDAL : BaseDAL
    {
        public DataSet GetUsuario()
        {
            ConnectionGeral connection = new ConnectionGeral();
            return connection.ReturnDataSet("SELECT * FROM USUARIO");
        }
        public Usuario Login(string login, string senha)
        {
            Usuario usuario = new Usuario();

            using (connection = new SqlConnection(stringDB))
            {
                command = new SqlCommand(@"Select * from USUARIO U
                    INNER JOIN USUARIO_PERFIL UP ON UP.ID_USUARIO = U.ID_USUARIO
                    INNER JOIN PERFIL P on P.ID_PERFIL = UP.ID_PERFIL 
                WHERE LOGIN = @login AND SENHA = @senha", connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@senha", senha);

                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    usuario.Id_Usuario = Convert.ToInt32(reader["ID_USUARIO"]);
                    usuario.Nome = reader["NOME"].ToString();
                    //usuario.Id_Perfil = Convert.ToInt32(reader["ID_PERFIL"]);
                    //usuario.Descricao = reader["DESCRICAO"].ToString();
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
