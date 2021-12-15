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
    public partial class Form7cs : Form
    {
       
        public Form7cs()
        {
            InitializeComponent();
        }

        private void Form7cs_Load(object sender, EventArgs e)
        {

        }

        private void button50_Click(object sender, EventArgs e)
        {
            BusinessmanApp B= new BusinessmanApp();
            this.Hide();
            B.Show();

        }

        private void button51_Click(object sender, EventArgs e)
        {



            SqlConnection con = new SqlConnection("Data Source=DESKTOP-S4J0PC9;Initial Catalog=TB_M;User ID=sa;Password=12345678");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into EmployeeInfo( Name, Date_Of_Birth, Mobile_Number, Email, Gender, Present_Address,Permanent_Addresss,Salary) values('" + Name.Text + "', '" + date_Of_Birth.Text + "', '" + mobile_Number.Text + "', '" + email.Text + "', '" + gender.Text + "', '" + present_Address.Text + "', '" + permanent_Address.Text + "', '" + salary.Text + "')";


            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("done!");

            }
            else
            {
                MessageBox.Show("Error!");
            }
            con.Close();
        }




      
        }




    }

