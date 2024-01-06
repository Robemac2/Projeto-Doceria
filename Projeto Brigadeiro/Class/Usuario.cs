namespace Projeto_Brigadeiro
{
    class Usuario
    {

        public string Nome { get; }
        public string Tipo { get; }

        public Usuario(string nome, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }
    }
}
