using Newtonsoft.Json;
using Projeto_Brigadeiro.Class;
using Projeto_Brigadeiro.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaConfiguracoes : Form
    {
        public static String NomeUsuario = null;
        private static List<Usuario> ListaUsuarios = new List<Usuario>();
        private static List<Usuario> ListaOrdenada;

        public JanelaConfiguracoes()
        {
            InitializeComponent();
        }

        private void JanelaConfiguracoes_Load( object sender, EventArgs e )
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

            ListaUsuarios.Clear();
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

        private void UpdateDataView( List<Usuario> lista )
        {
            ListaOrdenada = new List<Usuario>(lista.OrderBy(x => x.Nome));
            this.dataView.DataSource = typeof(Ingrediente);
            this.dataView.DataSource = ListaOrdenada;
            this.dataView.Refresh();
            this.dataView.Columns["Id"].Visible = false;
            this.dataView.Columns["Senha"].Visible = false;
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

        private async void ListarTabela()
        {
            try
            {
                var consumeApi = await Task.FromResult(ClientHttp.Client.GetAsync($"usuario/listar", HttpCompletionOption.ResponseContentRead));

                if ( consumeApi.Result.IsSuccessStatusCode )
                {
                    var retorno = await Task.FromResult(consumeApi.Result.Content.ReadAsStringAsync());
                    var usuarios = (JsonConvert.DeserializeObject<List<Usuario>>(retorno.Result));
                    ListaUsuarios.AddRange(usuarios);
                    UpdateDataView(usuarios);
                    return;
                }

                string erro = consumeApi.Result.StatusCode.ToString();

                throw new Exception(erro);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Erro ao ler dados da tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnVoltar_Click( object sender, EventArgs e )
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaInicio()));
            t.Start();
        }

        private void BtnNovo_Click( object sender, EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() == "Usuario" )
            {
                MessageBox.Show("Usuário não possui permissão para alterar dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            NomeUsuario = null;
            JanelaUsuario form = new JanelaUsuario();
            form.ShowDialog();
            ListarTabela();
        }

        private void BtnAlterarUsuario_Click( object sender, EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() == "Usuario" )
            {
                MessageBox.Show("Usuário não possui permissão para alterar dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            JanelaUsuario form = new JanelaUsuario();
            form.ShowDialog();
            ListarTabela();
        }

        private void BtnExcluir_Click( object sender, EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Master" )
            {
                MessageBox.Show("Usuário não possui permissão para excluir dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string usuarioNome = NomeUsuario;

            if ( usuarioNome == "" )
            {
                MessageBox.Show("Selecione o usuário para ser excluido.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                try
                {
                    Usuario usuario = ListaUsuarios.First(x => x.Nome == usuarioNome);

                    var consumeApi = ClientHttp.Client.DeleteAsync("usuario/" + usuario.Id);
                    consumeApi.Wait();

                    var readData = consumeApi.Result;

                    if ( readData.IsSuccessStatusCode )
                    {
                        ListarTabela();
                        return;
                    }

                    string erro = readData.StatusCode.ToString();

                    throw new Exception(erro);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Erro ao excluir dados na tabela.\n" + ex, "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void BtnCancelar_Click( object sender, EventArgs e )
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

        private void BtnAtualizar_Click( object sender, EventArgs e )
        {
            if ( CadastroUsuario.UsuarioLogado.TipoUsuario.ToString() != "Usuario" )
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
                MessageBox.Show("Usuário não possui permissão para atualizar dados.", "Projeto Brigadeiro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnSalvar_Click( object sender, EventArgs e )
        {
            if ( txtEnergia.Enabled == false )
            {
                return;
            }
            else
            {
                decimal custoEnergia = decimal.Parse(txtEnergia.Text.Remove(0, 3));
                decimal custoAgua = decimal.Parse(txtAgua.Text.Remove(0, 3));
                decimal custoGas = decimal.Parse(txtGas.Text.Remove(0, 3));
                decimal custoSalario = decimal.Parse(txtSalario.Text.Remove(0, 3));
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

        private void dataView_SelectionChanged( object sender, EventArgs e )
        {
            if ( dataView.Focused )
            {
                NomeUsuario = dataView.CurrentRow.Cells["Nome"].Value.ToString();
            }
        }

        private void TxtPreco_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( char.IsDigit(e.KeyChar) )
            {
                TextBox t = (TextBox)sender;
                t.Text = t.Text.Remove(0, 3);
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if ( t.Text.Length < 20 )
                {
                    t.Text = (float.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()).Replace(",", "").Replace(".", "")) / 100).ToString("N2");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                t.Text = "R$ " + t.Text;
            }
            e.Handled = true;
        }

        private void TxtPreco_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Back )
            {
                TextBox t = (TextBox)sender;
                t.Text = t.Text.Remove(0, 3);
                t.SelectionStart = t.Text.Length;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                string Left = t.Text.Substring(0, t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");
                string Right = t.Text.Substring(t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");

                if ( Left.Length > 0 )
                {
                    Left = Left.Remove(Left.Length - 1);
                    t.Text = (decimal.Parse(Left + Right) / 100).ToString("N2");
                    t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                    t.Text = "R$ " + t.Text;
                }
                e.Handled = true;
            }
        }

        private void TxtQuantidade_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( char.IsDigit(e.KeyChar) )
            {
                TextBox t = (TextBox)sender;
                t.SelectionStart = 0;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                if ( t.Text.Length < 20 )
                {
                    t.Text = (decimal.Parse(t.Text.Insert(cursorPosition, e.KeyChar.ToString()))).ToString("N0");
                }

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
            }
            e.Handled = true;
        }

        private void TxtQuantidade_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Back )
            {
                TextBox t = (TextBox)sender;

                string Left = t.Text.Substring(0, t.Text.Length).Replace(".", "").Replace(",", "");

                if ( Left.Length > 1 )
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
