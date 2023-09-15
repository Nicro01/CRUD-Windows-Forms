using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Forms.Data
{
    public class SQL
    {
        MySqlCommand sql;
        private void SQLConnection(string cmd)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand(cmd, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql.ExecuteNonQuery();
            con.CloseConnection();
        }

        //Método para adicionar usuário ao banco de dados
        public DataTable CriarDataTable(Model.User user)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand("INSERT INTO profile (id, name, cpf, f_id) values('" + user.id + "' ,'" + user.name + "' , '" + user.cpf + "' ,'" + user.template + "')", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = sql;
            con.CloseConnection();
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }

        //Método para atualizar usuário no banco de dados
        public void Update(int id, string name, string cpf)
        {
            SQLConnection("UPDATE profile SET name = '" + name + "', cpf = '" + cpf + "' WHERE id = " + id);
       
        }

        //Método para remover usuário do banco de dados
        public void Remove(int id)
        {

            try
            {
                SQLConnection("DELETE FROM profile WHERE id =" + id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }

        //Método para listar banco de dados no DataGridView
        public DataTable Listar(DataGridView dgv)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            var listar = new MySqlCommand("SELECT * FROM profile", con.con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(listar);
            DataTable data = new DataTable();
            adapter.Fill(data);
            listar.ExecuteNonQuery();
            dgv.DataSource = data;
            con.CloseConnection();
            return data;
        }

        public DataTable ListarTemplate(int id)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            var sql = new MySqlCommand("SELECT id, name, f_id FROM profile WHERE id = '" + id + "'", con.con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);
            DataTable data = new DataTable();
            adapter.Fill(data);

            sql.ExecuteNonQuery();

            con.CloseConnection();

            return data;
        }
    }
    
}
