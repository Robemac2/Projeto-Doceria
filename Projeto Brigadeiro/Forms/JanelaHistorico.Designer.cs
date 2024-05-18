namespace Projeto_Brigadeiro
{
    partial class JanelaHistorico
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaHistorico));
            this.imgFundo = new System.Windows.Forms.PictureBox();
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.BtnMes = new System.Windows.Forms.Button();
            this.BtnTrimestre = new System.Windows.Forms.Button();
            this.BtnSemestre = new System.Windows.Forms.Button();
            this.BtnAno = new System.Windows.Forms.Button();
            this.BtnCompleto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFundo
            // 
            this.imgFundo.BackgroundImage = global::Projeto_Brigadeiro.Properties.Resources.Bolo_Historico;
            this.imgFundo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgFundo.Location = new System.Drawing.Point(0, 0);
            this.imgFundo.Name = "imgFundo";
            this.imgFundo.Size = new System.Drawing.Size(1355, 733);
            this.imgFundo.TabIndex = 0;
            this.imgFundo.TabStop = false;
            // 
            // grafico
            // 
            legend1.Name = "Legend1";
            this.grafico.Legends.Add(legend1);
            this.grafico.Location = new System.Drawing.Point(434, 12);
            this.grafico.Name = "grafico";
            series1.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Preço";
            this.grafico.Series.Add(series1);
            this.grafico.Size = new System.Drawing.Size(904, 644);
            this.grafico.TabIndex = 1;
            this.grafico.Text = "chart1";
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
            this.dataView.Size = new System.Drawing.Size(416, 644);
            this.dataView.TabIndex = 2;
            this.dataView.TabStop = false;
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
            this.BtnVoltar.TabIndex = 17;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // BtnMes
            // 
            this.BtnMes.BackColor = System.Drawing.SystemColors.Window;
            this.BtnMes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMes.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMes.Location = new System.Drawing.Point(1162, 662);
            this.BtnMes.Name = "BtnMes";
            this.BtnMes.Size = new System.Drawing.Size(176, 55);
            this.BtnMes.TabIndex = 18;
            this.BtnMes.Text = "Último Mês";
            this.BtnMes.UseVisualStyleBackColor = false;
            this.BtnMes.Click += new System.EventHandler(this.BtnMes_Click);
            // 
            // BtnTrimestre
            // 
            this.BtnTrimestre.BackColor = System.Drawing.SystemColors.Window;
            this.BtnTrimestre.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnTrimestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTrimestre.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTrimestre.Location = new System.Drawing.Point(980, 662);
            this.BtnTrimestre.Name = "BtnTrimestre";
            this.BtnTrimestre.Size = new System.Drawing.Size(176, 55);
            this.BtnTrimestre.TabIndex = 19;
            this.BtnTrimestre.Text = "Último Trimesrte";
            this.BtnTrimestre.UseVisualStyleBackColor = false;
            this.BtnTrimestre.Click += new System.EventHandler(this.BtnTrimestre_Click);
            // 
            // BtnSemestre
            // 
            this.BtnSemestre.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSemestre.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnSemestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSemestre.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSemestre.Location = new System.Drawing.Point(798, 662);
            this.BtnSemestre.Name = "BtnSemestre";
            this.BtnSemestre.Size = new System.Drawing.Size(176, 55);
            this.BtnSemestre.TabIndex = 20;
            this.BtnSemestre.Text = "Último Semestre";
            this.BtnSemestre.UseVisualStyleBackColor = false;
            this.BtnSemestre.Click += new System.EventHandler(this.BtnSemestre_Click);
            // 
            // BtnAno
            // 
            this.BtnAno.BackColor = System.Drawing.SystemColors.Window;
            this.BtnAno.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAno.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAno.Location = new System.Drawing.Point(616, 662);
            this.BtnAno.Name = "BtnAno";
            this.BtnAno.Size = new System.Drawing.Size(176, 55);
            this.BtnAno.TabIndex = 21;
            this.BtnAno.Text = "Último Ano";
            this.BtnAno.UseVisualStyleBackColor = false;
            this.BtnAno.Click += new System.EventHandler(this.BtnAno_Click);
            // 
            // BtnCompleto
            // 
            this.BtnCompleto.BackColor = System.Drawing.SystemColors.Window;
            this.BtnCompleto.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCompleto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCompleto.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompleto.Location = new System.Drawing.Point(434, 662);
            this.BtnCompleto.Name = "BtnCompleto";
            this.BtnCompleto.Size = new System.Drawing.Size(176, 55);
            this.BtnCompleto.TabIndex = 22;
            this.BtnCompleto.Text = "Completo";
            this.BtnCompleto.UseVisualStyleBackColor = false;
            this.BtnCompleto.Click += new System.EventHandler(this.BtnCompleto_Click);
            // 
            // JanelaHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.BtnCompleto);
            this.Controls.Add(this.BtnAno);
            this.Controls.Add(this.BtnSemestre);
            this.Controls.Add(this.BtnTrimestre);
            this.Controls.Add(this.BtnMes);
            this.Controls.Add(this.BtnVoltar);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.grafico);
            this.Controls.Add(this.imgFundo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JanelaHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Brigadeiro";
            this.Load += new System.EventHandler(this.JanelaHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFundo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgFundo;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.Button BtnMes;
        private System.Windows.Forms.Button BtnTrimestre;
        private System.Windows.Forms.Button BtnSemestre;
        private System.Windows.Forms.Button BtnAno;
        private System.Windows.Forms.Button BtnCompleto;
    }
}