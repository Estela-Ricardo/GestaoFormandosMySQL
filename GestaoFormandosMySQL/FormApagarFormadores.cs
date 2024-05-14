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
    public partial class FormApagarFormadores : Form
    {
        DBConnectFormadores ligacao = new DBConnectFormadores();
        public FormApagarFormadores()
        {
            InitializeComponent();
        }

        private void FormApagarFormadores_Load(object sender, EventArgs e)
        {
            nudID.Focus();

            this.AcceptButton = this.btnPesquisa;

            nudID.Select(0, nudID.Value.ToString().Length);

            txtNome.ReadOnly = true;
            mtxtNIF.ReadOnly = true;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            txtArea.ReadOnly = true;

            btnEliminar.Enabled = false;
        }
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", nif = "", data_nascimento = "", id_area = "";

            if (ligacao.PesquisaFormador(nudID.Value.ToString(), ref nome, ref nif,
                ref data_nascimento, ref id_area))
            {
                txtNome.Text = nome;
                mtxtNIF.Text = nif;
                mtxtDataNascimento.Text = data_nascimento;
                txtArea.Text = ligacao.DevolverArea(id_area);

                groupBox3.Enabled = false;
                btnEliminar.Enabled = true;
                btnEliminar.Focus();
            }
            else
            {
                MessageBox.Show("Formador não encontrado!");
                nudID.Select(0, nudID.Value.ToString().Length);
                nudID.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja eliminar o registo ID " + nudID.Value.ToString(), "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ligacao.Delete(nudID.Value.ToString()))
                {
                    MessageBox.Show("Registo apagado!");
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Não foi possível apagar o registo!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            nudID.Focus();
            Limpar();
        }

        void Limpar()
        {
            nudID.Select(0, nudID.Value.ToString().Length);
            txtNome.Text = string.Empty;
            mtxtNIF.Clear();
            mtxtDataNascimento.Clear();
            txtArea.Text = "";
        }
    }
}
