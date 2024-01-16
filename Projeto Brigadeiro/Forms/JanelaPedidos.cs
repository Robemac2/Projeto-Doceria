using Projeto_Brigadeiro.Class;
using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaPedidos : Form
    {
        private int _pedidoId;
        public JanelaPedidos()
        {
            InitializeComponent();
        }

        private void JanelaPedidos_Load(object sender, EventArgs e)
        {
            lblRelatorio.Parent = imgFundo;
            lblRelatorio.BackColor = Color.Transparent;

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
                command.CommandText = "SELECT * FROM pedidos";

                DataTable pedidos = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(pedidos);

                command.Dispose();

                foreach (DataRow pedido in pedidos.Rows)
                {
                    dataView.Rows.Add(pedido.ItemArray);
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

            this.dataView.Sort(this.dataView.Columns["pedido_id"], ListSortDirection.Ascending);
        }

        private void ListarTabelaEmAberto()
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);
            string status = "Aberto";

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM pedidos WHERE status= @status";
                command.Parameters.AddWithValue("status", status);

                DataTable pedidos = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(pedidos);

                command.Dispose();

                foreach (DataRow pedido in pedidos.Rows)
                {
                    dataView.Rows.Add(pedido.ItemArray);
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

            this.dataView.Sort(this.dataView.Columns["pedido_id"], ListSortDirection.Ascending);
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

        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void BtnData_Click(object sender, EventArgs e)
        {

        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {

        }

        private void BtnStatus_Click(object sender, EventArgs e)
        {

        }

        private void BtnCustomizado_Click(object sender, EventArgs e)
        {

        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            _pedidoId = int.Parse(dataView.CurrentRow.Cells["pedido"].Value.ToString());
        }

        private void CheckPedidosEmAberto_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPedidosEmAberto.Checked == true)
            {
                ListarTabelaEmAberto();
            }
            else
            {
                ListarTabela();
            }
        }
    }
}
