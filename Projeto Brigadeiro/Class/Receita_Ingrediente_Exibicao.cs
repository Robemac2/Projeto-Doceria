using Projeto_Brigadeiro.Enums;

namespace Projeto_Brigadeiro.Class
{
    internal class Receita_Ingrediente_Exibicao
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public Unidade Unidade { get; set; }
        public decimal Preco { get; set; }

        public Receita_Ingrediente_Exibicao( string nome, int quantidade, Unidade unidade, decimal preco )
        {
            Nome = nome;
            Quantidade = quantidade;
            Unidade = unidade;
            Preco = preco;
        }
    }
}
