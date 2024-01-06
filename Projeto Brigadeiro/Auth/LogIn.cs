using Projeto_Brigadeiro.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            lblLogIn.Parent = imgFundo;
            lblLogIn.BackColor = Color.Transparent;
            lblUsuario.Parent = imgFundo;
            lblUsuario.BackColor = Color.Transparent;
            lblSenha.Parent = imgFundo;
            lblSenha.BackColor = Color.Transparent;
            CheckSenha.Parent = imgFundo;
            CheckSenha.BackColor = Color.Transparent;

            int DbExiste = VerifyDb();

            if (DbExiste == 0)
            {
                CreateDb();
                CreateTables();
            }

            VerifyUsers();
            Custo.CriarCusto();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            if (CadastroUsuario.Login(usuario, senha))
            {
                Dispose();
                Close();
                Thread t = new Thread(() => Application.Run(new JanelaInicio()));
                t.Start();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Incorretos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Text = "";
                txtUsuario.Text = "";
                txtUsuario.Focus();
            }
        }

        private int VerifyDb()
        {
            int DbExiste = 0;
            string baseDados = BaseDados.LocalBaseDados();

            if (File.Exists(baseDados))
            {
                DbExiste = 1;
            }
            return DbExiste;
        }

        private void CreateDb()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            if (!File.Exists(baseDados))
            {
                SQLiteConnection.CreateFile(baseDados);
            }

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void CreateTables()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "CREATE TABLE usuarios ( usuario_id INTEGER NOT NULL UNIQUE, nome TEXT NOT NULL UNIQUE,"
                                        + "senha TEXT NOT NULL, tipo TEXT NOT NULL, PRIMARY KEY( usuario_id AUTOINCREMENT ))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE ingredientes ( ingrediente_id INTEGER NOT NULL UNIQUE, nome TEXT NOT NULL UNIQUE,"
                                        + "quantidade NUMERIC NOT NULL, unidade TEXT NOT NULL,"
                                        + "preco TEXT NOT NULL, data TEXT NOT NULL,"
                                        + "PRIMARY KEY( ingrediente_id AUTOINCREMENT ))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE ingredientesHistorico ( nome TEXT NOT NULL,"
                                        + "quantidade NUMERIC NOT NULL, unidade TEXT NOT NULL,"
                                        + "preco TEXT NOT NULL, data TEXT NOT NULL )";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE receitas ( receita_id INTEGER NOT NULL UNIQUE, nome TEXT NOT NULL UNIQUE,"
                                        + "tempoPreparoHora TEXT NOT NULL, tempoPreparoMinuto TEXT NOT NULL,"
                                        + "preco TEXT NOT NULL, rendimento INTEGER NOT NULL,"
                                        + "PRIMARY KEY( receita_id AUTOINCREMENT ))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE receitas_ingredientes ( receita_id INTEGER NOT NULL, ingrediente_id INTEGER NOT NULL,"
                                        + "quantidade NUMERIC NOT NULL, unidade TEXT NOT NULL, preco TEXT NOT NULL,"
                                        + "FOREIGN KEY( ingrediente_id ) REFERENCES ingredientes ( ingrediente_id ),"
                                        + "FOREIGN KEY( receita_id ) REFERENCES receitas ( receita_id ))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE pedidos ( pedido_id INTEGER NOT NULL UNIQUE, cliente TEXT NOT NULL,"
                                        + "total TEXT NOT NULL, data TEXT NOT NULL,"
                                        + "PRIMARY KEY( pedido_id AUTOINCREMENT))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE pedidos_receitas ( pedido_id INTEGER NOT NULL, receita_id INTEGER NOT NULL,"
                                        + "quantidade NUMERIC NOT NULL, preco TEXT NOT NULL,"
                                        + "FOREIGN KEY( receita_id ) REFERENCES receitas ( receita_id ),"
                                        + "FOREIGN KEY( pedido_id ) REFERENCES pedidos ( pedido_id ))";
                command.ExecuteNonQuery();

                command.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar tabelas no banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void VerifyUsers()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;

                command.CommandText = "SELECT * FROM usuarios";

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }

            UsuarioMaster form1 = new UsuarioMaster();
            form1.ShowDialog();
        }

        private void CheckSenha_CheckStateChanged(object sender, EventArgs e)
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
