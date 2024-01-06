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
    public partial class JanelaReceitas : Form
    {
        public JanelaReceitas()
        {
            InitializeComponent();
        }

        private void JanelaReceitas_Load(object sender, System.EventArgs e)
        {
            lblReceita.Parent = imgFundo;
            lblReceita.BackColor = Color.Transparent;

            ListarTabela();
            AtualizarPrecos();
            Limpar();
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
                command.CommandText = "SELECT * FROM receitas";

                DataTable ingredientes = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                con.Open();

                adapter.Fill(ingredientes);

                command.Dispose();

                ingredientes.Columns.Remove("receita_id");

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

            this.dataView.Sort(this.dataView.Columns["receita"], ListSortDirection.Ascending);
        }

        private void Limpar()
        {
            txtPesquisar.Text = "";
        }

        private void BtnPesquisar_Click(object sender, System.EventArgs e)
        {
            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string receitaNome = txtPesquisar.Text;

            if (receitaNome == "")
            {
                MessageBox.Show("Informe a receita a ser pesquisada.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "SELECT * FROM receitas WHERE nome LIKE @nome";
                    command.Parameters.AddWithValue("@nome", "%" + receitaNome + "%");

                    command.ExecuteNonQuery();

                    DataTable ingredientes = new DataTable();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    adapter.Fill(ingredientes);

                    command.Dispose();

                    ingredientes.Columns.Remove("receita_id");

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

        private void BtnLimpar_Click(object sender, System.EventArgs e)
        {
            dataView.Rows.Clear();
            ListarTabela();
            Limpar();
        }

        private void BtnNovaReceita_Click(object sender, System.EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaNovaReceita()));
            t.Start();
        }

        private void BtnExcluir_Click(object sender, System.EventArgs e)
        {
            if (CadastroUsuario.UsuarioLogado.Tipo != "Master")
            {
                MessageBox.Show("Usuário não possui permissão para excluir dados.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string baseDados = BaseDados.LocalBaseDados();
            string strConection = BaseDados.StrConnection(baseDados);

            SQLiteConnection con = new SQLiteConnection(strConection);

            string receitaNome = dataView.CurrentRow.Cells["receita"].Value.ToString();

            if (receitaNome == "")
            {
                MessageBox.Show("Informe a receita a ser excluída.", "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Você tem certexa que deseja excluir a receita?\n\n" + dataView.CurrentRow.Cells["receita"].Value.ToString(), "SQLite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (resultado == DialogResult.No)
                {
                    return;
                }
                try
                {
                    con.Open();

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = con;
                    command.CommandText = "DELETE FROM receitas WHERE nome= @nome";
                    command.Parameters.AddWithValue("@nome", receitaNome);

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

        private void BtnVoltar_Click(object sender, System.EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarPrecos();
        }

        private void AtualizarPrecos()
        {
            Custo custo = Custo.CarregarCusto();

            if (dataView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataView.Rows)
                {
                    try
                    {
                        float soma = 0;
                        float minuto = float.Parse(row.Cells["tempoPreparoMinuto"].Value.ToString()) == 0f ? 0f : float.Parse(row.Cells["tempoPreparoMinuto"].Value.ToString()) / 60f;
                        float hora = float.Parse(row.Cells["tempoPreparoHora"].Value.ToString()) + minuto;

                        soma += Custo.CalcularCustoEnergia(custo.CustoEnergia) * hora;
                        soma += Custo.CalcularCustoAgua(custo.CustoAgua) * hora;
                        soma += Custo.CalcularCustoGas(custo.CustoGas) * hora;
                        soma += Custo.CalcularCustoSalario(custo.Dias, int.Parse(custo.Horas.Hour.ToString()), custo.CustoSalario) * hora;

                        string receitaNome = row.Cells["receita"].Value.ToString();

                        #region receitaId

                        string baseDados = BaseDados.LocalBaseDados();
                        string strConection = BaseDados.StrConnection(baseDados);
                        SQLiteConnection con = new SQLiteConnection(strConection);

                        SQLiteCommand command = new SQLiteCommand();
                        command.Connection = con;
                        con.Open();

                        command.CommandText = "SELECT * FROM receitas WHERE nome= @nome";
                        command.Parameters.AddWithValue("@nome", receitaNome);

                        DataTable ingredientes = new DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                        adapter.Fill(ingredientes); // receita
                        con.Close();

                        #endregion

                        int receita_id = int.Parse(ingredientes.Rows[0]["receita_id"].ToString());

                        #region ingredientes_receitas lista de ingredientes

                        string baseDados2 = BaseDados.LocalBaseDados();
                        string strConection2 = BaseDados.StrConnection(baseDados2);
                        SQLiteConnection con2 = new SQLiteConnection(strConection2);

                        SQLiteCommand command2 = new SQLiteCommand();
                        command2.Connection = con2;
                        con2.Open();

                        command2.CommandText = "SELECT * FROM receitas_ingredientes WHERE receita_id= @receita_id";
                        command2.Parameters.AddWithValue("@receita_id", receita_id);

                        DataTable ingredientes2 = new DataTable();
                        SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);

                        adapter2.Fill(ingredientes2); //receita x ingrediente preco
                        con2.Close();

                        #endregion

                        #region atualizar cada ingrediente

                        int i = 0;

                        foreach (DataRow row1 in ingredientes2.Rows)
                        {
                            string baseDados3 = BaseDados.LocalBaseDados();
                            string strConection3 = BaseDados.StrConnection(baseDados3);
                            SQLiteConnection con3 = new SQLiteConnection(strConection3);

                            SQLiteCommand command3 = new SQLiteCommand();
                            command3.Connection = con3;
                            con3.Open();

                            command3.CommandText = "SELECT * FROM ingredientes WHERE ingrediente_id= @ingrediente_id";
                            command3.Parameters.AddWithValue("@ingrediente_id", int.Parse(ingredientes2.Rows[i]["ingrediente_id"].ToString()));

                            DataTable ingredientes3 = new DataTable();
                            SQLiteDataAdapter adapter3 = new SQLiteDataAdapter(command3);

                            adapter3.Fill(ingredientes3); //ingrediente
                            con3.Close();


                            float precoNovo = float.Parse(BaseDados.PrecoIngrediente(ingredientes3.Rows[0]["nome"].ToString(), ingredientes2.Rows[i]["quantidade"].ToString(), ingredientes2.Rows[i]["unidade"].ToString()).Remove(0, 3));

                            if (precoNovo != float.Parse(ingredientes2.Rows[i]["preco"].ToString().Remove(0, 3)))
                            {
                                string baseDados4 = BaseDados.LocalBaseDados();
                                string strConection4 = BaseDados.StrConnection(baseDados4);
                                SQLiteConnection con4 = new SQLiteConnection(strConection4);

                                SQLiteCommand command4 = new SQLiteCommand();
                                command4.Connection = con4;
                                con4.Open();

                                command4.CommandText = "UPDATE receitas_ingredientes SET preco= @preco WHERE ingrediente_id= @ingrediente_id";
                                command4.Parameters.AddWithValue("@ingrediente_id", int.Parse(ingredientes2.Rows[i]["ingrediente_id"].ToString()));
                                command4.Parameters.AddWithValue("@preco", "R$ " + precoNovo.ToString("N2"));

                                command4.ExecuteNonQuery();

                                con4.Close();

                                soma += precoNovo;
                            }
                            else
                            {
                                soma += precoNovo;
                            }
                            i++;
                        }

                        #endregion

                        soma *= Custo.CalcularCustoGeral(custo.CustoGeral);
                        soma *= Custo.CalcularLucro(custo.Lucro);

                        #region atualizar preco receita

                        if (soma != float.Parse(row.Cells["preco"].Value.ToString().Remove(0, 3)))
                        {
                            string baseDados5 = BaseDados.LocalBaseDados();
                            string strConection5 = BaseDados.StrConnection(baseDados5);
                            SQLiteConnection con5 = new SQLiteConnection(strConection5);

                            SQLiteCommand command5 = new SQLiteCommand();
                            command5.Connection = con5;
                            con5.Open();

                            command5.CommandText = "UPDATE receitas SET preco= @preco WHERE nome= @nome";
                            command5.Parameters.AddWithValue("@nome", receitaNome);
                            command5.Parameters.AddWithValue("@preco", "R$ " + soma.ToString("N2"));

                            command5.ExecuteNonQuery();

                            con5.Close();
                        }

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }
    }
}
