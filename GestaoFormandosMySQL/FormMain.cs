using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormandosMySQL
{
    public partial class FormMain : Form
    {
        //FormInserirFormandos formInserirFormandos = new FormInserirFormandos();
        //FormApagarFormandos formApagarFormandos = new FormApagarFormandos();
        //FormListarFormandos formListarFormandos = new FormListarFormandos();
        //FormAtualizarFormandos formAtualizarFormandos = new FormAtualizarFormandos();
        //FormInserirNacionalidade formInserirNacionalidade = new FormInserirNacionalidade();
        //FormAtualizarNacionalidade formAtualizarNacionalidade = new FormAtualizarNacionalidade();
        //FormApagarNacionalidade formApagarNacionalidade = new FormApagarNacionalidade();
        //FormListarNacionalidade formListarNacionalidade = new FormListarNacionalidade();
        //FormAutenticacao formAutenticacao = new FormAutenticacao();

        FormInserirFormandos formInserirFormandos;
        FormApagarFormandos formApagarFormandos;
        FormListarFormandos formListarFormandos;
        FormAtualizarFormandos formAtualizarFormandos;
        FormInserirNacionalidade formInserirNacionalidade;
        FormAtualizarNacionalidade formAtualizarNacionalidade;
        FormApagarNacionalidade formApagarNacionalidade;
        FormListarNacionalidade formListarNacionalidade;
        FormAutenticacao formAutenticacao;
        FormExportarDados formExportarDados;
        FormInserirArea formInserirArea;
        FormAtualizarArea formAtualizarArea;
        FormApagarArea formApagarArea;
        FormListarArea formListarArea;
        FormInserirFormadores formInserirFormadores;
        FormAtualizarFormadores formAtualizarFormadores;
        FormApagarFormadores formApagarFormadores;
        FormListarFormadores formListarFormadores;
        public FormMain()
        {
            InitializeComponent();
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formInserirFormandos.IsDisposed)
            {
                formInserirFormandos = new FormInserirFormandos();
            }
            formInserirFormandos.MdiParent = this;
            formInserirFormandos.StartPosition = FormStartPosition.Manual;
            formInserirFormandos.Location = new Point((this.Width - formInserirFormandos.Width) / 2,
                (this.Height - formInserirFormandos.Height) / 3);
            //formInserirFormandos.StartPosition = FormStartPosition.CenterScreen;
            formInserirFormandos.Show();
            formInserirFormandos.Activate();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (formApagarFormandos.IsDisposed)
            {
                formApagarFormandos = new FormApagarFormandos();
            }
            formApagarFormandos.MdiParent = this;
            formApagarFormandos.StartPosition = FormStartPosition.Manual;
            formApagarFormandos.Location = new Point((this.Width - formApagarFormandos.Width) / 2,
                (this.Height - formApagarFormandos.Height) / 3);
            formApagarFormandos.Show();
            formApagarFormandos.Activate();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formListarFormandos.IsDisposed)
            {
                formListarFormandos = new FormListarFormandos();
            }
            formListarFormandos.MdiParent = this;
            formListarFormandos.StartPosition = FormStartPosition.Manual;
            formListarFormandos.Location = new Point((this.Width - formListarFormandos.Width) / 2,
                (this.Height - formListarFormandos.Height) / 3);
            formListarFormandos.Show();
            formListarFormandos.Activate();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formAtualizarFormandos.IsDisposed)
            {
                formAtualizarFormandos = new FormAtualizarFormandos();
            }
            formAtualizarFormandos.MdiParent = this;
            formAtualizarFormandos.StartPosition = FormStartPosition.Manual;
            formAtualizarFormandos.Location = new Point((this.Width - formAtualizarFormandos.Width) / 2,
                (this.Height - formAtualizarFormandos.Height) / 3);
            //formAtualizarFormandos.StartPosition = FormStartPosition.CenterScreen;
            formAtualizarFormandos.Show();
            formAtualizarFormandos.Activate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (VerificarFicheiro())
            {
                LerFicheiro();
            }

            toolStripLabelUser.Text = "";
            toolStripButtonLogOut.Enabled = false;
            toolStripButtonLogOut.Visible = false;
            formAutenticacao = new FormAutenticacao();
            formAutenticacao.ShowDialog();
            toolStripLabelUser.Text = "Perfil: " + formAutenticacao.userName;
            toolStripButtonLogOut.Enabled = true;
            toolStripButtonLogOut.Visible = true;

            formInserirFormandos = new FormInserirFormandos();
            formAtualizarFormandos = new FormAtualizarFormandos();
            formApagarFormandos = new FormApagarFormandos();
            formListarFormandos = new FormListarFormandos();

            formInserirNacionalidade = new FormInserirNacionalidade();
            formAtualizarNacionalidade = new FormAtualizarNacionalidade();
            formApagarNacionalidade = new FormApagarNacionalidade();
            formListarNacionalidade = new FormListarNacionalidade();    

            formExportarDados = new FormExportarDados();

            formInserirArea = new FormInserirArea();
            formAtualizarArea = new FormAtualizarArea();
            formApagarArea = new FormApagarArea();
            formListarArea = new FormListarArea();

            formInserirFormadores = new FormInserirFormadores();
            formAtualizarFormadores = new FormAtualizarFormadores();
            formApagarFormadores = new FormApagarFormadores();
            formListarFormadores = new FormListarFormadores();
        }

        private void inserirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formInserirNacionalidade.IsDisposed)
            {
                formInserirNacionalidade = new FormInserirNacionalidade();
            }
            formInserirNacionalidade.MdiParent = this;
            formInserirNacionalidade.StartPosition = FormStartPosition.Manual;
            formInserirNacionalidade.Location = new Point((this.Width - formInserirNacionalidade.Width) / 2,
                (this.Height - formInserirNacionalidade.Height) / 3);
            formInserirNacionalidade.Show();
            formInserirNacionalidade.Activate();
        }

        private void atualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formAtualizarNacionalidade.IsDisposed)
            {
                formAtualizarNacionalidade = new FormAtualizarNacionalidade();
            }
            formAtualizarNacionalidade.MdiParent = this;
            formAtualizarNacionalidade.StartPosition = FormStartPosition.Manual;
            formAtualizarNacionalidade.Location = new Point((this.Width - formAtualizarNacionalidade.Width) / 2,
                (this.Height - formAtualizarNacionalidade.Height) / 3);
            formAtualizarNacionalidade.Show();
            formAtualizarNacionalidade.Activate();
        }

        private void apagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formApagarNacionalidade.IsDisposed)
            {
                formApagarNacionalidade = new FormApagarNacionalidade();
            }
            formApagarNacionalidade.MdiParent = this;
            formApagarNacionalidade.StartPosition = FormStartPosition.Manual;
            formApagarNacionalidade.Location = new Point((this.Width - formApagarNacionalidade.Width) / 2,
                (this.Height - formApagarNacionalidade.Height) / 3);
            formApagarNacionalidade.Show();
            formApagarNacionalidade.Activate();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formListarNacionalidade.IsDisposed)
            {
                formListarNacionalidade = new FormListarNacionalidade();
            }
            formListarNacionalidade.MdiParent = this;
            formListarNacionalidade.StartPosition = FormStartPosition.Manual;
            formListarNacionalidade.Location = new Point((this.Width - formListarNacionalidade.Width) / 2,
                (this.Height - formListarNacionalidade.Height) / 3);
            formListarNacionalidade.Show();
            formListarNacionalidade.Activate();
        }

        private void toolStripButtonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja terminar sessão?\nTodas as janelas serão encerradas.", "Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Dispose();
                    frm.Close();
                }

                toolStripLabelUser.Text = "";
                toolStripButtonLogOut.Enabled = false;
                toolStripButtonLogOut.Visible = false;
                formAutenticacao.ShowDialog();
                toolStripLabelUser.Text = "Perfil: " + formAutenticacao.userName;
                toolStripButtonLogOut.Enabled = true;   
            }
        }
        private bool VerificarFicheiro()
        {
            bool flag = true;

            string path = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            try
            {
                if (!File.Exists(path))
                {
                    // Vamos gravar os dados do servidor e a porta
                    FormConfig formConfig = new FormConfig();
                    DialogResult result = formConfig.ShowDialog();
                    if (result == DialogResult.OK) 
                    {
                        // Criar o ficheiro para escrita
                        using (StreamWriter sw = File.CreateText(path)) 
                        {
                            sw.WriteLine(formConfig.mtxtIP.Text.Replace(",", "."));
                            sw.WriteLine(formConfig.mtxtPorta.Text);
                            //sw.WriteLine(formConfig.txtUsername.Text);
                            //sw.WriteLine(formConfig.txtPassword.Text);
                            //sw.WriteLine(formConfig.txtDatabase.Text);
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                //else
                //{
                //    MessageBox.Show("Já existe o ficheiro!");
                //}
               
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        // Método da leitura do ficheiro
        private bool LerFicheiro() 
        { 
            bool flag = true;
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            string[] dados = new string[2];

            try
            {
                if (File.Exists(path))
                {
                    // Utilizar o StreamReader para ler os dados do ficheiro linha a linha
                    using (StreamReader file = new StreamReader(path))
                    {
                        int counter = 0;
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            dados[counter++] = ln;
                        }
                        file.Close();
                        //MessageBox.Show("Leu " + counter + " linhas!");
                    }
                }
                // buscar o valor do array dados para a aplicação
                //MessageBox.Show("IP: " + dados[0]);
                //MessageBox.Show("Porta: " + dados[1]);
                //Geral.ipserver = dados[0];

                string[] octectos = dados[0].Split('.');
                int i = 0;
                for (i = 0; i < octectos.Length - 1; i++)
                {
                    Geral.ipserver = Geral.ipserver + int.Parse(octectos[i]) + ".";
                }
                Geral.ipserver = Geral.ipserver + int.Parse(octectos[i]);

                Geral.portaserver = dados[1];
                //Geral.username = dados[2];
                //Geral.password = dados[3];
                //Geral.database = dados[4];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nErro na leitura do ficheiro de configuração!");
                flag = false;
            }

            return flag;
        }

        private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formExportarDados.IsDisposed)
            {
                formExportarDados = new FormExportarDados();
            }
            formExportarDados.MdiParent = this;
            formExportarDados.StartPosition = FormStartPosition.Manual;
            formExportarDados.Location = new Point((this.Width - formExportarDados.Width) / 2,
                (this.Height - formExportarDados.Height) / 3);
            formExportarDados.Show();
            formExportarDados.Activate();
        }

        private void inserirToolStripMenuArea_Click(object sender, EventArgs e)
        {
            if (formInserirArea.IsDisposed)
            {
                formInserirArea = new FormInserirArea();
            }
            formInserirArea.MdiParent = this;
            formInserirArea.StartPosition = FormStartPosition.Manual;
            formInserirArea.Location = new Point((this.Width - formInserirArea.Width) / 2,
                (this.Height - formInserirArea.Height) / 3);
            formInserirArea.Show();
            formInserirArea.Activate();
        }

        private void atualizarToolStripMenuArea_Click(object sender, EventArgs e)
        {
            if (formAtualizarArea.IsDisposed)
            {
                formAtualizarArea = new FormAtualizarArea();
            }
            formAtualizarArea.MdiParent = this;
            formAtualizarArea.StartPosition = FormStartPosition.Manual;
            formAtualizarArea.Location = new Point((this.Width - formAtualizarArea.Width) / 2,
                (this.Height - formAtualizarArea.Height) / 3);
            formAtualizarArea.Show();
            formAtualizarArea.Activate();
        }

        private void apagarToolStripMenuArea_Click(object sender, EventArgs e)
        {
            if (formApagarArea.IsDisposed)
            {
                formApagarArea = new FormApagarArea();
            }
            formApagarArea.MdiParent = this;
            formApagarArea.StartPosition = FormStartPosition.Manual;
            formApagarArea.Location = new Point((this.Width - formApagarArea.Width) / 2,
                (this.Height - formApagarArea.Height) / 3);
            formApagarArea.Show();
            formApagarArea.Activate();
        }

        private void listarToolStripMenuArea_Click(object sender, EventArgs e)
        {
            if (formListarArea.IsDisposed)
            {
                formListarArea = new FormListarArea();
            }
            formListarArea.MdiParent = this;
            formListarArea.StartPosition = FormStartPosition.Manual;
            formListarArea.Location = new Point((this.Width - formListarArea.Width) / 2,
                (this.Height - formListarArea.Height) / 3);
            formListarArea.Show();
            formListarArea.Activate();
        }

        private void inserirToolStripMenuFormador_Click(object sender, EventArgs e)
        {
            if (formInserirFormadores.IsDisposed)
            {
                formInserirFormadores = new FormInserirFormadores();
            }
            formInserirFormadores.MdiParent = this;
            formInserirFormadores.StartPosition = FormStartPosition.Manual;
            formInserirFormadores.Location = new Point((this.Width - formInserirFormadores.Width) / 2,
                (this.Height - formInserirFormadores.Height) / 3);
            formInserirFormadores.Show();
            formInserirFormadores.Activate();
        }

        private void atualizarToolStripMenuFormador_Click(object sender, EventArgs e)
        {
            if (formAtualizarFormadores.IsDisposed)
            {
                formAtualizarFormadores = new FormAtualizarFormadores();
            }
            formAtualizarFormadores.MdiParent = this;
            formAtualizarFormadores.StartPosition = FormStartPosition.Manual;
            formAtualizarFormadores.Location = new Point((this.Width - formAtualizarFormadores.Width) / 2,
                (this.Height - formAtualizarFormadores.Height) / 3);
            formAtualizarFormadores.Show();
            formAtualizarFormadores.Activate();
        }

        private void apagarToolStripMenuFormador_Click(object sender, EventArgs e)
        {
            if (formApagarFormadores.IsDisposed)
            {
                formApagarFormadores = new FormApagarFormadores();
            }
            formApagarFormadores.MdiParent = this;
            formApagarFormadores.StartPosition = FormStartPosition.Manual;
            formApagarFormadores.Location = new Point((this.Width - formApagarFormadores.Width) / 2,
                (this.Height - formApagarFormadores.Height) / 3);
            formApagarFormadores.Show();
            formApagarFormadores.Activate();
        }

        private void listarToolStripMenuFormador_Click(object sender, EventArgs e)
        {
            if (formListarFormadores.IsDisposed)
            {
                formListarFormadores = new FormListarFormadores();
            }
            formListarFormadores.MdiParent = this;
            formListarFormadores.StartPosition = FormStartPosition.Manual;
            formListarFormadores.Location = new Point((this.Width - formListarFormadores.Width) / 2,
                (this.Height - formListarFormadores.Height) / 3);
            formListarFormadores.Show();
            formListarFormadores.Activate();
        }
    }
}
