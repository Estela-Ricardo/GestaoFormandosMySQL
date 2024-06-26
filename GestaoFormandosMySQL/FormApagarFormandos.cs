﻿using System;
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
    public partial class FormApagarFormandos : Form
    {
        DBConnect conn = new DBConnect();

        public FormApagarFormandos()
        {
            InitializeComponent();
            nudID.Enter += NudID_Enter;
        }
        private void NudID_Enter(object sender, EventArgs e)
        {
            if ( nudID.Value == 0)
            {
                LimparNudID();
            }
        }
        private void LimparNudID()
        {
            nudID.Value = 0;
            nudID.Select(0, nudID.Text.Length);
        }
        private void FormApagarFormandos_Load(object sender, EventArgs e)
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
            txtNacionalidade.ReadOnly = true;

            btnEliminar.Enabled = false;

            this.AcceptButton = this.btnPesquisa;

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", data_nascimento = "", id_nacionalidade = "";
            char genero = ' ';

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
                txtNacionalidade.Text = conn.DevolverNacionalidade(id_nacionalidade);

                groupBox3.Enabled = false;
                btnEliminar.Enabled = true;
                btnEliminar.Focus();
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
                LimparNudID();
                nudID.Focus();
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
            LimparNudID();
            txtNome.Text = string.Empty;
            txtMorada.Text = "";
            mtxtContacto.Clear();
            mtxtIBAN.Text = string.Empty;
            mtxtDataNascimento.Clear();
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            txtNacionalidade.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja eliminar o registo ID " + nudID.Value.ToString(), "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            { 
                if (conn.Delete(nudID.Value.ToString()))
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
    }
}
