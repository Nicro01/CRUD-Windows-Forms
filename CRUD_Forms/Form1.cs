using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Forms
{
    public partial class Form1 : Form
    {

        MySqlCommand sql;
        

        //Método para adicionar usuário ao banco de dados
        private DataTable CriarDataTable(User user)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand("INSERT INTO profile (id, name, cpf) values('" + user.id + "' ,'" + user.name +"' , '"+ user.cpf + "')", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = sql;
            con.CloseConnection();
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            return dt;
            
        }

        //Método para remover usuário do banco de dados
        private void Remove(int id)
        {

            try
            {
                Connection con = new Connection();
                con.AbrirConexao();
                sql = new MySqlCommand("DELETE FROM profile WHERE id =" + id, con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                sql.ExecuteNonQuery();
                con.CloseConnection();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
          
            
        }

        //Método para listar banco de dados no DataGridView
        private void Listar()
        {
            Connection con = new Connection();
            con.AbrirConexao();
            var listar = new MySqlCommand("SELECT * FROM profile", con.con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(listar);
            DataTable data = new DataTable();
            adapter.Fill(data);

            listar.ExecuteNonQuery();
            

            Dgv.DataSource = data;
            con.CloseConnection();  
        }

        public Form1()
        {
            InitializeComponent();
            Listar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBt_Click(object sender, EventArgs e)
        {
            

            try
            {
                User user = new User();

                //Atribuir valores as propriedades do objeto criado
                user.id = Convert.ToInt32(IdTb.Text);
                user.name = NameTb.Text;
                user.cpf = CpfTb.Text;

                //Validarção e, caso aprovado, adicionar objeto ao banco de dados
                if (Validacao.ValidarModelo(user) == true)
                {
                    MessageBox.Show("Registro salvo com sucesso !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CriarDataTable(user);
                }


                //Deixar TextBoxs vazias
                IdTb.Text = string.Empty;
                NameTb.Text = string.Empty;
                CpfTb.Text = string.Empty;

                //Listar banco de dados no DataGridView
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Id de usuário já existe.\n\n" + ex.ToString());
                return;
            }

            
            
        }

        private void RemoveTb_Click(object sender, EventArgs e)
        {
            if(IdTb.Text == string.Empty)
            {
                MessageBox.Show("Digite o ID do usuário que deseja remover");
                return;
            }
            Remove(Convert.ToInt32(IdTb.Text));
            IdTb.Text = string.Empty;
            Listar();
            MessageBox.Show("Usuário removido com sucesso!");
        }
    }

    internal class User
    {
        [Required(ErrorMessage = "Id is required")]
        public  int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public  string name { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        public  string cpf { get; set; }
    }
}
