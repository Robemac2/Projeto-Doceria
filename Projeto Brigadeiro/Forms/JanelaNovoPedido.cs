using Projeto_Brigadeiro.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {

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
    }
}
