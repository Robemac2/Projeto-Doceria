using Newtonsoft.Json;
using Projeto_Brigadeiro.Enums;

namespace Projeto_Brigadeiro
{
    class Usuario
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("tipoUsuario")]
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario()
        {

        }
        public Usuario( string nome, string senha, TipoUsuario tipoUsuario )
        {
            this.Nome = nome;
            this.Senha = senha;
            this.TipoUsuario = tipoUsuario;
        }

        public Usuario( int id, string nome, string senha, TipoUsuario tipoUsuario )
        {
            this.Id = id;
            this.Nome = nome;
            this.Senha = senha;
            this.TipoUsuario = tipoUsuario;
        }
    }
}
