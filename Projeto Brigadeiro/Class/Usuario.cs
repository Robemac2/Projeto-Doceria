using Projeto_Brigadeiro.Enums;

namespace Projeto_Brigadeiro
{
    class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

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
