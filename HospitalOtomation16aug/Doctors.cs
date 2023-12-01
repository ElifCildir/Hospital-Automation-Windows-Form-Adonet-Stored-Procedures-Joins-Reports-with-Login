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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace HospitalOtomation16aug
{
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }

        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");


        public void Listele()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = coon;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DoctorList";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
        }


        public void textClear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DoctorAdd";
            command.Parameters.AddWithValue("DoctorPoliclinic", textBox1.Text);
            command.Parameters.AddWithValue("DoctorName", textBox2.Text);
            command.Parameters.AddWithValue("DoctorSurname", textBox3.Text);
            command.Parameters.AddWithValue("DoctorAge", textBox4.Text);
            command.Parameters.AddWithValue("DoctorSalary", textBox5.Text);
            command.Parameters.AddWithValue("DoctorTitle", textBox6.Text);
            command.Parameters.AddWithValue("DoctorIdNumber", textBox7.Text);
            command.Parameters.AddWithValue("PolNo", textBox8.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            textClear();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["DoctorNumber"].Value.ToString();
            textBox1.Text = satir.Cells["DoctorPoliclinic"].Value.ToString();
            textBox2.Text = satir.Cells["DoctorName"].Value.ToString();
            textBox3.Text = satir.Cells["DoctorSurname"].Value.ToString();
            textBox4.Text = satir.Cells["DoctorAge"].Value.ToString();
            textBox5.Text = satir.Cells["DoctorSalary"].Value.ToString();
            textBox6.Text = satir.Cells["DoctorTitle"].Value.ToString();
            textBox7.Text = satir.Cells["DoctorIdNumber"].Value.ToString();
            textBox8.Text = satir.Cells["PolNo"].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DoctorUpdate";
            command.Parameters.AddWithValue("DoctorNumber", textBox1.Tag);
            command.Parameters.AddWithValue("DoctorPoliclinic", textBox1.Text);
            command.Parameters.AddWithValue("DoctorName", textBox2.Text);
            command.Parameters.AddWithValue("DoctorSurname", textBox3.Text);
            command.Parameters.AddWithValue("DoctorAge", textBox4.Text);
            command.Parameters.AddWithValue("DoctorSalary", textBox5.Text);
            command.Parameters.AddWithValue("DoctorTitle", textBox6.Text);
            command.Parameters.AddWithValue("DoctorIdNumber", textBox7.Text);
            command.Parameters.AddWithValue("PolNo", textBox8.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            textClear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DoctorDelete";
            command.Parameters.AddWithValue("DoctorNumber", textBox1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "Name")
            { 

            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DoctorSearch";
            command.Parameters.AddWithValue("DoctorName", textBox2.Text);

            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
            coon.Close();
            }

            else if (comboBox1.SelectedItem == "Age")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DoctorSearchAge";
                command.Parameters.AddWithValue("DoctorAge", textBox4.Text);

                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();


            }

            else if(comboBox1.SelectedItem == "Title")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DoctorSearchTitle";
                command.Parameters.AddWithValue("DoctorTitle", textBox6.Text);

                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();

            }



        }

        private void button1_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
    }

