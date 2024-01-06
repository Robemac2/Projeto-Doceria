namespace Projeto_Brigadeiro
{
    partial class JanelaNovaReceita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaNovaReceita));
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.ingrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboUnidade = new System.Windows.Forms.ComboBox();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.comboIngrediente = new System.Windows.Forms.ComboBox();
            this.lblTempoPreparo = new System.Windows.Forms.Label();
            this.txtRendimento = new System.Windows.Forms.TextBox();
            this.lblRendimento = new System.Windows.Forms.Label();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.lblCusto = new System.Windows.Forms.Label();
            this.BtnRemover = new System.Windows.Forms.Button();
            this.BtnAdicionar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.imgFundo = new System.Windows.Forms.PictureBox();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.txtReceita = new System.Windows.Forms.TextBox();
            this.lblNomeReceita = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtMinuto = new System.Windows.Forms.TextBox();
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
            this.BtnVoltar.TabIndex = 19;
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
            this.ingrediente,
            this.quantidade,
            this.unidade,
            this.preco});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.Location = new System.Drawing.Point(12, 41);
            this.dataView.MultiSelect = false;
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataView.RowTemplate.Height = 25;
            this.dataView.RowTemplate.ReadOnly = true;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(810, 615);
            this.dataView.TabIndex = 20;
            this.dataView.TabStop = false;
            this.dataView.SelectionChanged += new System.EventHandler(this.dataView_SelectionChanged);
            // 
            // ingrediente
            // 
            this.ingrediente.HeaderText = "Ingrediente";
            this.ingrediente.Name = "ingrediente";
            this.ingrediente.ReadOnly = true;
            // 
            // quantidade
            // 
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            // 
            // unidade
            // 
            this.unidade.HeaderText = "Unidade";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            // 
            // preco
            // 
            this.preco.HeaderText = "Preço";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            // 
            // comboUnidade
            // 
            this.comboUnidade.BackColor = System.Drawing.SystemColors.Window;
            this.comboUnidade.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUnidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboUnidade.FormattingEnabled = true;
            this.comboUnidade.Items.AddRange(new object[] {
            "gramas",
            "Kilogramas",
            "mililitros",
            "Litros",
            "unidades"});
            this.comboUnidade.Location = new System.Drawing.Point(997, 211);
            this.comboUnidade.Name = "comboUnidade";
            this.comboUnidade.Size = new System.Drawing.Size(141, 43);
            this.comboUnidade.TabIndex = 29;
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnidade.Location = new System.Drawing.Point(862, 208);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(91, 45);
            this.lblUnidade.TabIndex = 30;
            this.lblUnidade.Text = "Unidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.SystemColors.Window;
            this.txtQuantidade.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtQuantidade.Location = new System.Drawing.Point(997, 126);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(341, 40);
            this.txtQuantidade.TabIndex = 27;
            this.txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantidade_KeyPress);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuantidade.Location = new System.Drawing.Point(862, 123);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(119, 45);
            this.lblQuantidade.TabIndex = 28;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrediente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIngrediente.Location = new System.Drawing.Point(862, 38);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(114, 45);
            this.lblIngrediente.TabIndex = 25;
            this.lblIngrediente.Text = "Ingrediente";
            // 
            // comboIngrediente
            // 
            this.comboIngrediente.BackColor = System.Drawing.SystemColors.Window;
            this.comboIngrediente.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboIngrediente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboIngrediente.FormattingEnabled = true;
            this.comboIngrediente.Location = new System.Drawing.Point(997, 41);
            this.comboIngrediente.Name = "comboIngrediente";
            this.comboIngrediente.Size = new System.Drawing.Size(341, 43);
            this.comboIngrediente.TabIndex = 31;
            // 
            // lblTempoPreparo
            // 
            this.lblTempoPreparo.AutoSize = true;
            this.lblTempoPreparo.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempoPreparo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTempoPreparo.Location = new System.Drawing.Point(862, 460);
            this.lblTempoPreparo.Name = "lblTempoPreparo";
            this.lblTempoPreparo.Size = new System.Drawing.Size(169, 45);
            this.lblTempoPreparo.TabIndex = 33;
            this.lblTempoPreparo.Text = "Tempo de Preparo";
            // 
            // txtRendimento
            // 
            this.txtRendimento.BackColor = System.Drawing.SystemColors.Window;
            this.txtRendimento.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRendimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRendimento.Location = new System.Drawing.Point(1037, 509);
            this.txtRendimento.Name = "txtRendimento";
            this.txtRendimento.Size = new System.Drawing.Size(301, 40);
            this.txtRendimento.TabIndex = 34;
            this.txtRendimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRendimento_KeyDown);
            this.txtRendimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRendimento_KeyPress);
            // 
            // lblRendimento
            // 
            this.lblRendimento.AutoSize = true;
            this.lblRendimento.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRendimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRendimento.Location = new System.Drawing.Point(862, 506);
            this.lblRendimento.Name = "lblRendimento";
            this.lblRendimento.Size = new System.Drawing.Size(120, 45);
            this.lblRendimento.TabIndex = 35;
            this.lblRendimento.Text = "Rendimento";
            // 
            // txtCusto
            // 
            this.txtCusto.BackColor = System.Drawing.SystemColors.Window;
            this.txtCusto.Enabled = false;
            this.txtCusto.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCusto.Location = new System.Drawing.Point(1037, 555);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(301, 40);
            this.txtCusto.TabIndex = 36;
            // 
            // lblCusto
            // 
            this.lblCusto.AutoSize = true;
            this.lblCusto.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCusto.Location = new System.Drawing.Point(862, 552);
            this.lblCusto.Name = "lblCusto";
            this.lblCusto.Size = new System.Drawing.Size(116, 45);
            this.lblCusto.TabIndex = 37;
            this.lblCusto.Text = "Custo Total";
            // 
            // BtnRemover
            // 
            this.BtnRemover.BackColor = System.Drawing.SystemColors.Window;
            this.BtnRemover.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemover.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemover.Location = new System.Drawing.Point(924, 308);
            this.BtnRemover.Name = "BtnRemover";
            this.BtnRemover.Size = new System.Drawing.Size(176, 55);
            this.BtnRemover.TabIndex = 38;
            this.BtnRemover.Text = "Remover";
            this.BtnRemover.UseVisualStyleBackColor = false;
            this.BtnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // BtnAdicionar
            // 
            this.BtnAdicionar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdicionar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdicionar.Location = new System.Drawing.Point(1124, 308);
            this.BtnAdicionar.Name = "BtnAdicionar";
            this.BtnAdicionar.Size = new System.Drawing.Size(214, 55);
            this.BtnAdicionar.TabIndex = 39;
            this.BtnAdicionar.Text = "Adicionar / Atualizar";
            this.BtnAdicionar.UseVisualStyleBackColor = false;
            this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.Location = new System.Drawing.Point(962, 601);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(176, 55);
            this.BtnSalvar.TabIndex = 40;
            this.BtnSalvar.Text = "Salvar Receita";
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // imgFundo
            // 
            this.imgFundo.BackgroundImage = global::Projeto_Brigadeiro.Properties.Resources.Bolo_Receitas;
            this.imgFundo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgFundo.Location = new System.Drawing.Point(0, 0);
            this.imgFundo.Name = "imgFundo";
            this.imgFundo.Size = new System.Drawing.Size(1353, 732);
            this.imgFundo.TabIndex = 41;
            this.imgFundo.TabStop = false;
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpar.Location = new System.Drawing.Point(1162, 199);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(176, 55);
            this.BtnLimpar.TabIndex = 42;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.UseVisualStyleBackColor = false;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // txtReceita
            // 
            this.txtReceita.BackColor = System.Drawing.SystemColors.Window;
            this.txtReceita.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceita.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtReceita.Location = new System.Drawing.Point(1037, 407);
            this.txtReceita.Name = "txtReceita";
            this.txtReceita.Size = new System.Drawing.Size(301, 40);
            this.txtReceita.TabIndex = 44;
            // 
            // lblNomeReceita
            // 
            this.lblNomeReceita.AutoSize = true;
            this.lblNomeReceita.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeReceita.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNomeReceita.Location = new System.Drawing.Point(862, 404);
            this.lblNomeReceita.Name = "lblNomeReceita";
            this.lblNomeReceita.Size = new System.Drawing.Size(79, 45);
            this.lblNomeReceita.TabIndex = 45;
            this.lblNomeReceita.Text = "Receita";
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.SystemColors.Window;
            this.txtHora.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHora.Location = new System.Drawing.Point(1037, 463);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(91, 40);
            this.txtHora.TabIndex = 48;
            this.txtHora.TextChanged += new System.EventHandler(this.txtHora_TextChanged);
            this.txtHora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRendimento_KeyPress);
            // 
            // txtMinuto
            // 
            this.txtMinuto.BackColor = System.Drawing.SystemColors.Window;
            this.txtMinuto.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinuto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMinuto.Location = new System.Drawing.Point(1134, 463);
            this.txtMinuto.Name = "txtMinuto";
            this.txtMinuto.Size = new System.Drawing.Size(91, 40);
            this.txtMinuto.TabIndex = 49;
            this.txtMinuto.TextChanged += new System.EventHandler(this.txtMinuto_TextChanged);
            this.txtMinuto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtMinuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRendimento_KeyPress);
            // 
            // JanelaNovaReceita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.txtMinuto);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.txtReceita);
            this.Controls.Add(this.lblNomeReceita);
            this.Controls.Add(this.BtnLimpar);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.BtnAdicionar);
            this.Controls.Add(this.BtnRemover);
            this.Controls.Add(this.txtCusto);
            this.Controls.Add(this.lblCusto);
            this.Controls.Add(this.txtRendimento);
            this.Controls.Add(this.lblRendimento);
            this.Controls.Add(this.lblTempoPreparo);
            this.Controls.Add(this.comboIngrediente);
            this.Controls.Add(this.comboUnidade);
            this.Controls.Add(this.lblUnidade);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblIngrediente);
            this.Controls.Add(this.BtnVoltar);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.imgFundo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JanelaNovaReceita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Brigadeiro";
            this.Load += new System.EventHandler(this.JanelaNovaReceita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.ComboBox comboUnidade;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.ComboBox comboIngrediente;
        private System.Windows.Forms.Label lblTempoPreparo;
        private System.Windows.Forms.TextBox txtRendimento;
        private System.Windows.Forms.Label lblRendimento;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.Label lblCusto;
        private System.Windows.Forms.Button BtnRemover;
        private System.Windows.Forms.Button BtnAdicionar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.PictureBox imgFundo;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.TextBox txtReceita;
        private System.Windows.Forms.Label lblNomeReceita;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtMinuto;
    }
}