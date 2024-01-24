using Projeto_Brigadeiro.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro.Forms
{
    public partial class JanelaNovoPedido : Form
    {
        public bool _ehAtualizacao = false;
        public int _pedidoId;
        public JanelaNovoPedido()
        {
            InitializeComponent();
        }

        private void JanelaNovoPedido_Load(object sender, EventArgs e)
        {
            lblProduto.Parent = imgFundo;
            lblProduto.BackColor = Color.Transparent;
            lblQuantidade.Parent = imgFundo;
            lblQuantidade.BackColor = Color.Transparent;
            lblCliente.Parent = imgFundo;
            lblCliente.BackColor = Color.Transparent;
            lblData.Parent = imgFundo;
            lblData.BackColor = Color.Transparent;
            lblTotal.Parent = imgFundo;
            lblTotal.BackColor = Color.Transparent;

            txtTotal.Text = "R$ " + 0.ToString("N2");
            ListarIngredientes();
            Limpar();
            AtualizarPedido();
        }

        private void AtualizarPedido()
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
                    command.CommandText = "SELECT * FROM pedidos_receitas WHERE pedido_id= @pedido_id";
                    command.Parameters.AddWithValue("@pedido_id", _pedidoId);

                    command.ExecuteNonQuery();

                    DataTable receitas = new DataTable();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    adapter.Fill(receitas);

                    command.Dispose();

                    con.Close();

                    for (int i = 0; i < receitas.Rows.Count; i++)
                    {
                        string baseDados2 = BaseDados.LocalBaseDados();
                        string strConection2 = BaseDados.StrConnection(baseDados2);

                        SQLiteConnection con2 = new SQLiteConnection(strConection2);

                        con2.Open();

                        SQLiteCommand command2 = new SQLiteCommand();
                        command2.Connection = con2;
                        command2.CommandText = "SELECT * FROM receitas WHERE receita_id= @receita_id";
                        command2.Parameters.AddWithValue("@receita_id", int.Parse(receitas.Rows[i]["receita_id"].ToString()));

                        command2.ExecuteNonQuery();

                        DataTable receitasNomes = new DataTable();
                        SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);

                        adapter2.Fill(receitasNomes);

                        command2.Dispose();

                        con2.Close();

                        dataView.Rows.Add();

                        dataView.Rows[i].Cells["produto"].Value = receitasNomes.Rows[0]["nome"].ToString();
                        dataView.Rows[i].Cells["quantidade"].Value = receitas.Rows[i]["quantidade"].ToString();
                        dataView.Rows[i].Cells["preco"].Value = receitas.Rows[i]["preco"].ToString();
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
                command.CommandText = "SELECT * FROM receitas ORDER BY nome";

                command.ExecuteNonQuery();

                DataTable receitas = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                adapter.Fill(receitas);

                command.Dispose();

                comboReceita.DataSource = receitas;
                comboReceita.DisplayMember = "nome";

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

        private void AtualizarDataGrid()
        {
            double total = 0;

            foreach (DataGridViewRow item in dataView.Rows)
            {
                total += double.Parse(item.Cells[2].Value.ToString().Remove(0, 3));
            }

            txtTotal.Text = "R$ " + total.ToString("N2");
        }

        private void Limpar()
        {
            comboReceita.SelectedIndex = 0;
            txtQuantidade.Text = string.Empty;
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaPedidos()));
            t.Start();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Você tem certexa que deseja remover o produto?\n\n" + dataView.CurrentRow.Cells["produto"].Value.ToString(), "SQLite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.No)
            {
                return;
            }

            dataView.Rows.RemoveAt(dataView.CurrentCell.RowIndex);

            Limpar();
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            string produto = comboReceita.Text;
            string quantidade = txtQuantidade.Text;
            string preco = BaseDados.PrecoProduto(produto, quantidade);

            if (preco != "Erro para calcular o preço do produto.")
            {
                bool produtoExiste = false;
                int index = -1;

                foreach (DataGridViewRow item in dataView.Rows)
                {
                    if (item.Cells[0].Value != null && item.Cells[0].Value.ToString() == produto)
                    {
                        produtoExiste = true;
                        index = item.Cells[0].RowIndex;
                        break;
                    }
                }

                if (produtoExiste)
                {
                    dataView.Rows.RemoveAt(index);
                }

                dataView.Rows.Add(produto, quantidade, preco);

                Limpar();
                AtualizarDataGrid();

                return;
            }

            MessageBox.Show("Erro ao calcular o preço do ingrediente.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count == 0)
            {
                MessageBox.Show("Erro ao salvar, o pedido precisa conter ao menos UM produto.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (txtCliente.Text == "")
            {
                MessageBox.Show("Erro ao salvar, o pedido precisa conter UM cliente.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string clienteNome = txtCliente.Text;
            string pedidoPreco = txtTotal.Text;
            string pedidoStatus = "Aberto";
            string pedidoData = dataPicker.Value.ToShortDateString();

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;

                if (_ehAtualizacao)
                {
                    command.CommandText = "UPDATE pedidos SET cliente= @cliente,"
                                            + "data= @data, total= @total, status= @status "
                                            + "WHERE pedido_id= @pedido_id";
                    command.Parameters.AddWithValue("@cliente", clienteNome);
                    command.Parameters.AddWithValue("@data", pedidoData);
                    command.Parameters.AddWithValue("@total", pedidoPreco);
                    command.Parameters.AddWithValue("@status", pedidoStatus);
                    command.Parameters.AddWithValue("@pedido_id", _pedidoId);
                }
                else
                {
                    command.CommandText = "INSERT INTO pedidos (cliente, data, total, status) "
                                        + "VALUES (@cliente, @data, @total, @status)";
                    command.Parameters.AddWithValue("@cliente", clienteNome);
                    command.Parameters.AddWithValue("@data", pedidoData);
                    command.Parameters.AddWithValue("@total", pedidoPreco);
                    command.Parameters.AddWithValue("@status", pedidoStatus);
                }

                command.ExecuteNonQuery();

                if (!_ehAtualizacao)
                {
                    command.CommandText = "SELECT COUNT(*) FROM pedidos";

                    _pedidoId = int.Parse(command.ExecuteScalar().ToString());
                }

                con.Close();

                foreach (DataGridViewRow row in dataView.Rows)
                {
                    string baseDados2 = BaseDados.LocalBaseDados();
                    string strConection2 = BaseDados.StrConnection(baseDados2);

                    SQLiteConnection con2 = new SQLiteConnection(strConection2);

                    SQLiteCommand command2 = new SQLiteCommand();
                    command2.Connection = con2;

                    con2.Open();

                    command2.CommandText = "SELECT * FROM receitas WHERE nome= @nome";
                    string receitaNome = row.Cells["produto"].Value.ToString();
                    command2.Parameters.AddWithValue("@nome", receitaNome);

                    DataTable pedido = new DataTable();
                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);

                    adapter2.Fill(pedido);

                    if (_ehAtualizacao)
                    {
                        command2.CommandText = "UPDATE pedidos_receitas SET pedido_id= @pedido_id, receita_id= @receita_id, quantidade= @quantidade, "
                                        + "preco= @preco WHERE pedido_id= @pedido_id AND receita_id= @receita_id";
                        command2.Parameters.AddWithValue("@pedido_id", _pedidoId);
                        command2.Parameters.AddWithValue("@receita_id", int.Parse(pedido.Rows[0]["rceita_id"].ToString()));
                        command2.Parameters.AddWithValue("@quantidade", int.Parse(row.Cells["quantidade"].Value.ToString()));
                        command2.Parameters.AddWithValue("@preco", row.Cells["preco"].Value.ToString());
                    }
                    else
                    {
                        command2.CommandText = "INSERT INTO pedidos_receitas (pedido_id, receita_id, quantidade, preco) "
                                        + "VALUES (@pedido_id, @receita_id, @quantidade, @preco)";
                        command2.Parameters.AddWithValue("@pedido_id", _pedidoId);
                        command2.Parameters.AddWithValue("@receita_id", int.Parse(pedido.Rows[0]["receita_id"].ToString()));
                        command2.Parameters.AddWithValue("@quantidade", int.Parse(row.Cells["quantidade"].Value.ToString()));
                        command2.Parameters.AddWithValue("@preco", row.Cells["preco"].Value.ToString());
                    }

                    command2.ExecuteNonQuery();

                    con2.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar pedido.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }

            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaPedidos()));
            t.Start();
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
    }
}
