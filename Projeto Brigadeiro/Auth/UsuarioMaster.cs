using Projeto_Brigadeiro.Class;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class UsuarioMaster : Form
    {
        public UsuarioMaster()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string usuarioNome = txtUsuario.Text;
            string usuarioSenha = txtSenha.Text;

            if (usuarioNome == "" || usuarioSenha == "")
            {
                MessageBox.Show("Nome e senha obrigatórios.\n", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "INSERT INTO usuarios (nome, senha, tipo) VALUES (@nome, @senha, @tipo)";
                command.Parameters.AddWithValue("@nome", usuarioNome);
                command.Parameters.AddWithValue("@senha", usuarioSenha);
                command.Parameters.AddWithValue("@tipo", "Master");

                command.ExecuteNonQuery();

                command.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar usuário no banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
            Dispose();
            Close();
        }
        private void CheckSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }
    }
}
