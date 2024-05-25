using Newtonsoft.Json;
using System;

namespace Projeto_Brigadeiro.Entities
{
    internal class Receita
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("tempoDePreparo")]
        public DateTime TempoDePreparo { get; set; }

        [JsonProperty("preco")]
        public decimal Preco { get; set; }

        [JsonProperty("rendimento")]
        public int Rendimento { get; set; }

        [JsonProperty("precoUnitario")]
        public decimal PrecoUnitario { get; set; }

        public Receita( string nome, DateTime tempoDePreparo, decimal preco, int rendimento, decimal precoUnitario )
        {
            this.Nome = nome;
            this.TempoDePreparo = tempoDePreparo;
            this.Preco = preco;
            this.Rendimento = rendimento;
            this.PrecoUnitario = precoUnitario;
        }
    }
}
