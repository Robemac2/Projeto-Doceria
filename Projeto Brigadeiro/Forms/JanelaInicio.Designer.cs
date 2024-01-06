namespace Projeto_Brigadeiro
{
    partial class JanelaInicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaInicio));
            this.btnIngredientes = new System.Windows.Forms.Button();
            this.btnReceitas = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.imgBackground = new System.Windows.Forms.PictureBox();
            this.toolTipPedidos = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnIngredientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngredientes.Font = new System.Drawing.Font("Gabriola", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredientes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnIngredientes.Location = new System.Drawing.Point(40, 240);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Size = new System.Drawing.Size(274, 249);
            this.btnIngredientes.TabIndex = 1;
            this.btnIngredientes.Text = "Ingredientes";
            this.btnIngredientes.UseVisualStyleBackColor = true;
            this.btnIngredientes.Click += new System.EventHandler(this.BtnIngredientes_Click);
            // 
            // btnReceitas
            // 
            this.btnReceitas.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReceitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceitas.Font = new System.Drawing.Font("Gabriola", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceitas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnReceitas.Location = new System.Drawing.Point(372, 240);
            this.btnReceitas.Name = "btnReceitas";
            this.btnReceitas.Size = new System.Drawing.Size(274, 249);
            this.btnReceitas.TabIndex = 2;
            this.btnReceitas.Text = "Receitas";
            this.btnReceitas.UseVisualStyleBackColor = true;
            this.btnReceitas.Click += new System.EventHandler(this.BtnReceitas_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.Font = new System.Drawing.Font("Gabriola", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPedidos.Location = new System.Drawing.Point(704, 240);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(274, 249);
            this.btnPedidos.TabIndex = 3;
            this.btnPedidos.Text = "Pedidos";
            this.toolTipPedidos.SetToolTip(this.btnPedidos, "Módulo Pedidos está em Desenvolvimento");
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Gabriola", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfiguracoes.Location = new System.Drawing.Point(1036, 240);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(274, 249);
            this.btnConfiguracoes.TabIndex = 4;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // BtnSair
            // 
            this.BtnSair.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSair.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSair.Font = new System.Drawing.Font("Gabriola", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSair.Location = new System.Drawing.Point(40, 646);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(274, 71);
            this.BtnSair.TabIndex = 6;
            this.BtnSair.Text = "Sair";
            this.BtnSair.UseVisualStyleBackColor = false;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // imgBackground
            // 
            this.imgBackground.BackgroundImage = global::Projeto_Brigadeiro.Properties.Resources.Bolo_Menu;
            this.imgBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgBackground.Location = new System.Drawing.Point(0, 0);
            this.imgBackground.Name = "imgBackground";
            this.imgBackground.Size = new System.Drawing.Size(1353, 734);
            this.imgBackground.TabIndex = 0;
            this.imgBackground.TabStop = false;
            // 
            // JanelaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.BtnSair);
            this.Controls.Add(this.btnConfiguracoes);
            this.Controls.Add(this.btnPedidos);
            this.Controls.Add(this.btnReceitas);
            this.Controls.Add(this.btnIngredientes);
            this.Controls.Add(this.imgBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JanelaInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Brigadeiro";
            this.Load += new System.EventHandler(this.TelaInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBackground;
        private System.Windows.Forms.Button btnIngredientes;
        private System.Windows.Forms.Button btnReceitas;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.ToolTip toolTipPedidos;
    }
}