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
    public partial class ProcessoForm : Form
    {
        /*Atributos relacionados ao index da linha na tabela e o ID_Processo */
        int indexRow;
        int id_Processo;

        /*Atributos relacionados ao banco de dados */
        SqlConnection connection = new SqlConnection(@"Data Source=BRPC003828;Initial Catalog=CADASTRO_USUARIO;Persist Security Info=True;User ID=sa;Password=Gftbr!2020");
        SqlCommand sqlCommand;
        SqlDataAdapter dataAdapter;
        public string nome_Usuario { get; set; }


        public ProcessoForm(string _nome_Usuario)
        {
            InitializeComponent();
            autoTableUpdate();
            nome_Usuario = _nome_Usuario;
            setNomeUsuario();
        }
        /* Metodo de atualização de tabela */
        private void autoTableUpdate()
        {
            sqlCommand = new SqlCommand(@"select PAIS.NOME AS PAIS, ESTADO.NOME AS ESTADO, CIDADE.NOME AS CIDADE, STATUS.DESCRICAO AS STATUS, PROCESSO.*  from PROCESSO
                INNER JOIN STATUS ON STATUS.ID_STATUS = PROCESSO.ID_STATUS
                INNER JOIN CIDADE ON CIDADE.ID_CIDADE = PROCESSO.ID_CIDADE
                INNER JOIN ESTADO ON ESTADO.ID_ESTADO = CIDADE.ID_ESTADO
            INNER JOIN PAIS ON PAIS.ID_PAIS = ESTADO.ID_PAIS", connection);

            dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable data = new DataTable();
            dataAdapter.Fill(data);
            Grd_Processos.DataSource = data;
        }

        private void Grd_Processos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = Grd_Processos.Rows[indexRow];
            id_Processo = Convert.ToInt32(row.Cells[4].Value);
            Txt_Cidade.Text = row.Cells[6].Value.ToString();
            Txt_Nome.Text = row.Cells[7].Value.ToString();
            Txt_Cpf.Text = row.Cells[8].Value.ToString();
            txt_Rg.Text = row.Cells[9].Value.ToString();
            Mtb_Nascimento.Text = row.Cells[10].Value.ToString();
            Txt_Email.Text = row.Cells[11].Value.ToString();
            txt_Cep.Text = row.Cells[12].Value.ToString();
            Txt_Rua.Text = row.Cells[13].Value.ToString();
            Txt_Numero.Text = row.Cells[14].Value.ToString();
            Txt_Complemento.Text = row.Cells[15].Value.ToString();
            Txt_Bairro.Text = row.Cells[16].Value.ToString();
            txt_Celular.Text = row.Cells[17].Value.ToString();
            tx_Sexo.Text = row.Cells[18].Value.ToString();
            Txt_Excluir.Text = row.Cells[4].Value.ToString();
        }
        /*Metodo para inserir um método*/
        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            if (Txt_Cidade.Text != "" && Txt_Nome.Text != "" && Txt_Cpf.Text != "" && txt_Rg.Text != "")
            {
                try
                {

                    sqlCommand = new SqlCommand(@"INSERT INTO PROCESSO
                        VALUES(@STATUS, @CIDADE, @NOME, @CPF, @RG, @NASCIMENTO, @EMAIL, @CEP, 
                    @RUA, @NUMERO, @COMPLEMENTO, @BAIRRO, @CELULAR, @SEXO)", connection);

                    connection.Open();
                    sqlCommand.Parameters.AddWithValue("@STATUS", 5);
                    sqlCommand.Parameters.AddWithValue("@CIDADE", Cbx_Cidade.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@NOME", Txt_Nome.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@CPF", Txt_Cpf.Text);
                    sqlCommand.Parameters.AddWithValue("@RG", txt_Rg.Text);
                    sqlCommand.Parameters.AddWithValue("@NASCIMENTO", Mtb_Nascimento.Text);
                    sqlCommand.Parameters.AddWithValue("@EMAIL", Txt_Email.Text.ToLower());
                    sqlCommand.Parameters.AddWithValue("@CEP", txt_Cep.Text);
                    sqlCommand.Parameters.AddWithValue("@RUA", Txt_Rua.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@NUMERO", Txt_Numero.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@COMPLEMENTO", Txt_Complemento.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@BAIRRO", Txt_Bairro.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@CELULAR", txt_Celular.Text);
                    sqlCommand.Parameters.AddWithValue("@SEXO", tx_Sexo.Text.ToUpper());
                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Registro incluído com sucesso...");
                        autoTableUpdate();
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("Erro : " + exc.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Informe todos os dados requeridos");
            }
        }

        /*Metodo para atualizar algum processo existente */
        private void Btn_Atualizar_Click(object sender, EventArgs e)
        {
            if (Txt_Nome.Text != "" && Txt_Cpf.Text != "")
            {
                try
                {
                    sqlCommand = new SqlCommand(@"update PROCESSO set ID_STATUS = @Status, ID_CIDADE=@Cidade,
                        NOME = @Nome, CPF = @Cpf, RG = @Rg, NASCIMENTO = @Nascimento, EMAIL = @Email, CEP = @Cep, 
                        RUA = @Rua, NUMERO = @Numero, COMPLEMENTO = @Complemento, BAIRRO = @Bairro, CELULAR = @Celular, SEXO = @Sexo
                    where ID_PROCESSO = @id", connection);

                    sqlCommand.Parameters.AddWithValue("@Id", id_Processo);
                    sqlCommand.Parameters.AddWithValue("@Status", 5);
                    sqlCommand.Parameters.AddWithValue("@Cidade", Txt_Cidade.Text);
                    sqlCommand.Parameters.AddWithValue("@Nome", Txt_Nome.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@Cpf", Txt_Cpf.Text);                 
                    sqlCommand.Parameters.AddWithValue("@Rg", txt_Rg.Text);
                    sqlCommand.Parameters.AddWithValue("@Nascimento", Mtb_Nascimento.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", Txt_Email.Text.ToLower());
                    sqlCommand.Parameters.AddWithValue("@Cep", txt_Cep.Text);
                    sqlCommand.Parameters.AddWithValue("@Rua", Txt_Rua.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@Numero", Txt_Numero.Text);
                    sqlCommand.Parameters.AddWithValue("@Complemento", Txt_Complemento.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@Bairro", Txt_Bairro.Text.ToUpper());
                    sqlCommand.Parameters.AddWithValue("@Celular", txt_Celular.Text);
                    sqlCommand.Parameters.AddWithValue("@Sexo", tx_Sexo.Text.ToUpper());
                    connection.Open();

                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Processo atualizado com sucesso!");
                        autoTableUpdate();
                    }
                    else
                    {
                        throw new Exception(); ;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro: " + ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            
            else
            {
                MessageBox.Show("Selecione um processo para atualizar!");
            }
        }

        /* Metodo para a exclusão do processo */
        private void Btn_Excluir_Click(object sender, EventArgs e)
        {
            if (Txt_Excluir.Text != "")
            {
                try
                {
                    sqlCommand = new SqlCommand(@"delete PROCESSO WHERE ID_PROCESSO = @id", connection);
                    sqlCommand.Parameters.AddWithValue("@id", Txt_Excluir.Text);
                    connection.Open();
                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Processo excluido com sucesso!");
                        autoTableUpdate();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Falha na execução " + exc);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /*Metodo para limpar os campos dos compos */
        private void Btn_Novo_Click(object sender, EventArgs e)
        {
            Txt_Cidade.Text = "";
            Txt_Nome.Text = "";
            Txt_Cpf.Text = "";
            txt_Rg.Text = "";
            Mtb_Nascimento.Text = "";
            Txt_Email.Text = "";
            txt_Cep.Text = "";
            Txt_Rua.Text = "";
            Txt_Numero.Text = "";
            Txt_Complemento.Text = "";
            Txt_Bairro.Text = "";
            txt_Celular.Text = "";
            tx_Sexo.Text = "";
            
            autoTableUpdate();
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void Frm_Processo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /* Metodo para setar o nome do usuario que está logado */
        private void setNomeUsuario()
        {
            Txt_Nome_Usuario.Text = "";
            Txt_Nome_Usuario.Text = nome_Usuario;
        }

        /* ComboBox para adicionar país*/

        private void Cbx_Pais_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand = new SqlCommand(@"SELECT * FROM PAIS", connection);
                connection.Open();
                dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                Cbx_Pais.ValueMember = "ID_PAIS";
                Cbx_Pais.DisplayMember = "NOME";
                Cbx_Pais.DataSource = data;
                Cbx_Estado.Enabled = false;
                Cbx_Cidade.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro : " + exc);
            }
            finally
            {
                connection.Close();
            }
        }

        /* ComboBox para ver a alteração do ComboBox do país e mostrar as opções de estados */

        private void Cbx_Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Pais.SelectedValue != null)
                {
                    sqlCommand = new SqlCommand(@"SELECT * FROM ESTADO WHERE ID_PAIS = @ID_PAIS", connection);
                    sqlCommand.Parameters.AddWithValue("@ID_PAIS", Cbx_Pais.SelectedValue.ToString());
                    dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable data = new DataTable();
                    dataAdapter.Fill(data);
                    Cbx_Estado.ValueMember = ("ID_ESTADO");
                    Cbx_Estado.DisplayMember = ("NOME");
                    Cbx_Estado.DataSource = data;
                    Cbx_Estado.Enabled = true;
                    Cbx_Cidade.Enabled = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro : " + exc);
            }
            finally
            {
                connection.Close();
            }
        }

        /* ComboBox para ver a alteração do ComboBox do estado e mostrar as opções de cidades */

        private void Cbx_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(Cbx_Estado.SelectedValue != null)
                {
                    sqlCommand = new SqlCommand(@"SELECT * FROM CIDADE WHERE ID_ESTADO = @ID_ESTADO", connection);
                    sqlCommand.Parameters.AddWithValue("@ID_ESTADO", Cbx_Estado.SelectedValue.ToString());
                    dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable data = new DataTable();
                    dataAdapter.Fill(data);
                    Cbx_Cidade.ValueMember = ("ID_CIDADE");
                    Cbx_Cidade.DisplayMember = ("NOME");
                    Cbx_Cidade.DataSource = data;
                    Cbx_Cidade.Enabled = true;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Erro : " + exc);
            }
            finally
            {
                connection.Close();
            }
        }

        /*ComboBox para ver a alteração dos dados e colocar o valor do item no Txt_Cidade */

        private void Cbx_Cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Cidade.SelectedValue != null)
            {
                Txt_Cidade.Text = Cbx_Cidade.SelectedValue.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
