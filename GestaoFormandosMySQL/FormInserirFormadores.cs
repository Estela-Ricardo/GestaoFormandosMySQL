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
    public partial class FormInserirFormadores : Form
    {
        DBConnectFormadores ligacao = new DBConnectFormadores();

        string nifAux = "";
        public FormInserirFormadores()
        {
            InitializeComponent();
        }

        private void FormInserirFormadores_Load(object sender, EventArgs e)
        {
            nudID.Value = ligacao.DevolveUltimoID();
            ligacao.PreencherComboArea(ref cmbArea);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string id_area = cmbArea.Text.Substring(
                    cmbArea.Text.LastIndexOf(' ') + 1);

                if (ligacao.InsertFormador(nudID.Value.ToString(), txtNome.Text,nifAux, 
                    DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd"), 
                    id_area))
                {
                    MessageBox.Show("Gravado com sucesso!");
                    Limpar();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Erro na gravação do registo!");
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
            if (txtNome.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }

            nifAux = mtxtNIF.Text.Replace(" ", "");
            if (nifAux.Length != 0 && nifAux.Length != 9)
            {
                MessageBox.Show("Erro no campo Contacto!");
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
            Close();
        }

        void Limpar()
        {
            nudID.Value = ligacao.DevolveUltimoID();
            txtNome.Clear();
            mtxtNIF.Text = "";

            dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();

            cmbArea.Text = string.Empty;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mtxtDataNascimento.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void mtxtDataNascimento_TextChanged(object sender, EventArgs e)
        {
            int dia, mes, ano;
            string textoData;
            DateTime data;

            if (mtxtDataNascimento.MaskCompleted)
            {
                textoData = mtxtDataNascimento.Text;
                dia = int.Parse(textoData.Substring(0, 2));
                mes = int.Parse(textoData.Substring(3, 2));
                ano = int.Parse(textoData.Substring(6));

                try
                {
                    data = DateTime.Parse(dia + "-" + mes + "-" + ano);
                    dateTimePicker1.Value = data;
                }
                catch
                {
                    MessageBox.Show("Data incorrecta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtDataNascimento.Focus();
                }
            }
        }
    }
}
