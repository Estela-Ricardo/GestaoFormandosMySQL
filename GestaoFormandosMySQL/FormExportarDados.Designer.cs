using System.Drawing;

namespace GestaoFormandosMySQL
{
    partial class FormExportarDados
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportarDados = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.chkLstColunas = new System.Windows.Forms.CheckedListBox();
            this.cmbTabelas = new System.Windows.Forms.ComboBox();
            this.txtDados = new System.Windows.Forms.TextBox();
            this.btnExportarFicheiro = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCampos = new System.Windows.Forms.ComboBox();
            this.cboOperadores = new System.Windows.Forms.ComboBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnExportarDados);
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.chkLstColunas);
            this.groupBox1.Controls.Add(this.cmbTabelas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabela";
            // 
            // btnExportarDados
            // 
            this.btnExportarDados.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportarDados.Location = new System.Drawing.Point(477, 144);
            this.btnExportarDados.Name = "btnExportarDados";
            this.btnExportarDados.Size = new System.Drawing.Size(126, 49);
            this.btnExportarDados.TabIndex = 2;
            this.btnExportarDados.Text = "Exportar Dados";
            this.btnExportarDados.UseVisualStyleBackColor = false;
            this.btnExportarDados.Click += new System.EventHandler(this.btnExportarDados_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpar.Location = new System.Drawing.Point(259, 144);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(126, 49);
            this.btnLimpar.TabIndex = 2;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // chkLstColunas
            // 
            this.chkLstColunas.CheckOnClick = true;
            this.chkLstColunas.FormattingEnabled = true;
            this.chkLstColunas.HorizontalScrollbar = true;
            this.chkLstColunas.Location = new System.Drawing.Point(259, 32);
            this.chkLstColunas.Name = "chkLstColunas";
            this.chkLstColunas.Size = new System.Drawing.Size(344, 106);
            this.chkLstColunas.TabIndex = 1;
            // 
            // cmbTabelas
            // 
            this.cmbTabelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabelas.FormattingEnabled = true;
            this.cmbTabelas.Location = new System.Drawing.Point(9, 32);
            this.cmbTabelas.Name = "cmbTabelas";
            this.cmbTabelas.Size = new System.Drawing.Size(230, 24);
            this.cmbTabelas.TabIndex = 0;
            this.cmbTabelas.SelectedIndexChanged += new System.EventHandler(this.cmbTabelas_SelectedIndexChanged);
            // 
            // txtDados
            // 
            this.txtDados.Location = new System.Drawing.Point(12, 239);
            this.txtDados.Multiline = true;
            this.txtDados.Name = "txtDados";
            this.txtDados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDados.Size = new System.Drawing.Size(625, 219);
            this.txtDados.TabIndex = 1;
            this.txtDados.WordWrap = false;
            // 
            // btnExportarFicheiro
            // 
            this.btnExportarFicheiro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportarFicheiro.Location = new System.Drawing.Point(489, 464);
            this.btnExportarFicheiro.Name = "btnExportarFicheiro";
            this.btnExportarFicheiro.Size = new System.Drawing.Size(126, 49);
            this.btnExportarFicheiro.TabIndex = 2;
            this.btnExportarFicheiro.Text = "Exportar Ficheiro";
            this.btnExportarFicheiro.UseVisualStyleBackColor = false;
            this.btnExportarFicheiro.Click += new System.EventHandler(this.btnExportarFicheiro_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFiltro);
            this.groupBox2.Controls.Add(this.cboOperadores);
            this.groupBox2.Controls.Add(this.cboCampos);
            this.groupBox2.Location = new System.Drawing.Point(9, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 122);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // cboCampos
            // 
            this.cboCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampos.FormattingEnabled = true;
            this.cboCampos.Location = new System.Drawing.Point(7, 22);
            this.cboCampos.Name = "cboCampos";
            this.cboCampos.Size = new System.Drawing.Size(130, 24);
            this.cboCampos.TabIndex = 0;
            // 
            // cboOperadores
            // 
            this.cboOperadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperadores.FormattingEnabled = true;
            this.cboOperadores.Items.AddRange(new object[] {
            "",
            ">=",
            ">",
            "=",
            "<=",
            "<",
            "!=",
            "like"});
            this.cboOperadores.Location = new System.Drawing.Point(157, 22);
            this.cboOperadores.Name = "cboOperadores";
            this.cboOperadores.Size = new System.Drawing.Size(67, 24);
            this.cboOperadores.TabIndex = 0;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(7, 73);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(217, 22);
            this.txtFiltro.TabIndex = 1;
            // 
            // FormExportarDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 526);
            this.Controls.Add(this.btnExportarFicheiro);
            this.Controls.Add(this.txtDados);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExportarDados";
            this.ShowIcon = false;
            this.Text = "Exportação de Dados";
            this.Load += new System.EventHandler(this.FormExportarDados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTabelas;
        private System.Windows.Forms.CheckedListBox chkLstColunas;
        private System.Windows.Forms.Button btnExportarDados;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TextBox txtDados;
        private System.Windows.Forms.Button btnExportarFicheiro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCampos;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboOperadores;
    }
}