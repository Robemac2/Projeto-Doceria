using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class UsuarioMaster : Form
    {
        public UsuarioMaster()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click( object sender, EventArgs e )
        {
            string usuarioNome = txtUsuario.Text;
            string usuarioSenha = txtSenha.Text;

            if ( usuarioNome == "" || usuarioSenha == "" )
            {
                MessageBox.Show("Nome e senha obrigatórios.\n", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                Usuario usuario = new Usuario(usuarioNome, usuarioSenha, Enums.TipoUsuario.Master);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.68.12:8080/api/v1/");

                var consumeApi = client.PostAsJsonAsync<Usuario>("usuario", usuario);
                consumeApi.Wait();

                var readData = consumeApi.Result;

                if ( readData.IsSuccessStatusCode )
                {
                    return;
                }

                string erro = readData.StatusCode.ToString();

                throw new Exception(erro);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao criar usuário no banco de dados\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Dispose();
                Close();
            }
        }
        private void CheckSenha_CheckedChanged( object sender, EventArgs e )
        {
            if ( CheckSenha.Checked == true )
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
