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
    public partial class FormAtualizarNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        string id_nacionalidade = string.Empty;
        public FormAtualizarNacionalidade()
        {
            InitializeComponent();
        }

        private void FormAtualizarNacionalidade_Load(object sender, EventArgs e)
        {
            ligacao.PreencherComboNacionalidade(ref cmbNacionalidade);

            txtAlf2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;

            btnAtualizar.Enabled = false;
        }

        private void cmbNacionalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            string alf2 = "", nacionalidade = "";
            if (cmbNacionalidade.SelectedIndex != -1)
            {
                //MessageBox.Show(cmbNacionalidade.Text);
                id_nacionalidade = cmbNacionalidade.Text.Substring(
                    cmbNacionalidade.Text.LastIndexOf(' ') + 1);
                //MessageBox.Show(id_nacionalidade);
                if (ligacao.PesquisaNacionalidade(id_nacionalidade, ref alf2, ref nacionalidade))
                {
                    txtAlf2.Text = alf2;
                    txtNacionalidade.Text = nacionalidade;

                    txtAlf2.ReadOnly = false;
                    txtNacionalidade.ReadOnly = false;

                    cmbNacionalidade.Enabled = false;
                    btnAtualizar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Nacionalidade não encontrada!");
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                if (ligacao.UpdateNacionalidade(id_nacionalidade, txtAlf2.Text, txtNacionalidade.Text))
                {
                    MessageBox.Show("Atualizado com sucesso!");
                    cmbNacionalidade.Items.Clear();
                    ligacao.PreencherComboNacionalidade(ref cmbNacionalidade);
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

            txtAlf2.Text = Geral.TirarEspacos(txtAlf2.Text);
            if (txtAlf2.Text.Length != 2)
            {
                MessageBox.Show("Erro no campo ISO2!\nInsira 2 caracteres para o ISO2");
                txtAlf2.Focus();
                return false;
            }

            txtNacionalidade.Text = Geral.TirarEspacos(txtNacionalidade.Text);
            if (txtNacionalidade.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo Nacionalidade!");
                txtNacionalidade.Focus();
                return false;
            }

            return true;
        }
        void LimparCampos()
        {
            txtAlf2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;

            txtAlf2.Clear();
            txtNacionalidade.Clear();

            cmbNacionalidade.Enabled = true;
            btnAtualizar.Enabled = false;

            cmbNacionalidade.Text = "";
            cmbNacionalidade.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
