using Projeto_Brigadeiro.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaConfiguracoes : Form
    {
        public static String NomeUsuario = null;

        public JanelaConfiguracoes()
        {
            InitializeComponent();
        }

        private void JanelaConfiguracoes_Load(object sender, EventArgs e)
        {
            lblEnergia.Parent = imgFundo;
            lblEnergia.BackColor = Color.Transparent;
            lblEnergiaHora.Parent = imgFundo;
            lblEnergiaHora.BackColor = Color.Transparent;
            lblAgua.Parent = imgFundo;
            lblAgua.BackColor = Color.Transparent;
            lblAguaHora.Parent = imgFundo;
            lblAguaHora.BackColor = Color.Transparent;
            lblGas.Parent = imgFundo;
            lblGas.BackColor = Color.Transparent;
            lblGasHora.Parent = imgFundo;
            lblGasHora.BackColor = Color.Transparent;
            lblMaoDeObra.Parent = imgFundo;
            lblMaoDeObra.BackColor = Color.Transparent;
            lblSalario.Parent = imgFundo;
            lblSalario.BackColor = Color.Transparent;
            lblDias.Parent = imgFundo;
            lblDias.BackColor = Color.Transparent;
            lblHoras.Parent = imgFundo;
            lblHoras.BackColor = Color.Transparent;
            lblSalarioHora.Parent = imgFundo;
            lblSalarioHora.BackColor = Color.Transparent;
            lblGeral.Parent = imgFundo;
            lblGeral.BackColor = Color.Transparent;
            lblLucro.Parent = imgFundo;
            lblLucro.BackColor = Color.Transparent;

            ListarTabela();

            txtEnergia.Enabled = false;
            txtAgua.Enabled = false;
            txtGas.Enabled = false;
            txtSalario.Enabled = false;
            txtDias.Enabled = false;
            txtHoras.Enabled = false;
            txtGeral.Enabled = false;
            txtLucro.Enabled = false;

            ListarCusto();
        }

        private void ListarCusto()
        {
            Custo custo = Custo.CarregarCusto();

            txtEnergia.Text = "R$ " + custo.CustoEnergia.ToString("N2");
            txtAgua.Text = "R$ " + custo.CustoAgua.ToString("N2");
            txtGas.Text = "R$ " + custo.CustoGas.ToString("N2");
            txtSalario.Text = "R$ " + custo.CustoSalario.ToString("N2");
            txtDias.Text = custo.Dias.ToString("D2");
            txtHoras.Text = custo.Horas.Hour.ToString("D2");
            txtGeral.Text = custo.CustoGeral.ToString();
            txtLucro.Text = custo.Lucro.ToString();

            txtEnergiaHora.Text = "R$ " + Custo.CalcularCustoEnergia(custo.CustoEnergia).ToString("N2");
            txtAguaHora.Text = "R$ " + Custo.CalcularCustoAgua(custo.CustoAgua).ToString("N2");
            txtGasHora.Text = "R$ " + Custo.CalcularCustoGas(custo.CustoGas).ToString("N2");
            txtCusto.Text = "R$ " + Custo.CalcularCustoSalario(custo.Dias, int.Parse(custo.Horas.Hour.ToString()), custo.CustoSalario).ToString("N2");
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
                command.CommandText = "SELECT * FROM usuarios";

                DataTable ingredientes = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(ingredientes);

                command.Dispose();

                ingredientes.Columns.Remove("usuario_id");
                ingredientes.Columns.Remove("senha");

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
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            NomeUsuario = null;
            JanelaUsuario form = new JanelaUsuario();
            form.ShowDialog();
            dataView.Rows.Clear();
            ListarTabela();
        }

        private void BtnAlterarUsuario_Click(object sender, EventArgs e)
        {
            if (CadastroUsuario.UsuarioLogado.Tipo == "Usuario")
            {
                MessageBox.Show("Usuário não possui permissão para alterar dados.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            JanelaUsuario form = new JanelaUsuario();
            form.ShowDialog();
            dataView.Rows.Clear();
            ListarTabela();
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

            string usuarioNome = NomeUsuario;

            if (usuarioNome == "")
            {
                MessageBox.Show("Selecione o usuario para ser excluido.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "DELETE FROM usuarios WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", usuarioNome);

                    command.ExecuteNonQuery();

                    command.Dispose();

                    dataView.Rows.Clear();
                    ListarTabela();
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
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ListarCusto();

            txtEnergia.Enabled = false;
            txtAgua.Enabled = false;
            txtGas.Enabled = false;
            txtSalario.Enabled = false;
            txtDias.Enabled = false;
            txtHoras.Enabled = false;
            txtGeral.Enabled = false;
            txtLucro.Enabled = false;
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (CadastroUsuario.UsuarioLogado.Tipo != "Usuario")
            {
                txtEnergia.Enabled = true;
                txtAgua.Enabled = true;
                txtGas.Enabled = true;
                txtSalario.Enabled = true;
                txtDias.Enabled = true;
                txtHoras.Enabled = true;
                txtGeral.Enabled = true;
                txtLucro.Enabled = true;
            }
            else
            {
                MessageBox.Show("Usuário não possui permissão para atualizar dados.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtEnergia.Enabled == false)
            {
                return;
            }
            else
            {
                float custoEnergia = float.Parse(txtEnergia.Text.Remove(0, 3));
                float custoAgua = float.Parse(txtAgua.Text.Remove(0, 3));
                float custoGas = float.Parse(txtGas.Text.Remove(0, 3));
                float custoSalario = float.Parse(txtSalario.Text.Remove(0, 3));
                int dias = int.Parse(txtDias.Text);
                int horas = int.Parse(txtHoras.Text);
                DateTime dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horas, 0, 0);
                int custoGeral = int.Parse(txtGeral.Text);
                int lucro = int.Parse(txtLucro.Text);

                Custo custo = new Custo(custoEnergia, custoAgua, custoGas, custoSalario, dias, dateTime, custoGeral, lucro);

                Custo.SalvarCusto(custo);
            }

            ListarCusto();

            txtEnergia.Enabled = false;
            txtAgua.Enabled = false;
            txtGas.Enabled = false;
            txtSalario.Enabled = false;
            txtDias.Enabled = false;
            txtHoras.Enabled = false;
            txtGeral.Enabled = false;
            txtLucro.Enabled = false;
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            NomeUsuario = dataView.CurrentRow.Cells["nome"].Value.ToString();
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
