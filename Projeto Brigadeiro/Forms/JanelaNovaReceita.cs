using Projeto_Brigadeiro.Class;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaNovaReceita : Form
    {
        private int _primeiraAtualizacaoHora = 0;
        private int _primeiraAtualizacaoMinuto = 0;
        private bool _ativarDataGrid = false;
        public int _receitaId;
        public bool _ehAtualizacao = false;

        public JanelaNovaReceita()
        {
            InitializeComponent();
        }

        private void JanelaNovaReceita_Load(object sender, EventArgs e)
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

            ListarIngredientes();
            AtualizarReceita();
            _ativarDataGrid = true;
            AtualizarDataGrid();
        }

        private void AtualizarReceita()
        {
            if (_ehAtualizacao)
            {
                string baseDados = BaseDados.LocalBaseDados();
                string strConection = BaseDados.StrConnection(baseDados);

                SQLiteConnection con = new SQLiteConnection(strConection);

                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "SELECT * FROM receitas_ingredientes WHERE receita_id= @receita_id";
                    command.Parameters.AddWithValue("@receita_id", _receitaId);

                    command.ExecuteNonQuery();

                    DataTable ingredientes = new DataTable();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    adapter.Fill(ingredientes);

                    command.Dispose();

                    con.Close();

                    string baseDados2 = BaseDados.LocalBaseDados();
                    string strConection2 = BaseDados.StrConnection(baseDados2);

                    SQLiteConnection con2 = new SQLiteConnection(strConection2);

                    con2.Open();

                    SQLiteCommand command2 = new SQLiteCommand();
                    command2.Connection = con2;
                    command2.CommandText = "SELECT * FROM receitas WHERE receita_id= @receita_id";
                    command2.Parameters.AddWithValue("@receita_id", _receitaId);

                    command2.ExecuteNonQuery();

                    DataTable ingredientes2 = new DataTable();
                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);

                    adapter2.Fill(ingredientes2);

                    command2.Dispose();

                    con2.Close();

                    _primeiraAtualizacaoHora = 1;
                    _primeiraAtualizacaoMinuto = 1;

                    txtReceita.Text = ingredientes2.Rows[0]["nome"].ToString();
                    txtHora.Text = ingredientes2.Rows[0]["tempoPreparoHora"].ToString();
                    txtMinuto.Text = ingredientes2.Rows[0]["tempoPreparoMinuto"].ToString();
                    txtRendimento.Text = ingredientes2.Rows[0]["rendimento"].ToString();
                    txtCusto.Text = ingredientes2.Rows[0]["preco"].ToString();

                    for (int i = 0; i < ingredientes.Rows.Count; i++)
                    {
                        string baseDados3 = BaseDados.LocalBaseDados();
                        string strConection3 = BaseDados.StrConnection(baseDados3);

                        SQLiteConnection con3 = new SQLiteConnection(strConection3);

                        con3.Open();

                        SQLiteCommand command3 = new SQLiteCommand();
                        command3.Connection = con3;
                        command3.CommandText = "SELECT * FROM ingredientes WHERE ingrediente_id= @ingrediente_id";
                        command3.Parameters.AddWithValue("@ingrediente_id", int.Parse(ingredientes.Rows[i]["ingrediente_id"].ToString()));

                        command3.ExecuteNonQuery();

                        DataTable ingredientes3 = new DataTable();
                        SQLiteDataAdapter adapter3 = new SQLiteDataAdapter(command3);

                        adapter3.Fill(ingredientes3);

                        command3.Dispose();

                        con3.Close();

                        dataView.Rows.Add();

                        dataView.Rows[i].Cells["ingrediente"].Value = ingredientes3.Rows[0]["nome"].ToString();
                        dataView.Rows[i].Cells["quantidade"].Value = ingredientes.Rows[i]["quantidade"].ToString();
                        dataView.Rows[i].Cells["unidade"].Value = ingredientes.Rows[i]["unidade"].ToString();
                        dataView.Rows[i].Cells["preco"].Value = ingredientes.Rows[i]["preco"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao consultar dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void AtualizarDataGrid()
        {
            if (dataView.Rows.Count > 0)
            {
                Custo custo = Custo.CarregarCusto();

                this.dataView.Sort(this.dataView.Columns["ingrediente"], ListSortDirection.Ascending);

                float soma = 0;
                float minuto = float.Parse(txtMinuto.Text) == 0f ? 0f : float.Parse(txtMinuto.Text) / 60f;
                float hora = float.Parse(txtHora.Text) + minuto;

                soma += Custo.CalcularCustoEnergia(custo.CustoEnergia) * hora;
                soma += Custo.CalcularCustoAgua(custo.CustoAgua) * hora;
                soma += Custo.CalcularCustoGas(custo.CustoGas) * hora;
                soma += Custo.CalcularCustoSalario(custo.Dias, int.Parse(custo.Horas.Hour.ToString()), custo.CustoSalario) * hora;

                foreach (DataGridViewRow item in dataView.Rows)
                {
                    soma += float.Parse(item.Cells["preco"].Value.ToString().Remove(0, 3));
                }

                soma *= Custo.CalcularCustoGeral(custo.CustoGeral);
                soma *= Custo.CalcularLucro(custo.Lucro);

                txtCusto.Text = "R$ " + float.Parse(soma.ToString("N2"));
            }
        }

        private void Limpar()
        {
            comboUnidade.SelectedIndex = 0;
            comboIngrediente.SelectedIndex = 0;
            txtQuantidade.Text = 0.ToString("N0");
            txtHora.Text = 0.ToString();
            txtMinuto.Text = 0.ToString();
        }

        private void ListarIngredientes()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientes ORDER BY nome";

                command.ExecuteNonQuery();

                DataTable ingredientes = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                adapter.Fill(ingredientes);

                command.Dispose();

                comboIngrediente.DataSource = ingredientes;
                comboIngrediente.DisplayMember = "nome";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
        }

        private void TxtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                TextBox t = (TextBox)sender;
                t.SelectionStart = 0;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if (t.Text.Length < 20)
                {
                    t.Text = (decimal.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()))).ToString("N0");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
            }
            e.Handled = true;
        }

        private void TxtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox t = (TextBox)sender;

                string Left = t.Text.Substring(0, t.Text.Length).Replace(".", "").Replace(",", "");

                if (Left.Length > 1)
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

        private void TxtRendimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                TextBox t = (TextBox)sender;
                t.SelectionStart = 0;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if (t.Text.Length < 20)
                {
                    t.Text = (decimal.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()))).ToString("N0");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
            }
            e.Handled = true;
        }

        private void TxtRendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox t = (TextBox)sender;

                string Left = t.Text.Substring(0, t.Text.Length).Replace(".", "").Replace(",", "");

                if (Left.Length > 1)
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

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Você tem certexa que deseja remover o ingredientes?\n\n" + dataView.CurrentRow.Cells["ingrediente"].Value.ToString(), "SQLite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.No)
            {
                return;
            }

            dataView.Rows.RemoveAt(dataView.CurrentCell.RowIndex);

            AtualizarDataGrid();
            Limpar();
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            string ingrediente = comboIngrediente.Text;
            string quantidade = txtQuantidade.Text;
            string unidade = comboUnidade.Text;
            string preco = BaseDados.PrecoIngrediente(ingrediente, quantidade, unidade);

            if (preco != "Conversão Indevida")
            {
                bool ingredienteExiste = false;
                int index = -1;

                foreach (DataGridViewRow item in dataView.Rows)
                {
                    if (item.Cells[0].Value != null && item.Cells[0].Value.ToString() == ingrediente)
                    {
                        ingredienteExiste = true;
                        index = item.Cells[0].RowIndex;
                        break;
                    }
                }

                if (ingredienteExiste)
                {
                    dataView.Rows.RemoveAt(index);
                }

                dataView.Rows.Add(ingrediente, quantidade, unidade, preco);

                Limpar();
                AtualizarDataGrid();

                return;
            }

            MessageBox.Show("Erro ao calcular o preço do ingrediente.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string receitaNome = txtReceita.Text;
            int receitaRendimento = int.Parse(txtRendimento.Text);
            string receitaPreco = txtCusto.Text;

            if (receitaNome == "" || receitaRendimento == 0 || receitaPreco == "R$ 0,00")
            {
                MessageBox.Show("Todos os dados são de preenchimento obrigatório.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;

                    if (_ehAtualizacao)
                    {
                        command.CommandText = "UPDATE receitas SET tempoPreparoHora= @tempoPreparoHora,"
                                              + "tempoPreparoMinuto= @tempoPreparoMinuto, preco= @preco, rendimento= @rendimento "
                                              + "WHERE nome= @nome";
                        command.Parameters.AddWithValue("@nome", receitaNome);
                        command.Parameters.AddWithValue("@tempoPreparoHora", txtHora.Text);
                        command.Parameters.AddWithValue("@tempoPreparoMinuto", txtMinuto.Text);
                        command.Parameters.AddWithValue("@preco", receitaPreco);
                        command.Parameters.AddWithValue("@rendimento", receitaRendimento);
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO receitas (nome, tempoPreparoHora, tempoPreparoMinuto, preco, rendimento) "
                                          + "VALUES (@nome, @tempoPreparoHora, @tempoPreparoMinuto, @preco, @rendimento)";
                        command.Parameters.AddWithValue("@nome", receitaNome);
                        command.Parameters.AddWithValue("@tempoPreparoHora", txtHora.Text);
                        command.Parameters.AddWithValue("@tempoPreparoMinuto", txtMinuto.Text);
                        command.Parameters.AddWithValue("@preco", receitaPreco);
                        command.Parameters.AddWithValue("@rendimento", receitaRendimento);
                    }

                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT * FROM receitas WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", receitaNome);

                    DataTable ingredientes = new DataTable();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    adapter.Fill(ingredientes);

                    int receitaId = int.Parse(ingredientes.Rows[0]["receita_id"].ToString());

                    con.Close();

                    foreach (DataGridViewRow row in dataView.Rows)
                    {
                        string baseDados2 = BaseDados.LocalBaseDados();
                        string strConection2 = BaseDados.StrConnection(baseDados);

                        SQLiteConnection con2 = new SQLiteConnection(strConection);

                        SQLiteCommand command2 = new SQLiteCommand();
                        command2.Connection = con2;

                        con2.Open();

                        command2.CommandText = "SELECT * FROM ingredientes WHERE nome= @nome";
                        string ingredienteNome = row.Cells["ingrediente"].Value.ToString();
                        command2.Parameters.AddWithValue("@nome", ingredienteNome);

                        DataTable ingredientes2 = new DataTable();
                        SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);

                        adapter2.Fill(ingredientes2);

                        if (_ehAtualizacao)
                        {
                            command2.CommandText = "UPDATE receitas_ingredientes SET quantidade= @quantidade, unidade= @unidade, preco= @preco "
                                          + "WHERE receita_id= @receita_id AND ingrediente_id= @ingrediente_id";
                            command2.Parameters.AddWithValue("@receita_id", receitaId);
                            command2.Parameters.AddWithValue("@ingrediente_id", int.Parse(ingredientes2.Rows[0]["ingrediente_id"].ToString()));
                            command2.Parameters.AddWithValue("@quantidade", int.Parse(row.Cells["quantidade"].Value.ToString()));
                            command2.Parameters.AddWithValue("@unidade", row.Cells["unidade"].Value.ToString());
                            command2.Parameters.AddWithValue("@preco", row.Cells["preco"].Value.ToString());
                        }
                        else
                        {
                            command2.CommandText = "INSERT INTO receitas_ingredientes (receita_id, ingrediente_id, quantidade, unidade, preco) "
                                          + "VALUES (@receita_id, @ingrediente_id, @quantidade, @unidade, @preco)";
                            command2.Parameters.AddWithValue("@receita_id", receitaId);
                            command2.Parameters.AddWithValue("@ingrediente_id", int.Parse(ingredientes2.Rows[0]["ingrediente_id"].ToString()));
                            command2.Parameters.AddWithValue("@quantidade", int.Parse(row.Cells["quantidade"].Value.ToString()));
                            command2.Parameters.AddWithValue("@unidade", row.Cells["unidade"].Value.ToString());
                            command2.Parameters.AddWithValue("@preco", row.Cells["preco"].Value.ToString());
                        }

                        command2.ExecuteNonQuery();

                        con2.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar receita.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }
            }

            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaReceitas()));
            t.Start();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaReceitas()));
            t.Start();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            if (_ativarDataGrid)
            {
                if (dataView.Rows.Count == 0)
                {
                    Limpar();
                    return;
                }
                comboIngrediente.SelectedIndex = comboIngrediente.FindStringExact(dataView.CurrentRow.Cells["ingrediente"].Value.ToString());
                txtQuantidade.Text = dataView.CurrentRow.Cells["quantidade"].Value.ToString();

                switch (dataView.CurrentRow.Cells["unidade"].Value.ToString())
                {
                    case "gramas":
                        comboUnidade.SelectedIndex = 0;
                        break;
                    case "Kilogramas":
                        comboUnidade.SelectedIndex = 1;
                        break;
                    case "mililitros":
                        comboUnidade.SelectedIndex = 2;
                        break;
                    case "Litros":
                        comboUnidade.SelectedIndex = 3;
                        break;
                    case "unidades":
                        comboUnidade.SelectedIndex = 4;
                        break;
                }
            }
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {
            if (_primeiraAtualizacaoHora == 0)
            {
                _primeiraAtualizacaoHora = 1;
                return;
            }

            AtualizarDataGrid();
        }

        private void txtMinuto_TextChanged(object sender, EventArgs e)
        {
            if (_primeiraAtualizacaoMinuto == 0)
            {
                _primeiraAtualizacaoMinuto = 1;
                return;
            }
            AtualizarDataGrid();
        }
    }
}
