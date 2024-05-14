using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormandosMySQL
{
    public partial class FormAtualizarArea : Form
    {
        DBConnectFormadores ligacao = new DBConnectFormadores();
        string id_area = string.Empty;
        public FormAtualizarArea()
        {
            InitializeComponent();
        }

        private void FormAtualizarArea_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboArea(ref cmbArea);

            txtArea.ReadOnly = true;

            btnAtualizar.Enabled = false;
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string area = "";
            if (cmbArea.SelectedIndex != -1)
            {
                id_area = cmbArea.Text.Substring(
                    cmbArea.Text.LastIndexOf(' ') + 1);
                if (ligacao.PesquisaArea(id_area, ref area))
                {
                    txtArea.Text = area;

                    txtArea.ReadOnly = false;

                    cmbArea.Enabled = false;
                    btnAtualizar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Área não encontrada!");
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                if (ligacao.UpdateArea(id_area, txtArea.Text))
                {
                    MessageBox.Show("Atualizado com sucesso!");
                    cmbArea.Items.Clear();
                    ligacao.PreencherComboArea(ref cmbArea);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro na atualização do registo!");
                }
            }
        }

        private bool VerificarCampos()
        {

            txtArea.Text = Geral.TirarEspacos(txtArea.Text);
            if (txtArea.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo Área!");
                txtArea.Focus();
                return false;
            }

            return true;
        }
        void LimparCampos()
        {
            txtArea.ReadOnly = true;

            txtArea.Clear();
            
            cmbArea.Enabled = true;
            btnAtualizar.Enabled = false;

            cmbArea.Text = "";
            cmbArea.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
