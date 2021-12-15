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
    public partial class Form6 : Form
    {

        static SqlConnection c = new SqlConnection("Data Source=DESKTOP-S4J0PC9;Initial Catalog=TB_M;User ID=sa;Password=12345678");
        static SqlCommand scmd;
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form1 log = new Form1();
            this.Hide();
            log.Show();
         
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Do not keep any textbox blank");
                return;
            }
            
            string query = "Insert Into Teddy_1 values(@User_T,@User_N,@Pass,@DOB,@Mob_No,@Email,@Gender,@Present_Address, @Permanent_Address)";
            c.Open();
            scmd = new SqlCommand(query, c);
            






            //adding parameters
            scmd.Parameters.Add("@User_T", SqlDbType.VarChar);
            scmd.Parameters["@User_T"].Value = UserType.Text;

            scmd.Parameters.Add("@User_N", SqlDbType.VarChar);
            scmd.Parameters["@User_N"].Value = UserName.Text;

            scmd.Parameters.Add("@Pass", SqlDbType.VarChar);
            scmd.Parameters["@Pass"].Value = Password.Text;

            scmd.Parameters.Add("@DOB", SqlDbType.VarChar);
            scmd.Parameters["@DOB"].Value = Date_Of_Birth.Text;

            scmd.Parameters.Add("@Mob_No", SqlDbType.VarChar);
            scmd.Parameters["@Mob_No"].Value = Mobile_Number.Text;



            scmd.Parameters.Add("@Email", SqlDbType.VarChar);
            scmd.Parameters["@Email"].Value = Email.Text;

            scmd.Parameters.Add("@Gender", SqlDbType.VarChar);
            scmd.Parameters["@Gender"].Value = Gender.Text;





            scmd.Parameters.Add("@Present_Address", SqlDbType.VarChar);
            scmd.Parameters["@Present_Address"].Value = Present_Address.Text;

            scmd.Parameters.Add("@Permanent_Address", SqlDbType.VarChar);
            scmd.Parameters["@Permanent_Address"].Value = Permanent_Address.Text;


            scmd.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("Your account is created successfully");
            


        }
        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(UserType.Text) ||
                string.IsNullOrWhiteSpace(UserName.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) ||
                 string.IsNullOrWhiteSpace(Date_Of_Birth.Text) ||
                string.IsNullOrWhiteSpace(Mobile_Number.Text)||
                string.IsNullOrWhiteSpace(Email.Text)||
                 string.IsNullOrWhiteSpace(Gender.Text) ||
                string.IsNullOrWhiteSpace(Present_Address.Text)||
                string.IsNullOrWhiteSpace(Permanent_Address.Text)
                )
                return false;
            else return true;
        }
    }
}
