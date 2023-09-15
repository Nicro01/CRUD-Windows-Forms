using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using NITGEN.SDK.NBioBSP;
using static NITGEN.SDK.NBioBSP.NBioAPI;
using CRUD_Forms.Entity;
using CRUD_Forms.Data;

namespace CRUD_Forms
{
    public partial class Form1 : Form
    {
        Biometria bio = new Biometria();
        Model.User user = new Model.User();
        SQL sql = new SQL();
        Validation.Validacao val = new Validation.Validacao();
        

        public Form1()
        {
            InitializeComponent();
            sql.Listar(Dgv);
        }

        private void EsvaziarInputs()
        {
            IdTb.Text = string.Empty;
            NameTb.Text = string.Empty;
            CpfTb.Text = string.Empty;
        }   
        
        private void SairEdit()
        {
            if (UpTb.Enabled)
            {
                LeaveButton.Visible = true;
                return;
            }
            LeaveButton.Visible = false;
           
        }

        private void AddBt_Click(object sender, EventArgs e)
        {

            user.id = Convert.ToInt32(IdTb.Text);
            user.name = NameTb.Text;
            user.cpf = CpfTb.Text;
            user.template = bio.Registrar();
         
            if (user.template != "erro")
            {   
                val.ValidarModelo(user);
                sql.CriarDataTable(user);
                EsvaziarInputs();
                sql.Listar(Dgv);
                MessageBox.Show("Registro salvo com sucesso !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro de captura", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        

        private void RemoveTb_Click(object sender, EventArgs e)
        {
            if(IdTb.Text == string.Empty)
            {
                MessageBox.Show("Digite o ID do usuário que deseja remover");
                return;
            }
            sql.Remove(Convert.ToInt32(IdTb.Text));
            EsvaziarInputs();
            sql.Listar(Dgv);
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
                sql.Update(Convert.ToInt32(IdTb.Text), NameTb.Text, CpfTb.Text);
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário.\n\n" + ex.ToString());
                return;
            }

            IdTb.Enabled = true;
            UpTb.Enabled = false;

            //Esvaziar inputs
            EsvaziarInputs();

            sql.Listar(Dgv);
        }


        private void verifyBtn_Click(object sender, EventArgs e)
        {


            DataTable digital = sql.ListarTemplate(Convert.ToInt32(IdTb.Text));
            string Template = digital.Rows[0]["f_id"].ToString();
            string id = digital.Rows[0]["id"].ToString();
            string name = digital.Rows[0]["name"].ToString();

            if (bio.Comparar(Template))
            {
                returnLb.Text = "Return: Usuário encontrado!";
                returnId.Text = "ID: " + id;
                returnUE.Text = "Nome: " + name;
            }
            else
            {
                returnLb.Text = "Return: Usuário não encontrado!";
            }
            EsvaziarInputs();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Enabled = false;
            UpTb.Enabled = true;
            IdTb.Text = Dgv.CurrentRow.Cells[0].Value.ToString();
            NameTb.Text = Dgv.CurrentRow.Cells[1].Value.ToString();
            CpfTb.Text = Dgv.CurrentRow.Cells[2].Value.ToString();
            SairEdit();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Deseja sair? ", "",MessageBoxButtons.OKCancel);
            if(message == DialogResult.OK)
            {
                IdTb.Enabled = true;
                UpTb.Enabled = false;
                LeaveButton.Visible = false;
                EsvaziarInputs();
                return;
            }
            return;
        }
    }
}
