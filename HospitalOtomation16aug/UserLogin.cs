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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.SqlClient;


namespace HospitalOtomation16aug
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UserLogin";
            cmd.Parameters.AddWithValue("UserName", textBox1.Text);
            cmd.Parameters.AddWithValue("UserPassword", textBox2.Text);

            coon.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Hoşgeldiniz");

                MainMenu go = new MainMenu();
                go.Show();
                this.Hide();
             

            }



            else
            {
                MessageBox.Show("Giriş başarısız tekrar dene");
                textBox1.Clear();
                textBox2.Clear();
            }

        
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
