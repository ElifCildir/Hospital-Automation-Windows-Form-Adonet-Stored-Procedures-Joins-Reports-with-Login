using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalOtomation16aug
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");


        public void Listele()
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = coon;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "UserList";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;


        }

        public void Temizle()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox4.Clear();

        }



        private void Admin_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            dataGridView1.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AdminLogin";
            cmd.Parameters.AddWithValue("AdminUsername", textBox1.Text);
            cmd.Parameters.AddWithValue("AdminPassword", textBox2.Text);

            coon.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Hoşgeldiniz");

                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                dataGridView1.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                label5.Visible = true;

            }



            else
            {
                MessageBox.Show("Giriş başarısız; tekrar deneyin");
                textBox1.Clear();
                textBox2.Clear();
            }

            coon.Close();
            Listele();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coon.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddUser";
            command.Parameters.AddWithValue("UserName", textBox3.Text);
            command.Parameters.AddWithValue("UserPassword", textBox4.Text);

            command.ExecuteNonQuery();


            coon.Close();
            Listele();
            Temizle();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;

            textBox3.Tag = satir.Cells
              ["UserNumber"].Value.ToString();
            textBox3.Text = satir.Cells
                ["UserName"].Value.ToString();
            textBox4.Text = satir.Cells
                ["UserPassword"].Value.ToString();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteUsers2";
            command.Parameters.AddWithValue("UserNumber", textBox6.Text);
            ;

            command.ExecuteNonQuery();


            coon.Close();
            Listele();
            Temizle();
        }

    

        private void button5_Click_1(object sender, EventArgs e)
        {
            MainMenu go = new MainMenu();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1(); 
            go.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
