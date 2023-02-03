using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroUsuario
{
    public partial class Frm_Login : Form
    {
        /*Alguns comandos de sql*/
        SqlConnection connection = new SqlConnection(@"Data Source=BRPC003828;Initial Catalog=CADASTRO_USUARIO;Persist Security Info=True;User ID=sa;Password=Gftbr!2020");
        SqlCommand sqlCommand;
        SqlDataAdapter dataAdapter;

        public Frm_Login()
        {
            InitializeComponent();
        }

        /*Método para logar em um processo*/
        public void Btn_Entrar_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand(@"Select U.NOME from USUARIO U
                INNER JOIN USUARIO_PERFIL UP ON UP.ID_USUARIO = U.ID_USUARIO 
            WHERE LOGIN= '" + Txt_Usuario.Text + "' AND SENHA = '" + Txt_Senha.Text + "' AND ID_PERFIL = 3", connection);


            dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable data = new DataTable();
            dataAdapter.Fill(data);
            try
            {
                if (data.Rows.Count == 1)
                {
                    DataRow myRow = data.Rows[0];
                    string nome_Usuario = myRow["NOME"].ToString();
                    this.Hide();
                    new ProcessoForm(nome_Usuario).Show();
                }
                else
                {
                    MessageBox.Show("Login ou Senha incorreto!");
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
