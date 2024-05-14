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
    public partial class FormInserirNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormInserirNacionalidade()
        {
            InitializeComponent();
        }

        private void FormInserirNacionalidade_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGravar;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                if (ligacao.InsertNacionalidade(txtISO2.Text, txtNacionalidade.Text))
                {
                    MessageBox.Show("Gravado com sucesso!");
                    LimparCampos();
                    txtISO2.Focus();
                }
                else
                {
                    MessageBox.Show("Erro na gravação do registo!");
                }
            }
        }
        private bool VerificarCampos()
        {

            txtISO2.Text = Geral.TirarEspacos(txtISO2.Text);
            if (txtISO2.Text.Length != 2)
            {
                MessageBox.Show("Erro no campo ISO2!\nInsira 2 caracteres para o ISO2");
                txtISO2.Focus();
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
            txtISO2.Clear();
            txtNacionalidade.Clear();
            txtISO2.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
