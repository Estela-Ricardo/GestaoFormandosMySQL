//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace GestaoFormandosMySQL
{
    internal class DBConnect
    {
        private OdbcConnection connection;
        //private string server;
        //private string username;
        //private string password;
        //private string database;
        //private string port;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            //server = Geral.ipserver;
            //username = Geral.username;
            //password = Geral.password;
            //database = Geral.database;
            //port = Geral.portaserver;

            string connectionString = "DSN=GestaoFormandos";
                //"Server=" + server + ";Port=" + port + ";Database=" + database +
                //";Uid=" + username + ";Pwd=" + password + ";";

            connection = new OdbcConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string StatusConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else
                {
                    connection.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connection.State.ToString();
        }

        public int Count()
        {
            int count = -1;
            string query = "select count(*) from formando";
            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return count;
        }

        public int DevolveUltimoID()
        {
            int ultimoID = 2;
            string query = "select max(id_formando) from formando;";

            try
            {
                if (OpenConnection())
                {
                    ultimoID = 2;
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    //ultimoID = int.Parse(cmd.ExecuteScalar().ToString());
                    int.TryParse(cmd.ExecuteScalar().ToString(), out ultimoID);
                    ultimoID++;
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ultimoID;
        }

        public bool Insert(string id, string nome, string morada, string contacto, string iban,
            char genero, string data_nascimento, string id_nacionalidade)
        {
            string query = "insert into formando  (id_formando, nome, morada, contacto, iban, genero, data_nascimento, id_nacionalidade) values" +
                "('" + id + "','" + nome + "','" + morada + "','" + contacto + "','" + iban + "','" +
                genero + "','" + data_nascimento + "'," + id_nacionalidade + ");";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool Update(string id, string nome, string morada, string contacto, string iban,
            char genero, string data_nascimento, string id_nacionalidade)
        {
            string query = "update formando set nome = '" + nome + "', morada = '" + morada + "', contacto = '" +
                contacto + "', iban = '" + iban + "', genero = '" + genero + "', data_nascimento = '" +
                data_nascimento + "', id_nacionalidade = '" + id_nacionalidade + "' where id_formando = " + id;

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool PesquisaFormando(string id_pesquisa, ref string nome, ref string morada, ref string contacto,
            ref string iban, ref char sexo, ref string data_nascimento, ref string id_nacionalidade)
        {
            bool flag = false;

            string query = "select nome, morada, contacto, iban, genero, data_nascimento, id_nacionalidade from formando " +
                "where id_formando = '" + id_pesquisa + "';";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        nome = dataReader.GetString(0);
                        morada = dataReader[1].ToString();
                        contacto = dataReader["contacto"].ToString();
                        iban = dataReader[3].ToString();
                        sexo = dataReader["genero"].ToString()[0];
                        data_nascimento = dataReader[5].ToString();
                        id_nacionalidade = dataReader[6].ToString();
                        flag = true;
                    }
                    dataReader.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool Delete(string id)
        {
            bool flag = true;

            string query = "delete from formando where id_formando = '" + id + "';";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }
        public void PreencherDataGridViewFormando(ref DataGridView dgv)
        {
            string query = "select * from vFormandoNacionalidade order by nome;";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Nome"].Value = dr["nome"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[idxLinha].Cells[3].Value = dr["contacto"].ToString();
                        dgv.Rows[idxLinha].Cells["Genero"].Value = dr["genero"].ToString();
                        dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr["nacionalidade"].ToString();
                        idxLinha++;
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void PreencherDataGridViewFormando(ref DataGridView dgv, char genero, string nome, string id_nacionalidade)
        {
            string query = "select * from vFormandoNacionalidade ";

            if (nome.Length > 0 || genero == 'T')
            {
                query = query + " where nome like '%" + nome + "%' ";

                if (id_nacionalidade.Length > 0)
                {
                    query = query + " and id_nacionalidade = '" + id_nacionalidade + "' ";
                }

                if (genero != 'T' && genero != ' ')
                {
                    query = query + " and genero = '" + genero + "';";

                }

            }
            else
            {
                if (id_nacionalidade.Length > 0)
                {
                    query = query + "where id_nacionalidade = '" + id_nacionalidade + "' " +
                        " and genero = '" + genero + "';";
                }
                query = query + " where genero = '" + genero + "';";
            }
            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Nome"].Value = dr["nome"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[idxLinha].Cells[3].Value = dr["contacto"].ToString();
                        dgv.Rows[idxLinha].Cells["Genero"].Value = dr["genero"].ToString();
                        dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr["nacionalidade"].ToString();
                        idxLinha++;
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool InsertNacionalidade(string iso2, string nacionalidade)
        {
            string query = "insert into Nacionalidade (id_nacionalidade, alf2, nacionalidade) values" +
                "(0,'" + iso2 + "','" + nacionalidade + "')";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool DeleteNacionalidade(string id_nacionalidade)
        {
            bool flag = true;

            string query = "delete from nacionalidade where id_nacionalidade = '" + id_nacionalidade + "';";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public void PreencherComboNacionalidade(ref ComboBox combo)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from " +
                "nacionalidade order by nacionalidade;";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        combo.Items.Add(dr[2].ToString() + " - " + dr["alf2"].ToString() +
                            " - " + dr[0].ToString());
                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public string DevolverNacionalidade(string id_nacionalidade)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from " +
                "nacionalidade where id_nacionalidade = '" + id_nacionalidade + "';";

            string nacionalidade = "";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nacionalidade = dr[2].ToString() + " - " + dr["alf2"].ToString() +
                            " - " + dr[0].ToString();
                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return nacionalidade;
        }

        public bool PesquisaNacionalidade(string id_nacionalidade, ref string alf2, ref string nacionalidade)
        {
            bool flag = false;
            string query = "select id_nacionalidade, alf2, nacionalidade from " +
                "nacionalidade where id_nacionalidade = " + id_nacionalidade + ";";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        alf2 = dr["alf2"].ToString();
                        nacionalidade = dr[2].ToString();
                        flag = true;
                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }
        public bool UpdateNacionalidade(string id, string alf2, string nacionalidade)
        {
            string query = "update nacionalidade set alf2 = '" + alf2 + "', nacionalidade = '" + nacionalidade +
                "' where id_nacionalidade = " + id;
            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool ValidateUser(string userName, string passWord, ref string id_user)
        {
            bool flag = false;

            try
            {
                string query = "select userRole from users where binary uname = '" + userName + "' and pwd = " +
                    "sha2('" + passWord + "',512);";

                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    if (cmd.ExecuteScalar() != null)
                    {
                        id_user = cmd.ExecuteScalar().ToString();
                        flag = true;
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }
        public void PreencherDGVNacionalidade(ref DataGridView dgv)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from nacionalidade order by nacionalidade;";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["alf2"].Value = dr["alf2"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        idxLinha++;
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ValidateUser2(string userName, string passWord, ref string id_user)
        {
            bool flag = false;

            try
            {
                string query = "select nome_utilizador from utilizador where binary nome_utilizador = '" + userName + "' and palavra_passe = " +
                    "sha2('" + passWord + "',512) and estado = 'A';";

                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    if (cmd.ExecuteScalar() != null)
                    {
                        id_user = cmd.ExecuteScalar().ToString();
                        flag = true;
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
                if (flag)
                {
                    PUSuccessLogin(userName, "S");
                }
                else
                {
                    PUSuccessLogin(userName, "U");
                }
            }
            return flag;
        }

        private void PUSuccessLogin(string userName, string result)
        {
            try
            {
                string query = "call pUSuccessLogin('" + userName + "', '" + result + "');";
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ValidateUsersStatus(string userName, ref int nfalhas)
        {
            bool flag = false;

            try
            {
                string query = "select falhas from utilizador where nome_utilizador = '" + userName + "' and estado = 'I';";
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    if (cmd.ExecuteScalar() != null)
                    {
                        nfalhas = int.Parse(cmd.ExecuteScalar().ToString());
                        flag = true;
                    }
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public void PreencherComboTabelas(ref ComboBox combo)
        {
            string query = "show tables;";

            combo.Items.Add("---");

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        combo.Items.Add(dr[0].ToString());
                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void PreencherChkLsColunasTabela(ref CheckedListBox chkLstBox, string tabela)
        {
            string query = "show columns from " + tabela + ";";

            chkLstBox.Items.Clear();


            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        chkLstBox.Items.Add(dr[0].ToString());
                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void PreencherComboColunasTabela(ref ComboBox combo, string tabela)
        {
            string query = "show columns from " + tabela + ";";

            combo.Items.Clear();
            combo.Items.Add("");

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        combo.Items.Add(dr[0].ToString());
                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void ExportarRegistosTextBox(ref TextBox txtDados, string[] coluna, string tabela, string filtro = "")
        {
            string query = "select ";

            txtDados.Clear();
            for (int i = 0; i < coluna.Length; i++)
            {
                txtDados.Text = txtDados.Text + coluna[i].ToString() + ";";
                query = query + "`" + coluna[i] + "`" + ",";
            }
            query = query.Substring(0, query.Length - 1);
            query = query + " from " + tabela;

            if (filtro != "")
            {
                query = query + " where " + filtro;
            }

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtDados.Text = txtDados.Text + "\r\n";

                        //chkLstBox.Items.Add(dr[0].ToString());
                        for (int i = 0; i < coluna.Length;i++)
                        {
                            txtDados.Text = txtDados.Text + dr[i].ToString() + ";";
                        }

                    }
                    dr.Close();
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
