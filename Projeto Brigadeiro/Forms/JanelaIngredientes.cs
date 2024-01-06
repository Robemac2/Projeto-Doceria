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
    public partial class JanelaIngredientes : Form
    {
        public static string IngredienteHistorico;
        public JanelaIngredientes()
        {
            InitializeComponent();
        }

        private void JanelaIngredientes_Load(object sender, EventArgs e)
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

            ListarTabela();

            Limpar();
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

        private void ListarTabela()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientes";

                DataTable ingredientes = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(ingredientes);

                command.Dispose();

                ingredientes.Columns.Remove("ingrediente_id");

                foreach (DataRow ingrediente in ingredientes.Rows)
                {
                    dataView.Rows.Add(ingrediente.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }

            this.dataView.Sort(this.dataView.Columns["ingrediente"], ListSortDirection.Ascending);
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

        private void TxtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                TextBox t = (TextBox)sender;
                t.Text = t.Text.Remove(0, 3);
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if (t.Text.Length < 20)
                {
                    t.Text = (float.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()).Replace(",", "").Replace(".", "")) / 100).ToString("N2");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                t.Text = "R$ " + t.Text;
            }
            e.Handled = true;
        }

        private void TxtPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox t = (TextBox)sender;
                t.Text = t.Text.Remove(0, 3);
                t.SelectionStart = t.Text.Length;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                string Left = t.Text.Substring(0, t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");
                string Right = t.Text.Substring(t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");

                if (Left.Length > 0)
                {
                    Left = Left.Remove(Left.Length - 1);
                    t.Text = (decimal.Parse(Left + Right) / 100).ToString("N2");
                    t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                    t.Text = "R$ " + t.Text;
                }
                e.Handled = true;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string ingredienteNome = txtIngrediente.Text;
            int ingredienteQuantidade = int.Parse(txtQuantidade.Text);
            string ingredienteUnidade = comboUnidade.Text;
            string ingredientePreco = txtPreco.Text;
            string ingredienteData = dataPicker.Value.ToShortDateString();

            if (ingredienteNome == "" || ingredienteQuantidade == 0 || ingredientePreco == "R$ 0,00")
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
                    command.CommandText = "INSERT INTO ingredientes (nome, quantidade, unidade, preco, data) "
                                          + "VALUES (@nome, @quantidade, @unidade, @preco, @data)";
                    command.Parameters.AddWithValue("@nome", ingredienteNome);
                    command.Parameters.AddWithValue("@quantidade", ingredienteQuantidade);
                    command.Parameters.AddWithValue("@unidade", ingredienteUnidade);
                    command.Parameters.AddWithValue("@preco", ingredientePreco);
                    command.Parameters.AddWithValue("@data", ingredienteData);

                    command.ExecuteNonQuery();

                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }
            }

            dataView.Rows.Clear();
            ListarTabela();
            Limpar();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string ingredienteNome = txtIngrediente.Text;
            int ingredienteQuantidade = int.Parse(txtQuantidade.Text);
            string ingredienteUnidade = comboUnidade.Text;
            string ingredientePreco = txtPreco.Text;
            string ingredienteData = dataPicker.Value.ToShortDateString();

            if (ingredienteNome == "")
            {
                MessageBox.Show("Selecione um ingrediente para atualizar.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "SELECT * FROM ingredientes WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", ingredienteNome);

                    DataTable ingredientes = new DataTable();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    con.Open();

                    adapter.Fill(ingredientes);

                    command.CommandText = "INSERT INTO ingredientesHistorico (nome, quantidade, unidade, preco, data)"
                                          + "VALUES (@nome, @quantidade, @unidade, @preco, @data)";
                    command.Parameters.AddWithValue("@nome", ingredientes.Rows[0][1].ToString());
                    command.Parameters.AddWithValue("@quantidade", int.Parse(ingredientes.Rows[0][2].ToString()));
                    command.Parameters.AddWithValue("@unidade", ingredientes.Rows[0][3].ToString());
                    command.Parameters.AddWithValue("@preco", ingredientes.Rows[0][4].ToString());
                    command.Parameters.AddWithValue("@data", ingredientes.Rows[0][5].ToString());

                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE ingredientes SET quantidade= @quantidade,"
                                          + "unidade= @unidade, preco= @preco, data= @data WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", ingredienteNome);
                    command.Parameters.AddWithValue("@quantidade", ingredienteQuantidade);
                    command.Parameters.AddWithValue("@unidade", ingredienteUnidade);
                    command.Parameters.AddWithValue("@preco", ingredientePreco);
                    command.Parameters.AddWithValue("@data", ingredienteData);

                    command.ExecuteNonQuery();

                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }

            }
            dataView.Rows.Clear();
            ListarTabela();
            Limpar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (CadastroUsuario.UsuarioLogado.Tipo != "Master")
            {
                MessageBox.Show("Usuário não possui permissão para excluir dados.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string ingredienteNome = txtIngrediente.Text;

            if (ingredienteNome == "")
            {
                MessageBox.Show("Informe o ingrediente a ser excluido.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "DELETE FROM ingredientes WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", ingredienteNome);

                    command.ExecuteNonQuery();

                    command.Dispose();

                    dataView.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    con.Close();
                }
            }

            ListarTabela();
            Limpar();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string ingredienteNome = txtPesquisar.Text;

            if (ingredienteNome == "")
            {
                MessageBox.Show("Informe o ingrediente a ser pesquisado.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "SELECT * FROM ingredientes WHERE nome LIKE @nome";
                    command.Parameters.AddWithValue("@nome", "%" + ingredienteNome + "%");

                    command.ExecuteNonQuery();

                    DataTable ingredientes = new DataTable();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    adapter.Fill(ingredientes);

                    command.Dispose();

                    ingredientes.Columns.Remove("ingrediente_id");

                    dataView.Rows.Clear();

                    foreach (DataRow ingrediente in ingredientes.Rows)
                    {
                        dataView.Rows.Add(ingrediente.ItemArray);
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
            Limpar();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            dataView.Rows.Clear();
            ListarTabela();
            Limpar();
        }

        private void DataView_SelectionChanged(object sender, EventArgs e)
        {
            txtIngrediente.Text = dataView.CurrentRow.Cells["ingrediente"].Value.ToString();
            txtQuantidade.Text = dataView.CurrentRow.Cells["quantidade"].Value.ToString();
            txtPreco.Text = dataView.CurrentRow.Cells["preco"].Value.ToString();

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

            dataPicker.Value = DateTime.Parse(dataView.CurrentRow.Cells["data"].Value.ToString());
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private void BtnHistorico_Click(object sender, EventArgs e)
        {
            IngredienteHistorico = dataView.CurrentRow.Cells["ingrediente"].Value.ToString();

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientesHistorico WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", IngredienteHistorico);

                command.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                adapter.Fill(dt);

                command.Dispose();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nao Existe histórico para o ingrediente selecionado.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }

            Thread t = new Thread(() => Application.Run(new JanelaHistorico()));
            t.Start();
            Dispose();
            Close();
        }
    }
}
