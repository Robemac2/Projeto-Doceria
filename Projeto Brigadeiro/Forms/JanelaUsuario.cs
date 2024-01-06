using Projeto_Brigadeiro.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaUsuario : Form
    {
        public JanelaUsuario()
        {
            InitializeComponent();
        }

        private void JanelaUsuario_Load(object sender, EventArgs e)
        {
            if (JanelaConfiguracoes.NomeUsuario != null)
            {
                string baseDados = BaseDados.LocalBaseDados();
                string strConection = BaseDados.StrConnection(baseDados);

                SQLiteConnection con = new SQLiteConnection(strConection);

                switch (CadastroUsuario.UsuarioLogado.Tipo.ToString())
                {
                    case "Master":
                        txtUsuario.Enabled = false;
                        break;
                    case "Administrador":
                        txtUsuario.Enabled = false;
                        comboTipo.Enabled = false;
                        break;
                }

                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "SELECT * FROM usuarios WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", JanelaConfiguracoes.NomeUsuario);

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        txtUsuario.Text = reader["nome"].ToString();
                        txtSenha.Text = reader["senha"].ToString();
                        string tipo = reader["tipo"].ToString();

                        switch (tipo)
                        {
                            case "Administrador":
                                comboTipo.SelectedIndex = 0;
                                break;
                            case "Usuario":
                                comboTipo.SelectedIndex = 1;
                                break;
                        }
                        reader.Close();
                    }

                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao selecionar usuário no banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string usuarioNome = txtUsuario.Text;
            string usuarioSenha = txtSenha.Text;
            string usuarioTipo = comboTipo.Text;

            if (usuarioNome == "" || usuarioSenha == "" || comboTipo.Text == "")
            {
                MessageBox.Show("Nome, senha e tipo de usuario obrigatórios.\n", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            if (JanelaConfiguracoes.NomeUsuario != null)
            {
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;

                    command.CommandText = "UPDATE usuarios SET senha= @senha, tipo= @tipo WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", usuarioNome);
                    command.Parameters.AddWithValue("@senha", usuarioSenha);
                    command.Parameters.AddWithValue("@tipo", usuarioTipo);

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
            }
            else
            {
                try
                {
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "INSERT INTO usuarios (nome, senha, tipo) VALUES (@nome, @senha, @tipo)";
                    command.Parameters.AddWithValue("@nome", usuarioNome);
                    command.Parameters.AddWithValue("@senha", usuarioSenha);
                    command.Parameters.AddWithValue("@tipo", usuarioTipo);

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
