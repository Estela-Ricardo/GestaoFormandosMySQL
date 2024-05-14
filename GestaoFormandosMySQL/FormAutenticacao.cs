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
    public partial class FormAutenticacao : Form
    {
        DBConnect ligacao = new DBConnect();
        public string userName = "";
        public FormAutenticacao()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int nfalhas = 0;
            if (ligacao.ValidateUsersStatus(txtUser.Text, ref nfalhas))
            {
                MessageBox.Show("Utilizador bloqueado!\nNº Falhas de autenticação: " + nfalhas + "\nContacte o Administrador do Sistema.");
                return;
            }

            //if (txtUser.Text == "Login" && txtPW.Text == "1234")
            if(ligacao.ValidateUser2(txtUser.Text, txtPW.Text, ref userName))
            {
                DialogResult = DialogResult.OK;
                txtUser.Focus();
            }
            else
            {
                MessageBox.Show("Erro na autenticação!");
            }
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            //AcceptButton = btnLogin;
            txtUser.Text = "";
            txtPW.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPW.Focus();
                e.Handled = true; // Remove o som de alerta
            }
        }
        // ALTERNATIVA PARA SUPRIMIR SOM ALERTA NO ENTER
        //private void txtUser_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPW.Focus();
        //        e.SuppressKeyPress = true; // Remove o som de alerta
        //    }
        //}

        private void txtPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true; // Remove o som de alerta 
            }
        }
    }
}
