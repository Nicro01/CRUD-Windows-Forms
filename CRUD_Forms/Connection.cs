using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using MySqlConnector;

namespace CRUD_Forms
{
    internal class Connection
    {
        readonly string connection = "SERVER=localhost; DATABASE=crud_forms; UID=root; PWD= 123456789";

        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar" + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao fechar conexão" + ex.Message);
            }
        }
    }
}
