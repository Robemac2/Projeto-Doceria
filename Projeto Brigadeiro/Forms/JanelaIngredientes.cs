using Newtonsoft.Json;
using Projeto_Brigadeiro.Class;
using Projeto_Brigadeiro.Entities;
using Projeto_Brigadeiro.Enums;
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
    public partial class JanelaIngredientes : Form
    {
        public static string IngredienteHistoricoId;
        public static string IngredienteHistoricoNome;
        private static List<Ingrediente> ListaIngredientes = new List<Ingrediente>();
        private static List<Ingrediente> ListaOrdenada;
        public JanelaIngredientes()
        {
            InitializeComponent();
        }

        private void JanelaIngredientes_Load( object sender, EventArgs e )
        {
            lblIngrediente.Parent = imgFundo;
            lblIngrediente.BackColor = Color.Transparent;
            lblQuantidade.Parent = imgFundo;
            lblQuantidade.BackColor = Color.Transparent;
            lblUnidade.Parent = imgFundo;
            lblUnidade.BackColor = Color.Transparent;
            lblPreco.Parent = imgFundo;
            lblPreco.BackColor = Color.Transparent;
            lblData.Parent = imgFundo;
            lblData.BackColor = Color.Transparent;
            lblPesquisar.Parent = imgFundo;
            lblPesquisar.BackColor = Color.Transparent;

            comboUnidade.DataSource = Enum.GetValues(typeof(Unidade));
            dataView.DataSource = new BindingSource(ListaOrdenada, "");
            ListaIngredientes.Clear();

            Limpar();
            ListarTabela();
        }

        private void Limpar()
        {
            txtPesquisar.Text = "";
            txtIngrediente.Text = "";
            comboUnidade.SelectedIndex = 0;
            txtPreco.Text = "R$ " + 0.ToString("N2");
            txtQuantidade.Text = 0.ToString("N0");
            dataPicker.Value = DateTime.Now;
        }

        private void UpdateDataView( List<Ingrediente> lista )
        {
            ListaOrdenada = new List<Ingrediente>(lista.OrderBy(x => x.Nome));
            this.dataView.DataSource = typeof(Ingrediente);
            this.dataView.DataSource = ListaOrdenada;
            this.dataView.Refresh();
            this.dataView.Columns["Id"].Visible = false;
        }

        private async void ListarTabela()
        {
            try
            {
                var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"ingrediente", HttpCompletionOption.ResponseContentRead));

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                    var ingredientes = (JsonConvert.DeserializeObject<List<Ingrediente>>(retorno.Result));
                    ListaIngredientes.AddRange(ingredientes);

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
                UpdateDataView(ListaIngredientes);
                Limpar();
            }
        }

        private void TxtQuantidade_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( char.IsDigit(e.KeyChar) )
            {
                TextBox t = (TextBox)sender;
                t.SelectionStart = 0;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if ( t.Text.Length < 20 )
                {
                    t.Text = (decimal.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()))).ToString("N0");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
            }
            e.Handled = true;
        }

        private void TxtQuantidade_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Back )
            {
                TextBox t = (TextBox)sender;

                string Left = t.Text.Substring(0, t.Text.Length).Replace(".", "").Replace(",", "");

                if ( Left.Length > 1 )
                {
                    Left = Left.Remove(Left.Length - 1);
                    t.Text = (float.Parse(Left)).ToString("N0");
                }
                else
                {
                    t.Text = 0.ToString("N0");
                }
                e.Handled = true;
            }
        }

        private void TxtPreco_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( char.IsDigit(e.KeyChar) )
            {
                TextBox t = (TextBox)sender;
                t.Text = t.Text.Remove(0, 3);
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if ( t.Text.Length < 20 )
                {
                    t.Text = (float.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()).Replace(",", "").Replace(".", "")) / 100).ToString("N2");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                t.Text = "R$ " + t.Text;
            }
            e.Handled = true;
        }

        private void TxtPreco_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Back )
            {
                TextBox t = (TextBox)sender;
                t.Text = t.Text.Remove(0, 3);
                t.SelectionStart = t.Text.Length;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                string Left = t.Text.Substring(0, t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");
                string Right = t.Text.Substring(t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");

                if ( Left.Length > 0 )
                {
                    Left = Left.Remove(Left.Length - 1);
                    t.Text = (decimal.Parse(Left + Right) / 100).ToString("N2");
                    t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                    t.Text = "R$ " + t.Text;
                }
                e.Handled = true;
            }
        }

        private void BtnSalvar_Click( object sender, EventArgs e )
        {
            string ingredienteNome = txtIngrediente.Text;
            int ingredienteQuantidade = int.Parse(txtQuantidade.Text);
            Unidade ingredienteUnidade = (Unidade)comboUnidade.SelectedItem;
            decimal ingredientePreco = decimal.Parse(txtPreco.Text.Remove(0, 3));
            string ingredienteData = dataPicker.Value.Date.ToString("yyyy-MM-dd");

            if ( ingredienteNome == "" || ingredienteQuantidade == 0 || ingredientePreco == 0 )
            {
                MessageBox.Show("Todos os dados são de preenchimento obrigatório.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    Ingrediente ingrediente = new Ingrediente(ingredienteNome, ingredienteQuantidade, ingredienteUnidade, ingredientePreco, ingredienteData);

                    var consumeApi = ClientHttp.Client.PostAsJsonAsync<Ingrediente>("ingrediente", ingrediente);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        ListaIngredientes.Add(ingrediente);
                        UpdateDataView(ListaIngredientes);
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao inserir dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Limpar();
                }
            }
        }

        private void BtnAtualizar_Click( object sender, EventArgs e )
        {
            string ingredienteNome = txtIngrediente.Text;
            int ingredienteQuantidade = int.Parse(txtQuantidade.Text);
            Unidade ingredienteUnidade = (Unidade)comboUnidade.SelectedItem;
            decimal ingredientePreco = decimal.Parse(txtPreco.Text.Remove(0, 3));
            string ingredienteData = dataPicker.Value.Date.ToString("yyyy-MM-dd");

            if ( ingredienteNome == "" )
            {
                MessageBox.Show("Selecione um ingrediente para atualizar.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    Ingrediente ingrediente = ListaIngredientes.First(x => x.Nome == ingredienteNome);
                    Ingrediente ingredienteAtualizado = ingrediente;
                    ingredienteAtualizado.Quantidade = ingredienteQuantidade;
                    ingredienteAtualizado.Unidade = ingredienteUnidade;
                    ingredienteAtualizado.Preco = ingredientePreco;
                    ingredienteAtualizado.Data = ingredienteData;

                    var consumeApi = ClientHttp.Client.PutAsJsonAsync<Ingrediente>("ingrediente", ingredienteAtualizado);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        ListaIngredientes.Remove(ingrediente);
                        ListaIngredientes.Add(ingredienteAtualizado);
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao inserir dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    UpdateDataView(ListaIngredientes);
                    Limpar();
                }

            }
        }

        private void BtnExcluir_Click( object sender, EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Master" )
            {
                MessageBox.Show("Usuário não possui permissão para excluir dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string ingredienteNome = txtIngrediente.Text;

            if ( ingredienteNome == "" )
            {
                MessageBox.Show("Informe o ingrediente a ser excluido.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    Ingrediente ingrediente = ListaIngredientes.First(x => x.Nome == ingredienteNome);

                    var consumeApi = ClientHttp.Client.DeleteAsync("ingrediente/" + ingrediente.Id);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        ListaIngredientes.Remove(ingrediente);
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
                    UpdateDataView(ListaIngredientes);
                    Limpar();
                }
            }
        }

        private void BtnPesquisar_Click( object sender, EventArgs e )
        {
            string ingredienteNome = txtPesquisar.Text.ToLower();

            if ( ingredienteNome == "" )
            {
                MessageBox.Show("Informe o ingrediente a ser pesquisado.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    List<Ingrediente> listaPesquisa = new List<Ingrediente>();
                    listaPesquisa.AddRange(ListaIngredientes.Where(x => x.Nome.Contains(ingredienteNome)));

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

        private void BtnLimpar_Click( object sender, EventArgs e )
        {
            UpdateDataView(ListaIngredientes);
            Limpar();
        }

        private void DataView_SelectionChanged( object sender, EventArgs e )
        {
            if ( dataView.Focused )
            {
                txtIngrediente.Text = dataView.CurrentRow.Cells[1].Value.ToString();
                txtQuantidade.Text = dataView.CurrentRow.Cells[2].Value.ToString();
                comboUnidade.SelectedItem = (Unidade)dataView.CurrentRow.Cells[3].Value;
                txtPreco.Text = "R$ " + dataView.CurrentRow.Cells[4].Value.ToString();
                dataPicker.Value = DateTime.Parse(dataView.CurrentRow.Cells[5].Value.ToString());
            }
        }

        private void BtnVoltar_Click( object sender, EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private async void BtnHistorico_Click( object sender, EventArgs e )
        {
            if ( txtIngrediente.Text != string.Empty )
            {
                IngredienteHistoricoId = dataView.CurrentRow.Cells[0].Value.ToString();
                IngredienteHistoricoNome = dataView.CurrentRow.Cells[1].Value.ToString();

                try
                {
                    Ingrediente ingrediente = ListaIngredientes.First(x => x.Id == int.Parse(IngredienteHistoricoId));

                    var consumeApi = ClientHttp.Client.GetAsync($"historico-ingrediente/{ingrediente.Id}", HttpCompletionOption.ResponseContentRead);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                        var ingredientes = (JsonConvert.DeserializeObject<List<Ingrediente>>(retorno.Result));

                        if ( ingredientes.Count == 0 )
                        {
                            MessageBox.Show("Não existe histórico para o ingrediente selecionado.\n", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else
                    {
                        string erro = readData.StatusCode.ToString();

                        throw new Exception(erro);
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao acessar o banco de dados.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                finally
                {

                }

                Thread t = new Thread(() => Application.Run(new JanelaHistorico()));
                t.Start();
                Dispose();
                Close();
            }
        }
    }
}
