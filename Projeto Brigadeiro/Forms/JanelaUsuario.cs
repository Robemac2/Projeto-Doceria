using Newtonsoft.Json;
using Projeto_Brigadeiro.Class;
using Projeto_Brigadeiro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaUsuario : Form
    {
        private static List<Usuario> ListaUsuarios = new List<Usuario>();
        public JanelaUsuario()
        {
            InitializeComponent();
        }

        private async void JanelaUsuario_Load( object sender, EventArgs e )
        {
            ListaUsuarios.Clear();
            comboTipo.DataSource = Enum.GetValues(typeof(TipoUsuario));

            if ( JanelaConfiguracoes.NomeUsuario != null )
            {
                switch ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() )
                {
                    case "Master":
                        txtUsuario.Enabled = false;
                        break;
                    case "Administrador":
                        txtUsuario.Enabled = false;
                        comboTipo.Enabled = false;
                        break;
                }

                try
                {
                    var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"usuario/listar", HttpCompletionOption.ResponseContentRead));

                    if ( consumeApi.Result.IsSuccessStatusCode )
                    {
                        var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                        var usuarios = (JsonConvert.DeserializeObject<List<Usuario>>(retorno.Result));
                        ListaUsuarios.AddRange(usuarios.Where(x => x.Nome == JanelaConfiguracoes.NomeUsuario));

                        if ( ListaUsuarios.Count > 0 )
                        {
                            txtUsuario.Text = ListaUsuarios[0].Nome.ToString();
                            txtSenha.Text = ListaUsuarios[0].Senha.ToString();
                            comboTipo.SelectedItem = ListaUsuarios[0].TipoUsuario;
                        }

                        return;
                    }

                    string erro = consumeApi.Result.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao selecionar usuário no banco de dados\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void BtnCancelar_Click( object sender, EventArgs e )
        {
            Dispose();
            Close();
        }

        private void BtnSalvar_Click( object sender, EventArgs e )
        {
            string usuarioNome = txtUsuario.Text;
            string usuarioSenha = txtSenha.Text;
            TipoUsuario usuarioTipo = (TipoUsuario)comboTipo.SelectedItem;

            if ( usuarioNome == "" || usuarioSenha == "" || comboTipo.Text == "" )
            {
                MessageBox.Show("Nome, senha e tipo de usuário obrigatórios.\n", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if ( JanelaConfiguracoes.NomeUsuario != null )
            {
                try
                {
                    Usuario usuario = ListaUsuarios.First(x => x.Nome == usuarioNome);
                    Usuario usuarioAtualizado = usuario;
                    usuarioAtualizado.Senha = usuarioSenha;
                    usuarioAtualizado.TipoUsuario = usuarioTipo;

                    if ( usuarioTipo.ToString() == "Master" )
                    {
                        if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Master" )
                        {
                            MessageBox.Show("Apenas usuários Master podem criar outros usuários Master.\n", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }

                    var consumeApi = ClientHttp.Client.PutAsJsonAsync<Usuario>("usuario", usuarioAtualizado);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao criar usuário no banco de dados\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Dispose();
                    Close();
                }
            }
            else
            {
                try
                {
                    Usuario usuario = new Usuario(usuarioNome, usuarioSenha, usuarioTipo);

                    if ( usuarioTipo.ToString() == "Master" )
                    {
                        if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Master" )
                        {
                            MessageBox.Show("Apenas usuários Master podem criar outros usuários Master.\n", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }

                    var consumeApi = ClientHttp.Client.PostAsJsonAsync<Usuario>("usuario", usuario);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao criar usuário no banco de dados\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Dispose();
                    Close();
                }
            }
        }

        private void CheckSenha_CheckedChanged( object sender, EventArgs e )
        {
            if ( CheckSenha.Checked == true )
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }
    }
}
