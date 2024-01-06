using Projeto_Brigadeiro.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    static class CadastroUsuario
    {
        private static Usuario _usuarioLogado = null;

        public static Usuario UsuarioLogado { get { return _usuarioLogado; } private set { _usuarioLogado = value; } }

        public static bool Login(string nome, string senha)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;

                command.CommandText = "SELECT * FROM usuarios WHERE nome= @nome AND senha= @senha";
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@senha", senha);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    command.CommandText = "SELECT * FROM usuarios WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", nome);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    string tipo = reader["tipo"].ToString();
                    reader.Close();

                    UsuarioLogado = new Usuario(nome, tipo);

                    return true;
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
            return false;
        }
    }
}
