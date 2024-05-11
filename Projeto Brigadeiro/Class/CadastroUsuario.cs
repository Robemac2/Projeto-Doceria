using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    static class CadastroUsuario
    {
        private static Usuario _usuarioLogado = null;

        public static Usuario UsuarioLogado { get { return _usuarioLogado; } private set { _usuarioLogado = value; } }

        public static async Task<bool> Login( string nome, string senha )
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.68.12:8080/api/v1/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var consumeApi = await Task.FromResult(client.GetAsync($"usuario/validar?nome={nome}&senha={senha}", HttpCompletionOption.ResponseContentRead));

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                    var usuario = JsonConvert.DeserializeObject<List<Usuario>>(retorno.Result);
                    UsuarioLogado = usuario[0];
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
