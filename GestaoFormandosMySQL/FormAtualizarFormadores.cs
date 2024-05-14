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
    public partial class FormAtualizarFormadores : Form
    {
        DBConnectFormadores ligacao = new DBConnectFormadores();
        string nifAux = String.Empty;
        public FormAtualizarFormadores()
        {
            InitializeComponent();
        }

        private void FormAtualizarFormadores_Load(object sender, EventArgs e)
        {
            nudID.Focus();
            DesativarControlos();

            ligacao.PreencherComboArea(ref cmbArea);
            btnAtualizar.Enabled = false;

            this.AcceptButton = this.btnPesquisa;

           
            nudID.Select(0, nudID.Value.ToString().Length);
        }

        private void DesativarControlos()
        {
            txtNome.ReadOnly = true;
            mtxtNIF.ReadOnly = true;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            cmbArea.Enabled = false;
        }

        private void AtivarControlos()
        {
            txtNome.ReadOnly = false;
            mtxtNIF.ReadOnly = false;
            mtxtDataNascimento.ReadOnly = false;
            dateTimePicker1.Visible = false;
            cmbArea.Enabled = true;
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

                cmbArea.Text = ligacao.DevolverArea(id_area);

                groupBox3.Enabled = true;
                btnAtualizar.Enabled = true;
                btnAtualizar.Focus();

                AtivarControlos();
            }
            else
            {
                MessageBox.Show("Formador não encontrado!");
                nudID.Value = 0;
                nudID.Focus();
                nudID.Select(0, nudID.Value.ToString().Length);

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string id_area = cmbArea.Text.Substring(
                    cmbArea.Text.LastIndexOf(' ') + 1);
                if (ligacao.Update(nudID.Value.ToString(), txtNome.Text,
                   nifAux, DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"),
                   id_area))
                {
                    MessageBox.Show("Atualizado com sucesso!");
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Erro na atualização do registo!");
                }
            }
        }

        private bool VerificarCampos()
        {
            if (nudID.Value == 0)
            {
                MessageBox.Show("Erro no campo ID!");
                nudID.Focus();
                return false;
            }

            txtNome.Text = Geral.TirarEspacos(txtNome.Text);
            //Geral.TirarEspacos(ref txtNome);
            if (txtNome.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }

            nifAux = mtxtNIF.Text.Replace(" ", "");
            if (nifAux.Length != 0 && nifAux.Length != 9)
            {
                MessageBox.Show("Erro no campo NIF!");
                mtxtNIF.Focus();
                return false;
            }

            if (mtxtDataNascimento.Text.Length != 10 || Geral.CheckDate(mtxtDataNascimento.Text) == false)
            {
                MessageBox.Show("Erro no campo Data Nascimento!");
                mtxtDataNascimento.Focus();
                return false;
            }

            if (cmbArea.SelectedIndex == -1)
            {
                MessageBox.Show("Erro no campo Área!");
                cmbArea.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;

            Limpar();
            DesativarControlos();

            nudID.Focus();
            nudID.Select(0, nudID.Value.ToString().Length);
        }

        void Limpar()
        {
            nudID.Value = 0;
            txtNome.Clear();
            mtxtNIF.Text = string.Empty;
    
            //dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();
            cmbArea.Text = string.Empty;

        }
    }
}
