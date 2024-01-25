using Projeto_Brigadeiro.Class;
using Projeto_Brigadeiro.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.CompilerServices;
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
            CheckPedidosEmAberto.Parent = imgFundo;
            CheckPedidosEmAberto.BackColor = Color.Transparent;

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

                dataView.Rows.Clear();

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

            this.dataView.Sort(this.dataView.Columns["pedido"], ListSortDirection.Ascending);
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

                dataView.Rows.Clear();

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

            this.dataView.Sort(this.dataView.Columns["pedido"], ListSortDirection.Ascending);
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
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaNovoPedido()));
            t.Start();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM pedidos WHERE pedido_id= @pedido_id";
                command.Parameters.AddWithValue("@pedido_id", _pedidoId);

                DataTable pedidos = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(pedidos);

                if (pedidos.Rows[0]["status"].ToString() == "Aberto")
                {
                    Dispose();
                    Close();
                    JanelaNovoPedido janelaNovoPedido = new JanelaNovoPedido();
                    janelaNovoPedido._ehAtualizacao = true;
                    janelaNovoPedido._pedidoId = _pedidoId;
                    Thread t = new Thread(() => Application.Run(janelaNovoPedido));
                    t.Start();
                }
                else
                {
                    MessageBox.Show("Pedido não esta Aberto.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (CadastroUsuario.UsuarioLogado.Tipo != "Master")
            {
                MessageBox.Show("Usuário não possui permissão para finalizar pedidos.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM pedidos WHERE pedido_id= @pedido_id";
                command.Parameters.AddWithValue("@pedido_id", _pedidoId);

                DataTable pedidos = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(pedidos);

                if (pedidos.Rows[0]["status"].ToString() == "Aberto")
                {
                    string pedidoStatus = "Finalizado";
                    command.CommandText = "UPDATE pedidos SET status= @status "
                                            + "WHERE pedido_id= @pedido_id";
                    command.Parameters.AddWithValue("@status", pedidoStatus);
                    command.Parameters.AddWithValue("@pedido_id", _pedidoId);

                    command.ExecuteNonQuery();

                    command.Dispose();

                    ListarTabela();
                }
                else
                {
                    MessageBox.Show("Pedido não esta Aberto.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (CadastroUsuario.UsuarioLogado.Tipo != "Master")
            {
                MessageBox.Show("Usuário não possui permissão para cancelar pedidos.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM pedidos WHERE pedido_id= @pedido_id";
                command.Parameters.AddWithValue("@pedido_id", _pedidoId);

                DataTable pedidos = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(pedidos);

                if (pedidos.Rows[0]["status"].ToString() == "Aberto")
                {
                    string pedidoStatus = "Cancelado";
                    command.CommandText = "UPDATE pedidos SET status= @status "
                                            + "WHERE pedido_id= @pedido_id";
                    command.Parameters.AddWithValue("@status", pedidoStatus);
                    command.Parameters.AddWithValue("@pedido_id", _pedidoId);

                    command.ExecuteNonQuery();

                    command.Dispose();

                    ListarTabela();
                }
                else
                {
                    MessageBox.Show("Pedido não esta Aberto.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
