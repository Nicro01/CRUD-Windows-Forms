using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using NITGEN.SDK.NBioBSP;
using static NITGEN.SDK.NBioBSP.NBioAPI;



namespace CRUD_Forms
{
    public partial class Form1 : Form
    {
        NBioAPI m_NBioAPI;
        NBioAPI.IndexSearch m_IndexSearch;
        NBioAPI.Type.WINDOW_OPTION m_WinOption;
        MySqlCommand sql;


        public Form1()
        {
            InitializeComponent();
            Listar();
            m_NBioAPI = new NBioAPI();
            m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            uint ret = m_IndexSearch.InitEngine();
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
            }


            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);

            Text = String.Format("IndexSearch Demo for C#.NET using class library (BSP Version : v{0}.{1:D4})", version.Major, version.Minor);

            
        }

        private void DisplayErrorMsg(uint ret)
        {
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para adicionar usuário ao banco de dados
        private DataTable CriarDataTable(User user)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand("INSERT INTO profile (id, name, cpf, f_id) values('" + user.id + "' ,'" + user.name +"' , '"+ user.cpf + "' ,'" + user.f_id + "')", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = sql;
            con.CloseConnection();
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            return dt;
            
        }

        //Método para atualizar usuário no banco de dados
        private void Update(int id)
        {
            Connection con = new Connection();
            con.AbrirConexao();
            sql = new MySqlCommand("UPDATE profile SET name = '" + NameTb.Text + "', cpf = '" + CpfTb.Text + "' WHERE id = " + id, con.con);
            sql.ExecuteReader();
            con.CloseConnection();
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

        private void AddBt_Click(object sender, EventArgs e)
        {
            

            try
            {
                User user = new User();
                NBioAPI.Type.HFIR hNewFIR;
                NBioAPI.Type.FIR_TEXTENCODE m_textFIR;
                uint nUserID = 0;

                //Atribuir valores as propriedades do objeto criado
                user.id = Convert.ToInt32(IdTb.Text);
                user.name = NameTb.Text;
                user.cpf = CpfTb.Text;
                

                
                if (Validacao.ValidarNome(user) == false && Validacao.ValidarCPF(user) == false)
                {
                    nameRequired.Visible = true;
                    cpfRequired.Visible = true;
                }
                else if(Validacao.ValidarCPF(user) == false)
                {
                    cpfRequired.Visible = true;
                    nameRequired.Visible = false;
                }
                else if(Validacao.ValidarNome(user) == false)
                {
                    cpfRequired.Visible = false;
                    nameRequired.Visible = true;
                }
                else
                {
                    cpfRequired.Visible = false;
                    nameRequired.Visible = false;
                }

                try
                {
                    int test = Convert.ToInt32(IdTb.Text);
                    if (test == 0)
                        throw (new Exception());
                }
                catch
                {
                    MessageBox.Show("User ID must be have numeric type and greater than 0.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nUserID = Convert.ToUInt32(IdTb.Text);

                NBioAPI.Type.HFIR hEnrolledFIR;

                m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                uint ret = m_NBioAPI.Enroll(null, out hEnrolledFIR, null, NBioAPI.Type.TIMEOUT.DEFAULT, null, m_WinOption);

                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                    return;
                }

                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                m_NBioAPI.GetTextFIRFromHandle(hEnrolledFIR, out m_textFIR, true);

                user.f_id = m_textFIR.TextFIR.ToString();

                //Validarção e, caso aprovado, adicionar objeto ao banco de dados
                if (Validacao.ValidarModelo(user) == true)
                {
                    CriarDataTable(user);
                    MessageBox.Show("Registro salvo com sucesso !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ex.ToString());
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


        private void UpTb_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdTb.Text == string.Empty)
                {
                    MessageBox.Show("Digite o ID do usuário que deseja atualizar");
                    return;
                }
                Update(Convert.ToInt32(IdTb.Text));
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário.\n\n" + ex.ToString());
                return;
            }

            //Esvaziar inputs
            IdTb.Text = string.Empty;
            NameTb.Text = string.Empty;
            CpfTb.Text = string.Empty;

            Listar();
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            

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

        
        public string f_id { get; set; }
    }
}
