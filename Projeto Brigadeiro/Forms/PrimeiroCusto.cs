using System;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class PrimeiroCusto : Form
    {
        public PrimeiroCusto()
        {
            InitializeComponent();
        }

        private void PrimeiroCusto_Load(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            txtEnergia.Text = "R$ " + 0.ToString("N2");
            txtAgua.Text = "R$ " + 0.ToString("N2");
            txtGas.Text = "R$ " + 0.ToString("N2");
            txtSalario.Text = "R$ " + 0.ToString("N2");
            txtDias.Text = 0.ToString("D2");
            txtHoras.Text = 0.ToString("D2");
            txtGeral.Text = 0.ToString("D2");
            txtLucro.Text = 0.ToString("D2");
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtEnergia.Text == "" || txtAgua.Text == "" || txtGas.Text == "" || txtSalario.Text == "" || txtDias.Text == "" || txtHoras.Text == "" || txtGeral.Text == "" || txtLucro.Text == "")
            {
                MessageBox.Show("Todos os dados são obrigatórios.\n", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Limpar();
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
                float custoGeral = float.Parse(txtGeral.Text);
                float lucro = float.Parse(txtLucro.Text);

                Custo custo = new Custo(custoEnergia, custoAgua, custoGas, custoSalario, dias, dateTime, custoGeral, lucro);

                Custo.SalvarCusto(custo);

                Dispose();
                Close();
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
