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
    public partial class JanelaNovaReceita : Form
    {
        private List<Ingrediente> ListaIngredientes = new List<Ingrediente>();
        private List<Receita_Ingrediente> receita_Ingredientes = new List<Receita_Ingrediente>(); // Lista que será salva no banco
        private List<Receita_Ingrediente_Exibicao> receita_Ingredientes_Exibicao = new List<Receita_Ingrediente_Exibicao>(); //Lista de ingredientes para exibição
        private static List<Receita_Ingrediente_Exibicao> ListaOrdenada;
        private static Custo custo = Custo.CarregarCusto();
        public int _receitaId;
        public bool _ehAtualizacao = false;

        public JanelaNovaReceita()
        {
            InitializeComponent();
        }

        private void JanelaNovaReceita_Load( object sender, EventArgs e )
        {
            lblIngrediente.Parent = imgFundo;
            lblIngrediente.BackColor = Color.Transparent;
            lblQuantidade.Parent = imgFundo;
            lblQuantidade.BackColor = Color.Transparent;
            lblUnidade.Parent = imgFundo;
            lblUnidade.BackColor = Color.Transparent;
            lblTempoPreparo.Parent = imgFundo;
            lblTempoPreparo.BackColor = Color.Transparent;
            lblRendimento.Parent = imgFundo;
            lblRendimento.BackColor = Color.Transparent;
            lblCusto.Parent = imgFundo;
            lblCusto.BackColor = Color.Transparent;
            lblNomeReceita.Parent = imgFundo;
            lblNomeReceita.BackColor = Color.Transparent;

            txtCusto.Text = "R$ " + 0.ToString("N2");
            txtHora.Text = 0.ToString();
            txtMinuto.Text = 0.ToString();

            comboUnidade.DataSource = Enum.GetValues(typeof(Unidade));

            ListaIngredientes.Clear();
            receita_Ingredientes.Clear();
            receita_Ingredientes_Exibicao.Clear();

            ListarIngredientes();
            comboIngrediente.DataSource = ListaIngredientes;
            comboIngrediente.DisplayMember = "nome";

            AtualizarReceita();
            AtualizarCusto();
        }

        private async void AtualizarReceita()
        {
            if ( _ehAtualizacao )
            {
                List<Receita> ListaReceitas = new List<Receita>();

                try
                {
                    var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"receita", HttpCompletionOption.ResponseContentRead));

                    if ( consumeApi.Result.IsSuccessStatusCode )
                    {
                        var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                        var receitas = (JsonConvert.DeserializeObject<List<Receita>>(retorno.Result));
                        ListaReceitas.AddRange(receitas);
                    }
                    else
                    {
                        string erro = consumeApi.Result.StatusCode.ToString();

                        throw new Exception(erro);
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao ler receitas da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                Receita receita = ListaReceitas.Find(x => x.Id == _receitaId);

                txtReceita.Text = receita.Nome;
                txtHora.Text = receita.TempoDePreparo.Substring(0, 2);
                txtMinuto.Text = receita.TempoDePreparo.Substring(3, 2);
                txtRendimento.Text = receita.Rendimento.ToString();

                try
                {
                    var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"receita-ingrediente/{receita.Id}", HttpCompletionOption.ResponseContentRead));

                    if ( consumeApi.Result.IsSuccessStatusCode )
                    {
                        var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                        var receitaIngredientes = (JsonConvert.DeserializeObject<List<Receita_Ingrediente>>(retorno.Result));
                        receita_Ingredientes.AddRange(receitaIngredientes);
                    }
                    else
                    {
                        string erro = consumeApi.Result.StatusCode.ToString();

                        throw new Exception(erro);
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao ler ingredientes da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                foreach ( Receita_Ingrediente ingrediente in receita_Ingredientes )
                {
                    Ingrediente ingredienteObj = ListaIngredientes.Find(x => x.Id == ingrediente.IngredienteId);
                    Receita_Ingrediente_Exibicao receita_Ingrediente_Exibicao = new Receita_Ingrediente_Exibicao(ingredienteObj.Nome, ingrediente.Quantidade, ingrediente.Unidade, ingrediente.Preco);
                    receita_Ingredientes_Exibicao.Add(receita_Ingrediente_Exibicao);
                }

                Limpar();
                UpdateDataView(receita_Ingredientes_Exibicao);
            }
        }

        private void UpdateDataView( List<Receita_Ingrediente_Exibicao> lista )
        {
            ListaOrdenada = new List<Receita_Ingrediente_Exibicao>(lista.OrderBy(x => x.Nome));
            this.dataView.DataSource = typeof(Receita_Ingrediente);
            this.dataView.DataSource = ListaOrdenada;
            this.dataView.Refresh();
            AtualizarCusto();
        }

        private void AtualizarCusto()
        {
            if ( dataView.Rows.Count > 0 )
            {
                decimal soma = 0;
                decimal minuto = decimal.Parse(txtMinuto.Text) == 0m ? 0m : decimal.Parse(txtMinuto.Text) / 60m;
                decimal hora = decimal.Parse(txtHora.Text) + minuto;

                soma += Custo.CalcularCustoEnergia(custo.CustoEnergia) * hora;
                soma += Custo.CalcularCustoAgua(custo.CustoAgua) * hora;
                soma += Custo.CalcularCustoGas(custo.CustoGas) * hora;
                soma += Custo.CalcularCustoSalario(custo.Dias, int.Parse(custo.Horas.Hour.ToString()), custo.CustoSalario) * hora;

                foreach ( Receita_Ingrediente_Exibicao ingrediente in receita_Ingredientes_Exibicao )
                {
                    soma += ingrediente.Preco;
                }

                soma *= Custo.CalcularCustoGeral(custo.CustoGeral);
                soma *= Custo.CalcularLucro(custo.Lucro);

                txtCusto.Text = "R$ " + decimal.Parse(soma.ToString("N2"));
            }
        }

        private void Limpar()
        {
            comboUnidade.SelectedIndex = 0;
            comboIngrediente.SelectedIndex = 0;
            txtQuantidade.Text = 0.ToString("N0");
        }

        private async void ListarIngredientes()
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
                MessageBox.Show("Erro ao consultar dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

        private void TxtRendimento_KeyPress( object sender, KeyPressEventArgs e )
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

        private void TxtRendimento_KeyDown( object sender, KeyEventArgs e )
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

        private void BtnRemover_Click( object sender, EventArgs e )
        {
            DialogResult resultado = MessageBox.Show("Você tem certexa que deseja remover o ingredientes?\n\n" + dataView.CurrentRow.Cells["nome"].Value.ToString(), "Projeto Brigadeiro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if ( resultado == DialogResult.No )
            {
                return;
            }

            receita_Ingredientes_Exibicao.Remove(receita_Ingredientes_Exibicao.Find(x => x.Nome == dataView.CurrentRow.Cells["nome"].Value.ToString()));
            int ingredienteId = ListaIngredientes.Find(x => x.Nome == dataView.CurrentRow.Cells["nome"].Value.ToString()).Id;
            receita_Ingredientes.Remove(receita_Ingredientes.Find(x => x.Id == ingredienteId));

            UpdateDataView(receita_Ingredientes_Exibicao);
            Limpar();
        }

        private void BtnAdicionar_Click( object sender, EventArgs e )
        {
            int quantidade = int.Parse(txtQuantidade.Text);

            if ( quantidade == 0 )
            {
                MessageBox.Show("Informe a quantidade do ingrediente.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string ingrediente = comboIngrediente.Text;
            Unidade unidade = (Unidade)comboUnidade.SelectedItem;
            decimal preco = PrecoIngrediente(ingrediente, quantidade, unidade);

            if ( preco < 0 )
            {
                MessageBox.Show("Erro ao calcular o preço do ingrediente.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Receita_Ingrediente_Exibicao receita_Ingrediente_Exibicao = new Receita_Ingrediente_Exibicao(ingrediente, quantidade, unidade, preco);
            receita_Ingredientes_Exibicao.Add(receita_Ingrediente_Exibicao);
            UpdateDataView(receita_Ingredientes_Exibicao);

            Limpar();
            AtualizarCusto();
        }

        private async void BtnSalvar_Click( object sender, EventArgs e )
        {
            if ( txtReceita.Text == string.Empty || txtHora.Text == string.Empty || txtMinuto.Text == string.Empty || txtRendimento.Text == string.Empty )
            {
                MessageBox.Show("Preencha todos os campos.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string receitaNome = txtReceita.Text;
            DateTime receitaTempoPreparo = new DateTime(1, 1, 1, int.Parse(txtHora.Text), int.Parse(txtMinuto.Text), 0);
            string receitaTempoPreparoString = receitaTempoPreparo.ToString("HH:mm:ss");
            int receitaRendimento = int.Parse(txtRendimento.Text);
            decimal receitaPreco = decimal.Parse(txtCusto.Text.Replace("R$ ", ""));
            decimal receitaPrecoUnitario = receitaPreco / receitaRendimento;

            Receita receita = new Receita(receitaNome, receitaTempoPreparoString, receitaPreco, receitaRendimento, receitaPrecoUnitario);

            if ( !_ehAtualizacao )
            {
                try
                {
                    var consumeApi = ClientHttp.Client.PostAsJsonAsync<Receita>("receita", receita);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( !readData.IsSuccessStatusCode )
                    {
                        string erro = readData.StatusCode.ToString();

                        throw new Exception(erro);
                    }

                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao salvar receita na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                try
                {
                    var consumeApi = ClientHttp.Client.PutAsJsonAsync<Receita>("receita", receita);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( !readData.IsSuccessStatusCode )
                    {
                        string erro = readData.StatusCode.ToString();

                        throw new Exception(erro);
                    }

                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao atualizar receita na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            List<Receita> ListaReceitas = new List<Receita>();

            try
            {
                var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"receita", HttpCompletionOption.ResponseContentRead));

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                    var receitas = (JsonConvert.DeserializeObject<List<Receita>>(retorno.Result));
                    ListaReceitas.AddRange(receitas);
                }
                else
                {
                    string erro = consumeApi.Result.StatusCode.ToString();

                    throw new Exception(erro);
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao ler receitas da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            int receitaId = ListaReceitas.Find(x => x.Nome == receitaNome).Id;

            foreach ( Receita_Ingrediente_Exibicao ingrediente in receita_Ingredientes_Exibicao )
            {
                Receita_Ingrediente receita_Ingrediente = new Receita_Ingrediente(receitaId, ListaIngredientes.Find(x => x.Nome == ingrediente.Nome).Id, ingrediente.Quantidade, ingrediente.Unidade, ingrediente.Preco);
                receita_Ingredientes.Add(receita_Ingrediente);
            }

            if ( _ehAtualizacao )
            {
                try
                {
                    var consumeApi = ClientHttp.Client.DeleteAsync("receitaingrediente/" + receita.Id);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( !readData.IsSuccessStatusCode )
                    {
                        string erro = readData.StatusCode.ToString();

                        throw new Exception(erro);
                    }

                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao deletar ingredientes antigos da receita.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            try
            {
                var consumeApi = ClientHttp.Client.PostAsJsonAsync<List<Receita_Ingrediente>>("receita-ingrediente", receita_Ingredientes);
                consumeApi.Wait();

                var readData = consumeApi.Result;

                if ( !readData.IsSuccessStatusCode )
                {
                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao salvar ingredientes da receita.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaReceitas()));
            t.Start();
        }

        private void BtnVoltar_Click( object sender, EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaReceitas()));
            t.Start();
        }

        private void BtnLimpar_Click( object sender, EventArgs e )
        {
            Limpar();
            AtualizarCusto();
        }

        private void dataView_SelectionChanged( object sender, EventArgs e )
        {
            if ( dataView.Focused )
            {
                comboIngrediente.SelectedIndex = comboIngrediente.FindStringExact(dataView.CurrentRow.Cells["nome"].Value.ToString());
                txtQuantidade.Text = dataView.CurrentRow.Cells["quantidade"].Value.ToString();
                comboUnidade.SelectedItem = (Unidade)dataView.CurrentRow.Cells["unidade"].Value;
            }
        }

        private decimal PrecoIngrediente( string nome, int quantidade, Unidade unidade )
        {
            decimal preco = -1;
            decimal precoIngrediente = ListaIngredientes.Find(x => x.Nome == nome).Preco / ListaIngredientes.Find(x => x.Nome == nome).Quantidade;
            Unidade unidadeIngrediente = ListaIngredientes.Find(x => x.Nome == nome).Unidade;

            if ( unidadeIngrediente == unidade )
            {
                preco = precoIngrediente * quantidade;
            }
            else if ( unidadeIngrediente == Unidade.gramas && unidade == Unidade.Kilogramas )
            {
                preco = precoIngrediente * quantidade / 1000;
            }
            else if ( unidadeIngrediente == Unidade.Kilogramas && unidade == Unidade.gramas )
            {
                preco = precoIngrediente * quantidade * 1000;
            }
            else if ( unidadeIngrediente == Unidade.mililitros && unidade == Unidade.Litros )
            {
                preco = precoIngrediente * quantidade / 1000;
            }
            else if ( unidadeIngrediente == Unidade.Litros && unidade == Unidade.mililitros )
            {
                preco = precoIngrediente * quantidade * 1000;
            }
            else if ( unidadeIngrediente == Unidade.Metros && unidade == Unidade.centimetros )
            {
                preco = precoIngrediente * quantidade * 100;
            }
            else if ( unidadeIngrediente == Unidade.centimetros && unidade == Unidade.Metros )
            {
                preco = precoIngrediente * quantidade / 100;
            }

            return decimal.Round(preco, 2);
        }
    }
}
