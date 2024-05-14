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
    public partial class FormApagarArea : Form
    {
        DBConnectFormadores ligacao = new DBConnectFormadores();
        string id_area = "";
        public FormApagarArea()
        {
            InitializeComponent();
        }

        private void FormApagarArea_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboArea(ref cmbArea);

            txtArea.ReadOnly = true;

            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja eliminar o registo " + txtArea.Text, "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ligacao.DeleteArea(id_area))
                {
                    MessageBox.Show("Eliminou o registo!");
                    cmbArea.Text = "";
                    //Não é boa prática se tivermos muitos registos. Aí é melhor remover o item em si.
                    cmbArea.Items.Clear();
                    ligacao.PreencherComboArea(ref cmbArea);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Não foi possível apagar o registo!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            cmbArea.Focus();
        }

        void Limpar()
        {
            cmbArea.SelectedIndex = -1;
            cmbArea.Enabled = true;

            txtArea.Text = "";

            btnEliminar.Enabled = false;
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

                    cmbArea.Enabled = false;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Área não encontrada!");
                }
            }
        }
    }
}
