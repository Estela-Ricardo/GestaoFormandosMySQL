using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormandosMySQL
{
    public partial class FormAtualizarFormandos : Form
    {
        DBConnect conn = new DBConnect();
        string contactoAux = String.Empty;
        public FormAtualizarFormandos()
        {
            InitializeComponent();
        }

        private void FormAtualizarFormandos_Load(object sender, EventArgs e)
        {
            DesativarControlos();

            conn.PreencherComboNacionalidade(ref cmbNacionalidade);
            btnAtualizar.Enabled = false;

            this.AcceptButton = this.btnPesquisa;

            nudID.Focus();
            nudID.Select(0, nudID.Value.ToString().Length);
        }

        private void DesativarControlos()
        {
            txtNome.ReadOnly = true;
            txtMorada.ReadOnly = true;
            mtxtContacto.ReadOnly = true;
            mtxtIBAN.ReadOnly = true;
            rbFeminino.Enabled = false;
            rbMasculino.Enabled = false;
            rbOutro.Enabled = false;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
            cmbNacionalidade.Enabled = false;
        }

        private void AtivarControlos()
        {
            txtNome.ReadOnly = false;
            txtMorada.ReadOnly = false;
            mtxtContacto.ReadOnly = false;
            mtxtIBAN.ReadOnly = false;
            rbFeminino.Enabled = true;
            rbMasculino.Enabled = true;
            rbOutro.Enabled = true;
            mtxtDataNascimento.ReadOnly = false;
            dateTimePicker1.Visible = false;
            cmbNacionalidade.Enabled = true;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", data_nascimento = "", id_nacionalidade = "";
            char genero = ' ' ;

            if (conn.PesquisaFormando(nudID.Value.ToString(), ref nome, ref morada, ref contacto, ref iban, ref genero,
                ref data_nascimento, ref id_nacionalidade))
            {
                txtNome.Text = nome;
                txtMorada.Text = morada;
                mtxtContacto.Text = contacto;
                mtxtIBAN.Text = iban;
                if (genero == 'F')
                {
                    rbFeminino.Checked = true;
                }
                else if (genero == 'M')
                {
                    rbMasculino.Checked = true;
                }
                else if (genero == 'O')
                {
                    rbOutro.Checked = true;
                }
                mtxtDataNascimento.Text = data_nascimento;

                cmbNacionalidade.Text = conn.DevolverNacionalidade(id_nacionalidade);
               
                groupBox3.Enabled = true;
                btnAtualizar.Enabled = true;
                btnAtualizar.Focus();

                AtivarControlos();
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
                nudID.Value = 0;
                nudID.Focus();
                nudID.Select(0, nudID.Value.ToString().Length);

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string id_nacionalidade = cmbNacionalidade.Text.Substring(
                    cmbNacionalidade.Text.LastIndexOf(' ') + 1);
                if (conn.Update(nudID.Value.ToString(), txtNome.Text, txtMorada.Text,
                   contactoAux, mtxtIBAN.Text, Genero(), DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"), id_nacionalidade))
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

            txtMorada.Text = Geral.TirarEspacos(txtMorada.Text);
            if (txtMorada.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Morada!");
                txtMorada.Focus();
                return false;
            }

            contactoAux = mtxtContacto.Text.Replace(" ", "");
            if (contactoAux.Length != 0 && contactoAux.Length != 9)
            {
                MessageBox.Show("Erro no campo Contacto!");
                mtxtContacto.Focus();
                return false;
            }

            if (mtxtIBAN.Text.Length < 25)
            {
                MessageBox.Show("Erro no campo IBAN!");
                mtxtIBAN.Focus();
                return false;
            }

            if (Genero() == 'T')
            {
                MessageBox.Show("Erro no campo Género!");
                rbFeminino.Focus();
                return false;
            }

            if (mtxtDataNascimento.Text.Length != 10 || Geral.CheckDate(mtxtDataNascimento.Text) == false)
            {
                MessageBox.Show("Erro no campo Data Nascimento!");
                mtxtDataNascimento.Focus();
                return false;
            }

            if (cmbNacionalidade.SelectedIndex == -1) 
            {
                MessageBox.Show("Erro no campo Nacionalidade!");
                cmbNacionalidade.Focus();
                return false;
            }

            return true;
        }

        private char Genero()
        {
            char genero = 'T';
            if (rbFeminino.Checked)
            {
                genero = 'F';
            }
            else if (rbMasculino.Checked)
            {
                genero = 'M';
            }
            else if (rbOutro.Checked)
            {
                genero = 'O';
            }
            return genero;
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
            txtMorada.Text = "";
            mtxtContacto.Text = "";
            mtxtIBAN.Text = string.Empty;
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;

            //dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();
            cmbNacionalidade.Text = string.Empty;

        }
    }
}
