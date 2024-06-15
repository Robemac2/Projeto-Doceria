using Projeto_Brigadeiro.Auth;
using Projeto_Brigadeiro.Class;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load( object sender, EventArgs e )
        {
            lblLogIn.Parent = imgFundo;
            lblLogIn.BackColor = Color.Transparent;
            lblUsuario.Parent = imgFundo;
            lblUsuario.BackColor = Color.Transparent;
            lblSenha.Parent = imgFundo;
            lblSenha.BackColor = Color.Transparent;
            CheckSenha.Parent = imgFundo;
            CheckSenha.BackColor = Color.Transparent;

            ClientHttp clientHttp = new ClientHttp();
            PrimeiroUso.ChecarPrimeiroUso();
        }

        private void BtnEntrar_Click( object sender, EventArgs e )
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if ( CadastroUsuario.Login(usuario, senha).Result )
            {
                Dispose();
                Close();
                Thread t = new Thread(() => Application.Run(new JanelaInicio()));
                t.Start();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Incorretos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Text = "";
                txtUsuario.Text = "";
                txtUsuario.Focus();
            }
        }

        private void CheckSenha_CheckStateChanged( object sender, EventArgs e )
        {
            if ( CheckSenha.Checked == true )
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }
    }
}
