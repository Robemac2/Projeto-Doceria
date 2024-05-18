namespace Projeto_Brigadeiro
{
    partial class JanelaConfiguracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaConfiguracoes));
            this.dataView = new System.Windows.Forms.DataGridView();
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterarUsuario = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnergia = new System.Windows.Forms.TextBox();
            this.lblEnergia = new System.Windows.Forms.Label();
            this.txtEnergiaHora = new System.Windows.Forms.TextBox();
            this.lblEnergiaHora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAguaHora = new System.Windows.Forms.TextBox();
            this.lblAguaHora = new System.Windows.Forms.Label();
            this.txtAgua = new System.Windows.Forms.TextBox();
            this.lblAgua = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGasHora = new System.Windows.Forms.TextBox();
            this.lblGasHora = new System.Windows.Forms.Label();
            this.txtGas = new System.Windows.Forms.TextBox();
            this.lblGas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.lblSalarioHora = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblMaoDeObra = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtHoras = new System.Windows.Forms.TextBox();
            this.lblHoras = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAtualizar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.imgFundo = new System.Windows.Forms.PictureBox();
            this.txtLucro = new System.Windows.Forms.TextBox();
            this.lblLucro = new System.Windows.Forms.Label();
            this.txtGeral = new System.Windows.Forms.TextBox();
            this.lblGeral = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).BeginInit();
            this.SuspendLayout();
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
            this.dataView.Size = new System.Drawing.Size(479, 644);
            this.dataView.TabIndex = 2;
            this.dataView.TabStop = false;
            this.dataView.SelectionChanged += new System.EventHandler(this.dataView_SelectionChanged);
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
            this.BtnVoltar.TabIndex = 7;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.BackColor = System.Drawing.SystemColors.Window;
            this.BtnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcluir.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcluir.Location = new System.Drawing.Point(497, 601);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(176, 55);
            this.BtnExcluir.TabIndex = 3;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = false;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnAlterarUsuario
            // 
            this.BtnAlterarUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.BtnAlterarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnAlterarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAlterarUsuario.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlterarUsuario.Location = new System.Drawing.Point(497, 540);
            this.BtnAlterarUsuario.Name = "BtnAlterarUsuario";
            this.BtnAlterarUsuario.Size = new System.Drawing.Size(176, 55);
            this.BtnAlterarUsuario.TabIndex = 2;
            this.BtnAlterarUsuario.Text = "Alterar";
            this.BtnAlterarUsuario.UseVisualStyleBackColor = false;
            this.BtnAlterarUsuario.Click += new System.EventHandler(this.BtnAlterarUsuario_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.BackColor = System.Drawing.SystemColors.Window;
            this.BtnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Location = new System.Drawing.Point(497, 479);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(176, 55);
            this.BtnNovo.TabIndex = 1;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(679, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 708);
            this.label1.TabIndex = 21;
            // 
            // txtEnergia
            // 
            this.txtEnergia.BackColor = System.Drawing.SystemColors.Window;
            this.txtEnergia.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnergia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEnergia.Location = new System.Drawing.Point(930, 17);
            this.txtEnergia.Name = "txtEnergia";
            this.txtEnergia.Size = new System.Drawing.Size(358, 40);
            this.txtEnergia.TabIndex = 23;
            this.txtEnergia.TabStop = false;
            this.txtEnergia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPreco_KeyDown);
            this.txtEnergia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPreco_KeyPress);
            // 
            // lblEnergia
            // 
            this.lblEnergia.AutoSize = true;
            this.lblEnergia.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEnergia.Location = new System.Drawing.Point(790, 14);
            this.lblEnergia.Name = "lblEnergia";
            this.lblEnergia.Size = new System.Drawing.Size(134, 45);
            this.lblEnergia.TabIndex = 22;
            this.lblEnergia.Text = "Preço Energia";
            // 
            // txtEnergiaHora
            // 
            this.txtEnergiaHora.BackColor = System.Drawing.SystemColors.Window;
            this.txtEnergiaHora.Enabled = false;
            this.txtEnergiaHora.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnergiaHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEnergiaHora.Location = new System.Drawing.Point(930, 63);
            this.txtEnergiaHora.Name = "txtEnergiaHora";
            this.txtEnergiaHora.Size = new System.Drawing.Size(358, 40);
            this.txtEnergiaHora.TabIndex = 25;
            this.txtEnergiaHora.TabStop = false;
            // 
            // lblEnergiaHora
            // 
            this.lblEnergiaHora.AutoSize = true;
            this.lblEnergiaHora.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergiaHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEnergiaHora.Location = new System.Drawing.Point(790, 60);
            this.lblEnergiaHora.Name = "lblEnergiaHora";
            this.lblEnergiaHora.Size = new System.Drawing.Size(116, 45);
            this.lblEnergiaHora.TabIndex = 24;
            this.lblEnergiaHora.Text = "Custo Hora";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(687, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 2);
            this.label2.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(687, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(651, 2);
            this.label3.TabIndex = 31;
            // 
            // txtAguaHora
            // 
            this.txtAguaHora.BackColor = System.Drawing.SystemColors.Window;
            this.txtAguaHora.Enabled = false;
            this.txtAguaHora.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAguaHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAguaHora.Location = new System.Drawing.Point(930, 186);
            this.txtAguaHora.Name = "txtAguaHora";
            this.txtAguaHora.Size = new System.Drawing.Size(358, 40);
            this.txtAguaHora.TabIndex = 30;
            this.txtAguaHora.TabStop = false;
            // 
            // lblAguaHora
            // 
            this.lblAguaHora.AutoSize = true;
            this.lblAguaHora.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguaHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAguaHora.Location = new System.Drawing.Point(790, 183);
            this.lblAguaHora.Name = "lblAguaHora";
            this.lblAguaHora.Size = new System.Drawing.Size(116, 45);
            this.lblAguaHora.TabIndex = 29;
            this.lblAguaHora.Text = "Custo Hora";
            // 
            // txtAgua
            // 
            this.txtAgua.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgua.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAgua.Location = new System.Drawing.Point(930, 140);
            this.txtAgua.Name = "txtAgua";
            this.txtAgua.Size = new System.Drawing.Size(358, 40);
            this.txtAgua.TabIndex = 28;
            this.txtAgua.TabStop = false;
            this.txtAgua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPreco_KeyDown);
            this.txtAgua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPreco_KeyPress);
            // 
            // lblAgua
            // 
            this.lblAgua.AutoSize = true;
            this.lblAgua.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAgua.Location = new System.Drawing.Point(790, 137);
            this.lblAgua.Name = "lblAgua";
            this.lblAgua.Size = new System.Drawing.Size(114, 45);
            this.lblAgua.TabIndex = 27;
            this.lblAgua.Text = "Preço Água";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(687, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(651, 2);
            this.label5.TabIndex = 36;
            // 
            // txtGasHora
            // 
            this.txtGasHora.BackColor = System.Drawing.SystemColors.Window;
            this.txtGasHora.Enabled = false;
            this.txtGasHora.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGasHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGasHora.Location = new System.Drawing.Point(930, 305);
            this.txtGasHora.Name = "txtGasHora";
            this.txtGasHora.Size = new System.Drawing.Size(358, 40);
            this.txtGasHora.TabIndex = 35;
            this.txtGasHora.TabStop = false;
            // 
            // lblGasHora
            // 
            this.lblGasHora.AutoSize = true;
            this.lblGasHora.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGasHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGasHora.Location = new System.Drawing.Point(790, 302);
            this.lblGasHora.Name = "lblGasHora";
            this.lblGasHora.Size = new System.Drawing.Size(116, 45);
            this.lblGasHora.TabIndex = 34;
            this.lblGasHora.Text = "Custo Hora";
            // 
            // txtGas
            // 
            this.txtGas.BackColor = System.Drawing.SystemColors.Window;
            this.txtGas.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGas.Location = new System.Drawing.Point(930, 259);
            this.txtGas.Name = "txtGas";
            this.txtGas.Size = new System.Drawing.Size(358, 40);
            this.txtGas.TabIndex = 33;
            this.txtGas.TabStop = false;
            this.txtGas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPreco_KeyDown);
            this.txtGas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPreco_KeyPress);
            // 
            // lblGas
            // 
            this.lblGas.AutoSize = true;
            this.lblGas.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGas.Location = new System.Drawing.Point(790, 256);
            this.lblGas.Name = "lblGas";
            this.lblGas.Size = new System.Drawing.Size(101, 45);
            this.lblGas.TabIndex = 32;
            this.lblGas.Text = "Preço Gás";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(687, 547);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(651, 2);
            this.label4.TabIndex = 41;
            // 
            // txtCusto
            // 
            this.txtCusto.BackColor = System.Drawing.SystemColors.Window;
            this.txtCusto.Enabled = false;
            this.txtCusto.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCusto.Location = new System.Drawing.Point(930, 497);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(358, 40);
            this.txtCusto.TabIndex = 40;
            this.txtCusto.TabStop = false;
            // 
            // lblSalarioHora
            // 
            this.lblSalarioHora.AutoSize = true;
            this.lblSalarioHora.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalarioHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalarioHora.Location = new System.Drawing.Point(790, 494);
            this.lblSalarioHora.Name = "lblSalarioHora";
            this.lblSalarioHora.Size = new System.Drawing.Size(116, 45);
            this.lblSalarioHora.TabIndex = 39;
            this.lblSalarioHora.Text = "Custo Hora";
            // 
            // txtDias
            // 
            this.txtDias.BackColor = System.Drawing.SystemColors.Window;
            this.txtDias.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDias.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDias.Location = new System.Drawing.Point(930, 451);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(120, 40);
            this.txtDias.TabIndex = 38;
            this.txtDias.TabStop = false;
            this.txtDias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantidade_KeyPress);
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDias.Location = new System.Drawing.Point(790, 448);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(108, 45);
            this.lblDias.TabIndex = 37;
            this.lblDias.Text = "Dias / Mês";
            // 
            // lblMaoDeObra
            // 
            this.lblMaoDeObra.AutoSize = true;
            this.lblMaoDeObra.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaoDeObra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaoDeObra.Location = new System.Drawing.Point(922, 357);
            this.lblMaoDeObra.Name = "lblMaoDeObra";
            this.lblMaoDeObra.Size = new System.Drawing.Size(128, 45);
            this.lblMaoDeObra.TabIndex = 42;
            this.lblMaoDeObra.Text = "Mão de Obra";
            // 
            // txtSalario
            // 
            this.txtSalario.BackColor = System.Drawing.SystemColors.Window;
            this.txtSalario.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSalario.Location = new System.Drawing.Point(930, 405);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(358, 40);
            this.txtSalario.TabIndex = 44;
            this.txtSalario.TabStop = false;
            this.txtSalario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPreco_KeyDown);
            this.txtSalario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPreco_KeyPress);
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalario.Location = new System.Drawing.Point(790, 402);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(79, 45);
            this.lblSalario.TabIndex = 43;
            this.lblSalario.Text = "Salário";
            // 
            // txtHoras
            // 
            this.txtHoras.BackColor = System.Drawing.SystemColors.Window;
            this.txtHoras.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoras.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHoras.Location = new System.Drawing.Point(1168, 451);
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(120, 40);
            this.txtHoras.TabIndex = 46;
            this.txtHoras.TabStop = false;
            this.txtHoras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtHoras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantidade_KeyPress);
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHoras.Location = new System.Drawing.Point(1056, 448);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(118, 45);
            this.lblHoras.TabIndex = 45;
            this.lblHoras.Text = "Horas / Dia";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(730, 635);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(176, 55);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAtualizar
            // 
            this.BtnAtualizar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnAtualizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAtualizar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAtualizar.Location = new System.Drawing.Point(938, 635);
            this.BtnAtualizar.Name = "BtnAtualizar";
            this.BtnAtualizar.Size = new System.Drawing.Size(176, 55);
            this.BtnAtualizar.TabIndex = 5;
            this.BtnAtualizar.Text = "Atualizar";
            this.BtnAtualizar.UseVisualStyleBackColor = false;
            this.BtnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvar.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.Location = new System.Drawing.Point(1146, 635);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(176, 55);
            this.BtnSalvar.TabIndex = 6;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // imgFundo
            // 
            this.imgFundo.BackgroundImage = global::Projeto_Brigadeiro.Properties.Resources.Bolo_Configuracoes;
            this.imgFundo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgFundo.Location = new System.Drawing.Point(0, 0);
            this.imgFundo.Name = "imgFundo";
            this.imgFundo.Size = new System.Drawing.Size(1354, 735);
            this.imgFundo.TabIndex = 47;
            this.imgFundo.TabStop = false;
            // 
            // txtLucro
            // 
            this.txtLucro.BackColor = System.Drawing.SystemColors.Window;
            this.txtLucro.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLucro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLucro.Location = new System.Drawing.Point(1130, 556);
            this.txtLucro.Name = "txtLucro";
            this.txtLucro.Size = new System.Drawing.Size(158, 40);
            this.txtLucro.TabIndex = 51;
            this.txtLucro.TabStop = false;
            this.txtLucro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtLucro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantidade_KeyPress);
            // 
            // lblLucro
            // 
            this.lblLucro.AutoSize = true;
            this.lblLucro.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLucro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLucro.Location = new System.Drawing.Point(1056, 553);
            this.lblLucro.Name = "lblLucro";
            this.lblLucro.Size = new System.Drawing.Size(68, 45);
            this.lblLucro.TabIndex = 50;
            this.lblLucro.Text = "Lucro";
            // 
            // txtGeral
            // 
            this.txtGeral.BackColor = System.Drawing.SystemColors.Window;
            this.txtGeral.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGeral.Location = new System.Drawing.Point(930, 556);
            this.txtGeral.Name = "txtGeral";
            this.txtGeral.Size = new System.Drawing.Size(120, 40);
            this.txtGeral.TabIndex = 49;
            this.txtGeral.TabStop = false;
            this.txtGeral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantidade_KeyDown);
            this.txtGeral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantidade_KeyPress);
            // 
            // lblGeral
            // 
            this.lblGeral.AutoSize = true;
            this.lblGeral.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGeral.Location = new System.Drawing.Point(790, 553);
            this.lblGeral.Name = "lblGeral";
            this.lblGeral.Size = new System.Drawing.Size(120, 45);
            this.lblGeral.TabIndex = 48;
            this.lblGeral.Text = "Custo Extra";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(687, 601);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(651, 2);
            this.label8.TabIndex = 52;
            // 
            // JanelaConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLucro);
            this.Controls.Add(this.lblLucro);
            this.Controls.Add(this.txtGeral);
            this.Controls.Add(this.lblGeral);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.BtnAtualizar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.txtHoras);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.lblMaoDeObra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCusto);
            this.Controls.Add(this.lblSalarioHora);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGasHora);
            this.Controls.Add(this.lblGasHora);
            this.Controls.Add(this.txtGas);
            this.Controls.Add(this.lblGas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAguaHora);
            this.Controls.Add(this.lblAguaHora);
            this.Controls.Add(this.txtAgua);
            this.Controls.Add(this.lblAgua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEnergiaHora);
            this.Controls.Add(this.lblEnergiaHora);
            this.Controls.Add(this.txtEnergia);
            this.Controls.Add(this.lblEnergia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.BtnAlterarUsuario);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnVoltar);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.imgFundo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JanelaConfiguracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Brigadeiro";
            this.Load += new System.EventHandler(this.JanelaConfiguracoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterarUsuario;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnergia;
        private System.Windows.Forms.Label lblEnergia;
        private System.Windows.Forms.TextBox txtEnergiaHora;
        private System.Windows.Forms.Label lblEnergiaHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAguaHora;
        private System.Windows.Forms.Label lblAguaHora;
        private System.Windows.Forms.TextBox txtAgua;
        private System.Windows.Forms.Label lblAgua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGasHora;
        private System.Windows.Forms.Label lblGasHora;
        private System.Windows.Forms.TextBox txtGas;
        private System.Windows.Forms.Label lblGas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.Label lblSalarioHora;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblMaoDeObra;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.TextBox txtHoras;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAtualizar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.PictureBox imgFundo;
        private System.Windows.Forms.TextBox txtLucro;
        private System.Windows.Forms.Label lblLucro;
        private System.Windows.Forms.TextBox txtGeral;
        private System.Windows.Forms.Label lblGeral;
        private System.Windows.Forms.Label label8;
    }
}