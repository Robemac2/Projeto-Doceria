using System;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaInicio : Form
    {
        public JanelaInicio()
        {
            InitializeComponent();
        }

        private void TelaInicio_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngredientes_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaIngredientes()));
            t.Start();
        }

        private void BtnReceitas_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaReceitas()));
            t.Start();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new LogIn()));
            t.Start();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaPedidos()));
            t.Start();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            Thread t = new Thread(() => Application.Run(new JanelaConfiguracoes()));
            t.Start();
        }
    }
}
