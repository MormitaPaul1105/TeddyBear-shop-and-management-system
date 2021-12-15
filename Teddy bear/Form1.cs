using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teddy_bear
{
   
    public partial class Form1 : Form
    {

   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Do not keep any textbox blank");
                return;
            }

           
            if (UserType.Text == "Businessman")
            {
                 SqlConnection c = new SqlConnection("Data Source=DESKTOP-S4J0PC9;Initial Catalog=TB_M;User ID=sa;Password=12345678");
                SqlCommand scmd;
                string query = "Select * From Teddy_1 WHERE  UserName=@User_N AND Password = @Pass";
                
                scmd = new SqlCommand(query, c);
                c.Open();
                scmd.Parameters.Add("@User_N", SqlDbType.VarChar);
                scmd.Parameters["@User_N"].Value = UserName.Text;

                scmd.Parameters.Add("@Pass", SqlDbType.VarChar);
                scmd.Parameters["@Pass"].Value = Password.Text;

                SqlDataAdapter DA = new SqlDataAdapter(scmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    
                    BusinessmanApp BA = new BusinessmanApp();
                    this.Hide();
                    BA.Show();

                }
                else
                {
                    MessageBox.Show("This account isn't exist");
                }
                c.Close();
            }
            
            if (UserType.Text == "Customer")
            {
               

                SqlConnection c = new SqlConnection("Data Source=DESKTOP-S4J0PC9;Initial Catalog=TB_M;User ID=sa;Password=12345678");
                SqlCommand scmd;
                string query = "Select * From Teddy_1 WHERE  UserName=@User_N AND Password = @Pass";
                
                scmd = new SqlCommand(query, c);

                c.Open();
                scmd.Parameters.Add("@User_N", SqlDbType.VarChar);
                scmd.Parameters["@User_N"].Value = UserName.Text;

                scmd.Parameters.Add("@Pass", SqlDbType.VarChar);
                scmd.Parameters["@Pass"].Value = Password.Text;



                SqlDataAdapter da = new SqlDataAdapter(scmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    CustomerApp CA = new CustomerApp();
                    this.Hide();
                    CA.Show();
                }

                
                else
                {

                    MessageBox.Show("This account isn't exist");
                }
                c.Close();
            }



        }

    

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 reg_1 = new Form6();
            this.Hide();
            reg_1.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(UserType.Text) ||
                string.IsNullOrWhiteSpace(UserName.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) 
                
                )
                return false;
            else return true;
        }
    }

}
