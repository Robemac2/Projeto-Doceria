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

            ListarIngredientes();
            Limpar();
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

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
