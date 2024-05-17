using Newtonsoft.Json;
using Projeto_Brigadeiro.Enums;

namespace Projeto_Brigadeiro.Entities
{
    internal class Ingrediente
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        [JsonProperty("unidade")]
        public Unidade Unidade { get; set; }

        [JsonProperty("preco")]
        public decimal Preco { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        public Ingrediente( string nome, int quantidade, Unidade unidade, decimal preco, string data )
        {
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Unidade = unidade;
            this.Preco = preco;
            this.Data = data;
        }
    }
}
