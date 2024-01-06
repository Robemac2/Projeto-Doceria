using Projeto_Brigadeiro.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Projeto_Brigadeiro
{
    public partial class JanelaHistorico : Form
    {
        public JanelaHistorico()
        {
            InitializeComponent();
        }

        private void JanelaHistorico_Load(object sender, EventArgs e)
        {
            Font f = new Font("Gabriola", 20f, FontStyle.Bold);
            Font g = new Font("Gabriola", 16f, FontStyle.Italic);
            grafico.Font = f;
            grafico.Titles.Add("Histórico de Preços - " + JanelaIngredientes.IngredienteHistorico).Font = f;
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

            ListarTabela();
        }

        private void ListarTabela()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", JanelaIngredientes.IngredienteHistorico);

                DataTable temp = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(temp);

                command.Dispose();

                con.Close();

                temp.Columns.Remove("nome");
                temp.Columns.Remove("quantidade");
                temp.Columns.Remove("unidade");

                DataTable ingredientes = new DataTable();
                ingredientes.Columns.Add("preco");
                ingredientes.Columns.Add("data", typeof(DateTime));


                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    ingredientes.Rows.Add();
                    ingredientes.Rows[i].SetField("preco", temp.Rows[i][0].ToString());
                    ingredientes.Rows[i].SetField("data", DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")));
                }

                ingredientes.DefaultView.Sort = "data ASC";
                ingredientes = ingredientes.DefaultView.ToTable();

                grafico.DataSource = ingredientes;

                grafico.Series["Preço"].XValueMember = "data";
                grafico.Series["Preço"].IsXValueIndexed = true;
                grafico.Series["Preço"].YValueMembers = "preco";

                dataView.Columns["data"].DefaultCellStyle.Format = "dd/MM/yyyy";

                foreach (DataRow ingrediente in ingredientes.Rows)
                {
                    dataView.Rows.Add(ingrediente.ItemArray);
                }

                ingredientes.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaIngredientes()));
            t.Start();
        }

        private void BtnCompleto_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", JanelaIngredientes.IngredienteHistorico);

                DataTable temp = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(temp);

                command.Dispose();

                con.Close();

                temp.Columns.Remove("nome");
                temp.Columns.Remove("quantidade");
                temp.Columns.Remove("unidade");

                DataTable ingredientes = new DataTable();
                ingredientes.Columns.Add("preco");
                ingredientes.Columns.Add("data", typeof(DateTime));


                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    ingredientes.Rows.Add();
                    ingredientes.Rows[i].SetField("preco", temp.Rows[i][0].ToString());
                    ingredientes.Rows[i].SetField("data", DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")));
                }

                ingredientes.DefaultView.Sort = "data ASC";
                ingredientes = ingredientes.DefaultView.ToTable();

                grafico.DataSource = ingredientes;

                grafico.Series["Preço"].XValueMember = "data";
                grafico.Series["Preço"].IsXValueIndexed = true;
                grafico.Series["Preço"].YValueMembers = "preco";

                ingredientes.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnAno_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                DateTime ano = DateTime.Now;
                ano = ano.AddYears(-1);

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", JanelaIngredientes.IngredienteHistorico);

                DataTable temp = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(temp);

                command.Dispose();

                con.Close();

                temp.Columns.Remove("nome");
                temp.Columns.Remove("quantidade");
                temp.Columns.Remove("unidade");

                DataTable ingredientes = new DataTable();
                ingredientes.Columns.Add("preco");
                ingredientes.Columns.Add("data", typeof(DateTime));

                int j = 0;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (ano < DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")))
                    {
                        ingredientes.Rows.Add();
                        ingredientes.Rows[j].SetField("preco", temp.Rows[i][0].ToString());
                        ingredientes.Rows[j].SetField("data", DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")));
                        j++;
                    }
                }

                ingredientes.DefaultView.Sort = "data ASC";
                ingredientes = ingredientes.DefaultView.ToTable();

                grafico.DataSource = ingredientes;

                grafico.Series["Preço"].XValueMember = "data";
                grafico.Series["Preço"].IsXValueIndexed = true;
                grafico.Series["Preço"].YValueMembers = "preco";

                ingredientes.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnSemestre_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                DateTime semestre = DateTime.Now;
                semestre = semestre.AddMonths(-6);

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", JanelaIngredientes.IngredienteHistorico);

                DataTable temp = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(temp);

                command.Dispose();

                con.Close();

                temp.Columns.Remove("nome");
                temp.Columns.Remove("quantidade");
                temp.Columns.Remove("unidade");

                DataTable ingredientes = new DataTable();
                ingredientes.Columns.Add("preco");
                ingredientes.Columns.Add("data", typeof(DateTime));

                int j = 0;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (semestre < DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")))
                    {
                        ingredientes.Rows.Add();
                        ingredientes.Rows[j].SetField("preco", temp.Rows[i][0].ToString());
                        ingredientes.Rows[j].SetField("data", DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")));
                        j++;
                    }
                }

                ingredientes.DefaultView.Sort = "data ASC";
                ingredientes = ingredientes.DefaultView.ToTable();

                grafico.DataSource = ingredientes;

                grafico.Series["Preço"].XValueMember = "data";
                grafico.Series["Preço"].IsXValueIndexed = true;
                grafico.Series["Preço"].YValueMembers = "preco";

                ingredientes.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnTrimestre_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                DateTime trimestre = DateTime.Now;
                trimestre = trimestre.AddMonths(-3);

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", JanelaIngredientes.IngredienteHistorico);

                DataTable temp = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(temp);

                command.Dispose();

                con.Close();

                temp.Columns.Remove("nome");
                temp.Columns.Remove("quantidade");
                temp.Columns.Remove("unidade");

                DataTable ingredientes = new DataTable();
                ingredientes.Columns.Add("preco");
                ingredientes.Columns.Add("data", typeof(DateTime));

                int j = 0;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (trimestre < DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")))
                    {
                        ingredientes.Rows.Add();
                        ingredientes.Rows[j].SetField("preco", temp.Rows[i][0].ToString());
                        ingredientes.Rows[j].SetField("data", DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")));
                        j++;
                    }
                }

                ingredientes.DefaultView.Sort = "data ASC";
                ingredientes = ingredientes.DefaultView.ToTable();

                grafico.DataSource = ingredientes;

                grafico.Series["Preço"].XValueMember = "data";
                grafico.Series["Preço"].IsXValueIndexed = true;
                grafico.Series["Preço"].YValueMembers = "preco";

                ingredientes.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnMes_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                DateTime mes = DateTime.Now;
                mes = mes.AddMonths(-1);

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", JanelaIngredientes.IngredienteHistorico);

                DataTable temp = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(temp);

                command.Dispose();

                con.Close();

                temp.Columns.Remove("nome");
                temp.Columns.Remove("quantidade");
                temp.Columns.Remove("unidade");

                DataTable ingredientes = new DataTable();
                ingredientes.Columns.Add("preco");
                ingredientes.Columns.Add("data", typeof(DateTime));

                int j = 0;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (mes < DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")))
                    {
                        ingredientes.Rows.Add();
                        ingredientes.Rows[j].SetField("preco", temp.Rows[i][0].ToString());
                        ingredientes.Rows[j].SetField("data", DateTime.Parse(temp.Rows[i][1].ToString(), new CultureInfo("pt-BR")));
                        j++;
                    }
                }

                ingredientes.DefaultView.Sort = "data ASC";
                ingredientes = ingredientes.DefaultView.ToTable();

                grafico.DataSource = ingredientes;

                grafico.Series["Preço"].XValueMember = "data";
                grafico.Series["Preço"].IsXValueIndexed = true;
                grafico.Series["Preço"].YValueMembers = "preco";

                ingredientes.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
