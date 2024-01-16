namespace Projeto_Brigadeiro
{
    partial class JanelaPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaPedidos));
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnData = new System.Windows.Forms.Button();
            this.BtnCliente = new System.Windows.Forms.Button();
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnStatus = new System.Windows.Forms.Button();
            this.BtnCustomizado = new System.Windows.Forms.Button();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgFundo = new System.Windows.Forms.PictureBox();
            this.CheckPedidosEmAberto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnVoltar
            // 
            this.BtnVoltar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVoltar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVoltar.Location = new System.Drawing.Point(12, 662);
            this.BtnVoltar.Name = "BtnVoltar";
            this.BtnVoltar.Size = new System.Drawing.Size(176, 55);
            this.BtnVoltar.TabIndex = 21;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToResizeColumns = false;
            this.dataView.AllowUserToResizeRows = false;
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pedido,
            this.cliente,
            this.dataPedido,
            this.total,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.Location = new System.Drawing.Point(12, 12);
            this.dataView.MultiSelect = false;
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataView.RowTemplate.Height = 25;
            this.dataView.RowTemplate.ReadOnly = true;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(845, 644);
            this.dataView.TabIndex = 22;
            this.dataView.TabStop = false;
            this.dataView.SelectionChanged += new System.EventHandler(this.dataView_SelectionChanged);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(863, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(475, 2);
            this.label5.TabIndex = 37;
            // 
            // BtnNovo
            // 
            this.BtnNovo.BackColor = System.Drawing.SystemColors.Window;
            this.BtnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Location = new System.Drawing.Point(1012, 418);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(176, 55);
            this.BtnNovo.TabIndex = 38;
            this.BtnNovo.Text = "Novo Pedido";
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnAlterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAlterar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlterar.Location = new System.Drawing.Point(1012, 479);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(176, 55);
            this.BtnAlterar.TabIndex = 39;
            this.BtnAlterar.Text = "Alterar Pedido";
            this.BtnAlterar.UseVisualStyleBackColor = false;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(1012, 601);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(176, 55);
            this.BtnCancelar.TabIndex = 40;
            this.BtnCancelar.Text = "Cancelar Pedido";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnData
            // 
            this.BtnData.BackColor = System.Drawing.SystemColors.Window;
            this.BtnData.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnData.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnData.Location = new System.Drawing.Point(1012, 97);
            this.BtnData.Name = "BtnData";
            this.BtnData.Size = new System.Drawing.Size(176, 55);
            this.BtnData.TabIndex = 41;
            this.BtnData.Text = "Geral Por Data";
            this.BtnData.UseVisualStyleBackColor = false;
            this.BtnData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // BtnCliente
            // 
            this.BtnCliente.BackColor = System.Drawing.SystemColors.Window;
            this.BtnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCliente.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.Location = new System.Drawing.Point(1012, 158);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(176, 55);
            this.BtnCliente.TabIndex = 42;
            this.BtnCliente.Text = "Geral Por Cliente";
            this.BtnCliente.UseVisualStyleBackColor = false;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // lblRelatorio
            // 
            this.lblRelatorio.AutoSize = true;
            this.lblRelatorio.Font = new System.Drawing.Font("Gabriola", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRelatorio.Location = new System.Drawing.Point(1035, 30);
            this.lblRelatorio.Name = "lblRelatorio";
            this.lblRelatorio.Size = new System.Drawing.Size(131, 59);
            this.lblRelatorio.TabIndex = 43;
            this.lblRelatorio.Text = "Relatórios";
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnFinalizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFinalizar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.Location = new System.Drawing.Point(1012, 540);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(176, 55);
            this.BtnFinalizar.TabIndex = 44;
            this.BtnFinalizar.Text = "Finalizar Pedido";
            this.BtnFinalizar.UseVisualStyleBackColor = false;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnStatus
            // 
            this.BtnStatus.BackColor = System.Drawing.SystemColors.Window;
            this.BtnStatus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStatus.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStatus.Location = new System.Drawing.Point(1012, 219);
            this.BtnStatus.Name = "BtnStatus";
            this.BtnStatus.Size = new System.Drawing.Size(176, 55);
            this.BtnStatus.TabIndex = 45;
            this.BtnStatus.Text = "Geral Por Status";
            this.BtnStatus.UseVisualStyleBackColor = false;
            this.BtnStatus.Click += new System.EventHandler(this.BtnStatus_Click);
            // 
            // BtnCustomizado
            // 
            this.BtnCustomizado.BackColor = System.Drawing.SystemColors.Window;
            this.BtnCustomizado.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCustomizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomizado.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomizado.Location = new System.Drawing.Point(1012, 280);
            this.BtnCustomizado.Name = "BtnCustomizado";
            this.BtnCustomizado.Size = new System.Drawing.Size(176, 55);
            this.BtnCustomizado.TabIndex = 46;
            this.BtnCustomizado.Text = "Customizado";
            this.BtnCustomizado.UseVisualStyleBackColor = false;
            this.BtnCustomizado.Click += new System.EventHandler(this.BtnCustomizado_Click);
            // 
            // pedido
            // 
            this.pedido.HeaderText = "Pedido";
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // dataPedido
            // 
            this.dataPedido.HeaderText = "Data Pedido";
            this.dataPedido.Name = "dataPedido";
            this.dataPedido.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // imgFundo
            // 
            this.imgFundo.BackgroundImage = global::Projeto_Brigadeiro.Properties.Resources.Bolo_Pedidos;
            this.imgFundo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgFundo.Location = new System.Drawing.Point(-3, -5);
            this.imgFundo.Name = "imgFundo";
            this.imgFundo.Size = new System.Drawing.Size(1354, 739);
            this.imgFundo.TabIndex = 0;
            this.imgFundo.TabStop = false;
            // 
            // CheckPedidosEmAberto
            // 
            this.CheckPedidosEmAberto.AutoSize = true;
            this.CheckPedidosEmAberto.BackColor = System.Drawing.Color.Transparent;
            this.CheckPedidosEmAberto.Font = new System.Drawing.Font("Gabriola", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckPedidosEmAberto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckPedidosEmAberto.Location = new System.Drawing.Point(472, 660);
            this.CheckPedidosEmAberto.Name = "CheckPedidosEmAberto";
            this.CheckPedidosEmAberto.Size = new System.Drawing.Size(385, 58);
            this.CheckPedidosEmAberto.TabIndex = 47;
            this.CheckPedidosEmAberto.Text = "Mostrar Apenas Pedidos em Aberto";
            this.CheckPedidosEmAberto.UseVisualStyleBackColor = false;
            this.CheckPedidosEmAberto.CheckedChanged += new System.EventHandler(this.CheckPedidosEmAberto_CheckedChanged);
            // 
            // JanelaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.CheckPedidosEmAberto);
            this.Controls.Add(this.BtnCustomizado);
            this.Controls.Add(this.BtnStatus);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.lblRelatorio);
            this.Controls.Add(this.BtnData);
            this.Controls.Add(this.BtnCliente);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnVoltar);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.imgFundo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JanelaPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Brigadeiro";
            this.Load += new System.EventHandler(this.JanelaPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgFundo;
        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnData;
        private System.Windows.Forms.Button BtnCliente;
        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnStatus;
        private System.Windows.Forms.Button BtnCustomizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.CheckBox CheckPedidosEmAberto;
    }
}