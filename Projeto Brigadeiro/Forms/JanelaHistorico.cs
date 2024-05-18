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
using System.Windows.Forms.DataVisualization.Charting;

namespace Projeto_Brigadeiro
{
    public partial class JanelaHistorico : Form
    {
        private static List<Ingrediente> ListaIngredientes = new List<Ingrediente>();
        private static List<Ingrediente> ListaOrdenada;

        public JanelaHistorico()
        {
            InitializeComponent();
        }

        private void JanelaHistorico_Load( object sender, EventArgs e )
        {
            Font f = new Font("Gabriola", 20f, FontStyle.Bold);
            Font g = new Font("Gabriola", 16f, FontStyle.Italic);
            grafico.Font = f;
            grafico.Titles.Add("Histórico de Preços - " + JanelaIngredientes.IngredienteHistoricoNome).Font = f;
            ChartArea chartArea = new ChartArea("Data X Preço");
            chartArea.AxisX.TitleFont = f;
            chartArea.AxisY.TitleFont = f;
            chartArea.AxisX.Title = "Data";
            chartArea.AxisX.LabelStyle.Font = g;
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.Title = "Preço";
            chartArea.AxisY.LabelStyle.Font = g;
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartArea.AxisY.MajorGrid.Enabled = false;
            grafico.Series["Preço"].IsValueShownAsLabel = true;
            grafico.Series["Preço"].LabelFormat = "R$ 0.00";
            grafico.Series["Preço"].IsVisibleInLegend = false;
            grafico.ChartAreas.Clear();
            grafico.ChartAreas.Add(chartArea);
            ListaIngredientes.Clear();

            BtnCompleto_Click(null, new EventArgs());
        }

        private void UpdateDataView( List<Ingrediente> lista )
        {
            ListaOrdenada = new List<Ingrediente>(lista.OrderByDescending(x => x.Data));
            this.dataView.DataSource = typeof(Ingrediente);
            this.dataView.DataSource = ListaOrdenada;
            this.dataView.Refresh();
            this.dataView.Columns["Id"].Visible = false;
            this.dataView.Columns["Nome"].Visible = false;
            this.dataView.Columns["Quantidade"].Visible = false;
            this.dataView.Columns["Unidade"].Visible = false;
        }

        private void UpdateChart( List<Ingrediente> lista )
        {
            DataTable dtIngredientes = new DataTable();
            dtIngredientes.Columns.Add("preco");
            dtIngredientes.Columns.Add("data", typeof(DateTime));

            for ( int i = 0; i < lista.Count; i++ )
            {
                dtIngredientes.Rows.Add();
                dtIngredientes.Rows[i].SetField("preco", "R$ " + lista[i].Preco.ToString());
                dtIngredientes.Rows[i].SetField("data", lista[i].Data.ToString());
            }

            dtIngredientes.DefaultView.Sort = "data ASC";
            dtIngredientes = dtIngredientes.DefaultView.ToTable();

            grafico.DataSource = dtIngredientes;

            grafico.Series["Preço"].XValueMember = "data";
            grafico.Series["Preço"].IsXValueIndexed = true;
            grafico.Series["Preço"].YValueMembers = "preco";
        }

        private async void SelecionarData( DateTime data )
        {
            try
            {
                var consumeApi = ClientHttp.Client.GetAsync($"historico-ingrediente/{JanelaIngredientes.IngredienteHistoricoId}", HttpCompletionOption.ResponseContentRead);
                consumeApi.Wait();

                var readData = consumeApi.Result;

                var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                var ingredientes = (JsonConvert.DeserializeObject<List<Ingrediente>>(retorno.Result));
                List<Ingrediente> ingredientesData = new List<Ingrediente>(ingredientes.Where(x => DateTime.Parse(x.Data) > data));
                ListaIngredientes.Clear();
                ListaIngredientes.AddRange(ingredientesData);

                UpdateChart(ListaIngredientes);
                UpdateDataView(ListaIngredientes);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnVoltar_Click( object sender, EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaIngredientes()));
            t.Start();
        }

        private void BtnCompleto_Click( object sender, EventArgs e )
        {
            DateTime data = DateTime.Now.AddYears(-100);
            SelecionarData(data);
        }

        private void BtnAno_Click( object sender, EventArgs e )
        {
            DateTime data = DateTime.Now.AddYears(-1);
            SelecionarData(data);
        }

        private void BtnSemestre_Click( object sender, EventArgs e )
        {
            DateTime data = DateTime.Now.AddMonths(-6);
            SelecionarData(data);
        }

        private void BtnTrimestre_Click( object sender, EventArgs e )
        {
            DateTime data = DateTime.Now.AddMonths(-3);
            SelecionarData(data);
        }

        private void BtnMes_Click( object sender, EventArgs e )
        {
            DateTime data = DateTime.Now.AddMonths(-1);
            SelecionarData(data);
        }
    }
}
