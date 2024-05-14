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
    public partial class FormInserirArea : Form
    {
        DBConnectFormadores ligacao = new DBConnectFormadores();
        public FormInserirArea()
        {
            InitializeComponent();
        }

        private void FormInserirArea_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGravar;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                if (ligacao.InsertArea(txtArea.Text))
                {
                    MessageBox.Show("Gravado com sucesso!");
                    txtArea.Clear();
                    txtArea.Focus();
                }
                else
                {
                    MessageBox.Show("Erro na gravação do registo!");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
