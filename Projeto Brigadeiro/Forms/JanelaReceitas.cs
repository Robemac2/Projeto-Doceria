using Newtonsoft.Json;
using Projeto_Brigadeiro.Class;
using Projeto_Brigadeiro.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaReceitas : Form
    {
        private string _receitaNome;
        private static List<Receita> ListaReceitas = new List<Receita>();
        private static List<Receita> ListaOrdenada;

        public JanelaReceitas()
        {
            InitializeComponent();
        }

        private void JanelaReceitas_Load( object sender, System.EventArgs e )
        {
            lblReceita.Parent = imgFundo;
            lblReceita.BackColor = Color.Transparent;

            ListaReceitas.Clear();
            ListarTabela();
            AtualizarPrecos();
            Limpar();
        }

        private async void ListarTabela()
        {
            try
            {
                var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"receita", HttpCompletionOption.ResponseContentRead));

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                    var receitas = (JsonConvert.DeserializeObject<List<Receita>>(retorno.Result));
                    ListaReceitas.AddRange(receitas);

                    return;
                }

                string erro = consumeApi.Result.StatusCode.ToString();

                throw new Exception(erro);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                UpdateDataView(ListaReceitas);
            }
        }

        private void Limpar()
        {
            txtPesquisar.Text = "";
        }

        private void UpdateDataView( List<Receita> lista )
        {
            ListaOrdenada = new List<Receita>(lista.OrderBy(x => x.Nome));
            this.dataView.DataSource = typeof(Receita);
            this.dataView.DataSource = ListaOrdenada;
            this.dataView.Refresh();
            this.dataView.Columns["Id"].Visible = false;
        }

        private void BtnPesquisar_Click( object sender, System.EventArgs e )
        {
            string receitaNome = txtPesquisar.Text.ToLower();

            if ( receitaNome == string.Empty )
            {
                MessageBox.Show("Informe a receita a ser pesquisada.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    List<Receita> listaPesquisa = new List<Receita>();
                    listaPesquisa.AddRange(ListaReceitas.Where(x => x.Nome.Contains(receitaNome)));

                    UpdateDataView(listaPesquisa);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao consultar dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Limpar();
                }
            }
        }

        private void BtnLimpar_Click( object sender, System.EventArgs e )
        {
            UpdateDataView(ListaReceitas);
            Limpar();
        }

        private void BtnNovaReceita_Click( object sender, System.EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaNovaReceita()));
            t.Start();
        }

        private void BtnExcluir_Click( object sender, System.EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Master" )
            {
                MessageBox.Show("Usuário não possui permissão para excluir dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string receitaNome = _receitaNome;

            if ( receitaNome == string.Empty )
            {
                MessageBox.Show("Informe a receita a ser excluída.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    Receita receita = ListaReceitas.First(x => x.Nome == receitaNome);

                    var consumeApi = ClientHttp.Client.DeleteAsync("receita/" + receita.Id);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        ListaReceitas.Remove(receita);
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao excluir dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    UpdateDataView(ListaReceitas);
                    Limpar();
                }
            }
        }

        private void BtnVoltar_Click( object sender, System.EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private void BtnAtualizar_Click( object sender, EventArgs e )
        {
            try
            {
                JanelaNovaReceita janelaNovaReceita = new JanelaNovaReceita();
                janelaNovaReceita._ehAtualizacao = true;

                string baseDados = BaseDados.LocalBaseDados();
                string strConection = BaseDados.StrConnection(baseDados);
                SQLiteConnection con = new SQLiteConnection(strConection);

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                con.Open();

                command.CommandText = "SELECT * FROM receitas WHERE nome= @nome";
                command.Parameters.AddWithValue("@nome", _receitaNome);

                DataTable ingredientes = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                adapter.Fill(ingredientes);
                con.Close();

                janelaNovaReceita._receitaId = int.Parse(ingredientes.Rows[0]["receita_id"].ToString());

                Thread t = new Thread(() => Application.Run(janelaNovaReceita));
                t.Start();

                Dispose();
                Close();
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao atualizar dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void AtualizarPrecos()
        {
            Custo custo = Custo.CarregarCusto();

            if ( dataView.Rows.Count > 0 )
            {
                foreach ( DataGridViewRow row in dataView.Rows )
                {
                    try
                    {
                        decimal soma = 0m;
                        decimal minuto = decimal.Parse(row.Cells["tempoPreparoMinuto"].Value.ToString()) == 0m ? 0m : decimal.Parse(row.Cells["tempoPreparoMinuto"].Value.ToString()) / 60m;
                        decimal hora = decimal.Parse(row.Cells["tempoPreparoHora"].Value.ToString()) + minuto;

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

                        foreach ( DataRow row1 in ingredientes2.Rows )
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


                            decimal precoNovo = decimal.Parse(BaseDados.PrecoIngrediente(ingredientes3.Rows[0]["nome"].ToString(), ingredientes2.Rows[i]["quantidade"].ToString(), ingredientes2.Rows[i]["unidade"].ToString()).Remove(0, 3));

                            if ( precoNovo != decimal.Parse(ingredientes2.Rows[i]["preco"].ToString().Remove(0, 3)) )
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

                        if ( soma != decimal.Parse(row.Cells["preco"].Value.ToString().Remove(0, 3)) )
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
                    catch ( Exception ex )
                    {
                        MessageBox.Show("Erro ao atualizar dados na tabela.\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void dataView_SelectionChanged( object sender, EventArgs e )
        {
            if ( dataView.Focused )
            {
                _receitaNome = dataView.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
