using Newtonsoft.Json;
using Projeto_Brigadeiro.Enums;

namespace Projeto_Brigadeiro.Entities
{
    internal class Receita_Ingrediente
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("receitaId")]
        public int ReceitaId { get; set; }

        [JsonProperty("IngredienteId")]
        public int IngredienteId { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        [JsonProperty("unidade")]
        public Unidade Unidade { get; set; }

        [JsonProperty("preco")]
        public decimal Preco { get; set; }

        public Receita_Ingrediente( int receitaId, int ingredienteId, int quantidade, Unidade unidade, decimal preco )
        {
            ReceitaId = receitaId;
            IngredienteId = ingredienteId;
            Quantidade = quantidade;
            Unidade = unidade;
            Preco = preco;
        }
    }
}