using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    static class CadastroUsuario
    {
        private static Usuario _usuarioLogado = null;

        public static Usuario UsuarioLogado { get { return _usuarioLogado; } private set { _usuarioLogado = value; } }

        public static bool Login( string nome, string senha )
        {
            try
            {
                Usuario usuario = new Usuario();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.68.12:8080/api/v1/");

                var consumeApi = client.GetAsync($"usuario/validar?nome={nome}&senha={senha}");
                consumeApi.Wait();

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    return true;
                }

                string erro = consumeApi.Result.StatusCode.ToString();

                throw new Exception(erro);
            }

            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao acessar o banco de dados\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            return false;
        }
    }
}
