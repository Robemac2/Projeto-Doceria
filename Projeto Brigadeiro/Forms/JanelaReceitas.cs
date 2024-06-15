using Newtonsoft.Json;
using Projeto_Brigadeiro.Class;
using Projeto_Brigadeiro.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaReceitas : Form
    {
        private string _receitaNome;
        private static List<Receita> ListaReceitas = new List<Receita>();
        private static List<Receita> ListaOrdenada;

        public JanelaReceitas()
        {
            InitializeComponent();
        }

        private void JanelaReceitas_Load( object sender, System.EventArgs e )
        {
            lblReceita.Parent = imgFundo;
            lblReceita.BackColor = Color.Transparent;

            ListaReceitas.Clear();
            ListarTabela();
            Limpar();
        }

        private async void ListarTabela()
        {
            try
            {
                var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"receita", HttpCompletionOption.ResponseContentRead));

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                    var receitas = (JsonConvert.DeserializeObject<List<Receita>>(retorno.Result));
                    ListaReceitas.AddRange(receitas);

                    return;
                }

                string erro = consumeApi.Result.StatusCode.ToString();

                throw new Exception(erro);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                UpdateDataView(ListaReceitas);
            }
        }

        private void Limpar()
        {
            txtPesquisar.Text = "";
        }

        private void UpdateDataView( List<Receita> lista )
        {
            ListaOrdenada = new List<Receita>(lista.OrderBy(x => x.Nome));
            this.dataView.DataSource = typeof(Receita);
            this.dataView.DataSource = ListaOrdenada;
            this.dataView.Refresh();
            this.dataView.Columns["Id"].Visible = false;
        }

        private void BtnPesquisar_Click( object sender, System.EventArgs e )
        {
            string receitaNome = txtPesquisar.Text.ToLower();

            if ( receitaNome == string.Empty )
            {
                MessageBox.Show("Informe a receita a ser pesquisada.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    List<Receita> listaPesquisa = new List<Receita>();
                    listaPesquisa.AddRange(ListaReceitas.Where(x => x.Nome.Contains(receitaNome)));

                    UpdateDataView(listaPesquisa);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao consultar dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Limpar();
                }
            }
        }

        private void BtnLimpar_Click( object sender, System.EventArgs e )
        {
            UpdateDataView(ListaReceitas);
            Limpar();
        }

        private void BtnNovaReceita_Click( object sender, System.EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaNovaReceita()));
            t.Start();
        }

        private void BtnExcluir_Click( object sender, System.EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Master" )
            {
                MessageBox.Show("Usuário não possui permissão para excluir dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string receitaNome = _receitaNome;

            if ( receitaNome == string.Empty )
            {
                MessageBox.Show("Informe a receita a ser excluída.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    Receita receita = ListaReceitas.First(x => x.Nome == receitaNome);

                    var consumeApi = ClientHttp.Client.DeleteAsync("receita/" + receita.Id);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        ListaReceitas.Remove(receita);
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao excluir dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    UpdateDataView(ListaReceitas);
                    Limpar();
                }
            }
        }

        private void BtnVoltar_Click( object sender, System.EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private void BtnAtualizar_Click( object sender, EventArgs e )
        {
            try
            {
                if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() == "Usuario" )
                {
                    MessageBox.Show("Usuário não possui permissão para atualizar dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if ( _receitaNome == string.Empty )
                {
                    MessageBox.Show("Informe a receita a ser atualizada.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                JanelaNovaReceita janelaNovaReceita = new JanelaNovaReceita();
                janelaNovaReceita._ehAtualizacao = true;
                janelaNovaReceita._receitaId = int.Parse(dataView.CurrentRow.Cells[0].Value.ToString());

                Thread t = new Thread(() => Application.Run(janelaNovaReceita));
                t.Start();
                Dispose();
                Close();
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao atualizar dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataView_SelectionChanged( object sender, EventArgs e )
        {
            if ( dataView.Focused )
            {
                _receitaNome = dataView.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
