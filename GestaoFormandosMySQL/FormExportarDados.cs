using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GestaoFormandosMySQL
{
    public partial class FormExportarDados : Form
    {
        DBConnect ligacao = new DBConnect();
        
        public FormExportarDados()
        {
            InitializeComponent();
        }

        private void FormExportarDados_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboTabelas(ref cmbTabelas);
        }

        private void cmbTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbTabelas.SelectedIndex > 0)
            {
                ligacao.PreencherChkLsColunasTabela(ref chkLstColunas, cmbTabelas.Text);
                ligacao.PreencherComboColunasTabela(ref cboCampos, cmbTabelas.Text);
            }
        }

        private void btnExportarDados_Click(object sender, EventArgs e)
        {
            if (chkLstColunas.CheckedItems.Count > 0) // != chkLstColunas.Items.Count
            {
                Cursor.Current = Cursors.WaitCursor; //Set cursor as hourglass
                string[] dados = new string[chkLstColunas.CheckedItems.Count];
                int index = 0;
                foreach (object itemChecked in chkLstColunas.CheckedItems) 
                {
                    //MessageBox.Show("Coluna: " + itemChecked.ToString());
                    dados[index] = itemChecked.ToString();
                    index++;
                }
                if (cboCampos.SelectedIndex > 0 && cboOperadores.SelectedIndex > 0 && txtFiltro.Text.Length > 0)
                {
                    string filtro = cboCampos.Text + " " + cboOperadores.Text + " '" + txtFiltro.Text + "' ";
                    ligacao.ExportarRegistosTextBox(ref txtDados, dados, cmbTabelas.Text, filtro);
                }
                else
                {
                    ligacao.ExportarRegistosTextBox(ref txtDados, dados, cmbTabelas.Text);
                }
            }
            else
            {
                MessageBox.Show("Tem que selecionar pelo menos uma coluna!");
                chkLstColunas.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            chkLstColunas.Items.Clear();
            cmbTabelas.SelectedIndex = 0;
            txtDados.Clear();
            cmbTabelas.Focus();
            cboCampos.Items.Clear();
            cboOperadores.Items.Clear();
            txtFiltro.Clear();
        }

        private void btnExportarFicheiro_Click(object sender, EventArgs e)
        {
            if (txtDados.Text.Length > 0)
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Title = "Guardar dados para exportação";
                dlg.DefaultExt = "txt";
                dlg.FileName = cmbTabelas.SelectedItem.ToString();
                dlg.Filter = "Ficheiros de texto|*.txt";
                dlg.InitialDirectory = Geral.App_Path();
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(dlg.FileName, txtDados.Text);

                    if (MessageBox.Show("Deseja abrir a pasta da gravação?", "Exportação de dados",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string directoryPath = Path.GetDirectoryName(dlg.FileName);
                        Process.Start("explorer.exe", directoryPath);
                        //Process.Start(dlg.FileName); // Abre ficheiro
                    }
                }
            }
            else
            {
                MessageBox.Show("Não existem dados para exportação!");
            }

            chkLstColunas.Items.Clear();
            cmbTabelas.SelectedIndex = 0;
            txtDados.Clear();
            cmbTabelas.Focus();
            cboCampos.Items.Clear();
            cboOperadores.Items.Clear();
            txtFiltro.Clear();
        }
    }
}
