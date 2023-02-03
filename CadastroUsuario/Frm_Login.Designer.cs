namespace CadastroUsuario
{
    partial class Frm_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_CadastroCliente = new System.Windows.Forms.Label();
            this.Lbl_SubTitulo = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.Lbl_Senha = new System.Windows.Forms.Label();
            this.Btn_Entrar = new System.Windows.Forms.Button();
            this.Txt_Senha = new System.Windows.Forms.TextBox();
            this.Btn_Sair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_CadastroCliente
            // 
            this.Lbl_CadastroCliente.AutoSize = true;
            this.Lbl_CadastroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Lbl_CadastroCliente.Location = new System.Drawing.Point(97, 42);
            this.Lbl_CadastroCliente.Name = "Lbl_CadastroCliente";
            this.Lbl_CadastroCliente.Size = new System.Drawing.Size(178, 22);
            this.Lbl_CadastroCliente.TabIndex = 7;
            this.Lbl_CadastroCliente.Text = "Cadastro de Clientes";
            // 
            // Lbl_SubTitulo
            // 
            this.Lbl_SubTitulo.AutoSize = true;
            this.Lbl_SubTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Lbl_SubTitulo.Location = new System.Drawing.Point(160, 75);
            this.Lbl_SubTitulo.Name = "Lbl_SubTitulo";
            this.Lbl_SubTitulo.Size = new System.Drawing.Size(54, 22);
            this.Lbl_SubTitulo.TabIndex = 6;
            this.Lbl_SubTitulo.Text = "Login";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Lbl_Usuario.Location = new System.Drawing.Point(74, 144);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(59, 22);
            this.Lbl_Usuario.TabIndex = 5;
            this.Lbl_Usuario.Text = "Login:";
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Txt_Usuario.Location = new System.Drawing.Point(78, 187);
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(197, 27);
            this.Txt_Usuario.TabIndex = 0;
            // 
            // Lbl_Senha
            // 
            this.Lbl_Senha.AutoSize = true;
            this.Lbl_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Lbl_Senha.Location = new System.Drawing.Point(74, 232);
            this.Lbl_Senha.Name = "Lbl_Senha";
            this.Lbl_Senha.Size = new System.Drawing.Size(67, 22);
            this.Lbl_Senha.TabIndex = 4;
            this.Lbl_Senha.Text = "Senha:";
            // 
            // Btn_Entrar
            // 
            this.Btn_Entrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Entrar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_Entrar.Location = new System.Drawing.Point(78, 354);
            this.Btn_Entrar.Name = "Btn_Entrar";
            this.Btn_Entrar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Entrar.TabIndex = 2;
            this.Btn_Entrar.Text = "Entrar";
            this.Btn_Entrar.UseVisualStyleBackColor = false;
            this.Btn_Entrar.Click += new System.EventHandler(this.Btn_Entrar_Click);
            // 
            // Txt_Senha
            // 
            this.Txt_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Txt_Senha.Location = new System.Drawing.Point(78, 271);
            this.Txt_Senha.Name = "Txt_Senha";
            this.Txt_Senha.Size = new System.Drawing.Size(197, 27);
            this.Txt_Senha.TabIndex = 1;
            this.Txt_Senha.UseSystemPasswordChar = true;
            // 
            // Btn_Sair
            // 
            this.Btn_Sair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Sair.Location = new System.Drawing.Point(200, 354);
            this.Btn_Sair.Name = "Btn_Sair";
            this.Btn_Sair.Size = new System.Drawing.Size(75, 23);
            this.Btn_Sair.TabIndex = 3;
            this.Btn_Sair.Text = "Sair";
            this.Btn_Sair.UseVisualStyleBackColor = false;
            this.Btn_Sair.Click += new System.EventHandler(this.Btn_Sair_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 455);
            this.Controls.Add(this.Btn_Sair);
            this.Controls.Add(this.Txt_Senha);
            this.Controls.Add(this.Btn_Entrar);
            this.Controls.Add(this.Lbl_Senha);
            this.Controls.Add(this.Txt_Usuario);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.Lbl_SubTitulo);
            this.Controls.Add(this.Lbl_CadastroCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_CadastroCliente;
        private System.Windows.Forms.Label Lbl_SubTitulo;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.Label Lbl_Senha;
        private System.Windows.Forms.Button Btn_Entrar;
        private System.Windows.Forms.TextBox Txt_Senha;
        private System.Windows.Forms.Button Btn_Sair;
    }
}

