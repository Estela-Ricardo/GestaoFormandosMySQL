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
    internal class DBConnectFormadores
    {
        private OdbcConnection connection;
       

        public DBConnectFormadores()
        {
            Initialize();
        }

        private void Initialize()
        {
            string connectionString = "DSN=GestaoFormandos";

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

        public bool InsertArea(string area)
        {
            string query = "insert into area (id_area, area) values" +
                "(0,'" + area + "')";

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

        public void PreencherComboArea(ref ComboBox combo)
        {
            string query = "select id_area, area from " +
                "area order by id_area;";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        combo.Items.Add(dr[1].ToString() + " - " + dr[0].ToString());
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

        public bool PesquisaArea(string id_area, ref string area)
        {
            bool flag = false;
            string query = "select id_area, area from " +
                "area where id_area = " + id_area + ";";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        area = dr["area"].ToString();
                        id_area = dr["id_area"].ToString();
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

        public bool UpdateArea(string id, string area)
        {
            string query = "update area set area = '" + area +
                "' where id_area = " + id;
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
        public bool DeleteArea(string id_area)
        {
            bool flag = true;

            string query = "delete from area where id_area = '" + id_area + "';";

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

        public void PreencherDGVArea(ref DataGridView dgv)
        {
            string query = "select id_area, area from area order by id_area;";

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
                        dgv.Rows[idxLinha].Cells["id_area"].Value = dr["id_area"].ToString();
                        dgv.Rows[idxLinha].Cells["area"].Value = dr["area"].ToString();
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

        public int DevolveUltimoID()
        {
            int ultimoID = 2;
            string query = "select max(id_formador) from formador;";

            try
            {
                if (OpenConnection())
                {
                    ultimoID = 2;
                    OdbcCommand cmd = new OdbcCommand(query, connection);
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

        public bool InsertFormador(string id, string nome, string nif,
            string data_nascimento, string id_area)
        {
            string query = "insert into formador  (id_formador, nome, nif, " +
                "dataNascimento, id_area) values" +
                "('" + id + "','" + nome + "','" + nif + "','" + data_nascimento + "'," + 
                id_area + ");";

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

        public bool PesquisaFormador(string id_pesquisa, ref string nome, 
            ref string nif,ref string data_nascimento, ref string id_area)
        {
            bool flag = false;

            string query = "select nome, nif, dataNascimento, id_area from formador " +
                "where id_formador = '" + id_pesquisa + "';";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        nome = dataReader.GetString(0);
                        nif = dataReader["nif"].ToString();
                        data_nascimento = dataReader["dataNascimento"].ToString();
                        id_area = dataReader["id_area"].ToString();
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

        public string DevolverArea(string id_area)
        {
            string query = "select id_area, area from " +
                "area where id_area = '" + id_area + "';";

            string area = "";

            try
            {
                if (OpenConnection())
                {
                    OdbcCommand cmd = new OdbcCommand(query, connection);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        area = dr[1].ToString() + " - " + dr["id_area"].ToString();
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
            return area;
        }

        public bool Update(string id, string nome, string nif, string data_nascimento, string id_area)
        {
            string query = "update formador set nome = '" + nome + "', nif = '" +
                nif + "', dataNascimento = '" + data_nascimento + "', id_area = '" + 
                id_area + "' where id_formador = " + id;

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

        public bool Delete(string id)
        {
            bool flag = true;

            string query = "delete from formador where id_formador = '" + id + "';";

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

        public void PreencherDataGridViewFormador(ref DataGridView dgv)
        {
            string query = "select * from vFormadorArea order by nome;";

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
                        dgv.Rows[idxLinha].Cells["id_formador"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["nome"].Value = dr["Nome"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[idxLinha].Cells["area"].Value = dr["area"].ToString();
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

        public void PreencherDataGridViewFormador(ref DataGridView dgv, string nome, string id_area)
        {
            string query = "select * from vFormadorArea ";

            if (nome.Length > 0 )
            {
                query = query + " where nome like '%" + nome + "%' ";

                if (id_area.Length > 0)
                {
                    query = query + " and id_area = '" + id_area + "' ";
                }
            }
            else
            {
                if (id_area.Length > 0)
                {
                    query = query + "where id_area = '" + id_area + "';";
                }
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
                        dgv.Rows[idxLinha].Cells["id_formador"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["nome"].Value = dr["Nome"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[idxLinha].Cells["area"].Value = dr["area"].ToString();
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
    }
}
