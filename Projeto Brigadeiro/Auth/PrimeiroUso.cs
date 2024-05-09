using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projeto_Brigadeiro.Auth
{
    public class PrimeiroUso
    {
        [JsonIgnore]
        public bool Configuracao { get; set; }

        public PrimeiroUso( bool configuracao )
        {
            this.Configuracao = configuracao;
        }

        public static void ChecarPrimeiroUso()
        {
            string nomeArquivo = "PrimeiroUso.json";

            if ( File.Exists("PrimeiroUso.json") )
            {
                string carregar = File.ReadAllText(nomeArquivo);
                PrimeiroUso primeiroUso = JsonSerializer.Deserialize<PrimeiroUso>(carregar);
                primeiroUso.Configuracao = false;
            }
            else
            {
                File.Create(@".\PrimeiroUso.json").Close();
                PrimeiroUso primeiroUso = new PrimeiroUso(true);
                string salvar = JsonSerializer.Serialize(primeiroUso);
                File.WriteAllText(nomeArquivo, salvar);
                UsuarioMaster form1 = new UsuarioMaster();
                form1.ShowDialog();
            }
        }
    }
}
