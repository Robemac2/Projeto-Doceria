using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Brigadeiro
{
    public partial class JanelaPedidos : Form
    {
        public JanelaPedidos()
        {
            InitializeComponent();
        }

        private void JanelaPedidos_Load(object sender, EventArgs e)
        {
            lblRelatorio.Parent = imgFundo;
            lblRelatorio.BackColor = Color.Transparent;
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
    }
}
