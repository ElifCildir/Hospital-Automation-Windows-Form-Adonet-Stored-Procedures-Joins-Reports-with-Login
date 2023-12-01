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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }

        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");


        public void Listele()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = coon;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PatientList";
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
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PatientsAdd";
            command.Parameters.AddWithValue("PatientName", textBox1.Text);
            command.Parameters.AddWithValue("PatientSurname", textBox2.Text);
            command.Parameters.AddWithValue("PatientWeight", textBox3.Text);
            command.Parameters.AddWithValue("PatientHeight", textBox4.Text);
            command.Parameters.AddWithValue("PatientIdNumber", textBox5.Text);
            command.Parameters.AddWithValue("PatientAge", textBox6.Text);
            command.Parameters.AddWithValue("PatientReportStatus", textBox7.Text);

            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            textClear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["PatientNumber"].Value.ToString();
            textBox1.Text = satir.Cells["PatientName"].Value.ToString();
            textBox2.Text = satir.Cells["PatientSurname"].Value.ToString();
            textBox3.Text = satir.Cells["PatientWeight"].Value.ToString();
            textBox4.Text = satir.Cells["PatientHeight"].Value.ToString();
            textBox5.Text = satir.Cells["PatientIdNumber"].Value.ToString();
            textBox6.Text = satir.Cells["PatientAge"].Value.ToString();
            textBox7.Text = satir.Cells["PatientReportStatus"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PatientUpdate";
            command.Parameters.AddWithValue("PatientNumber", textBox1.Tag);
            command.Parameters.AddWithValue("PatientName", textBox1.Text);
            command.Parameters.AddWithValue("PatientSurname", textBox2.Text);
            command.Parameters.AddWithValue("PatientWeight", textBox3.Text);
            command.Parameters.AddWithValue("PatientHeight", textBox4.Text);
            command.Parameters.AddWithValue("PatientIdNumber", textBox5.Text);
            command.Parameters.AddWithValue("PatientAge", textBox6.Text);
            command.Parameters.AddWithValue("PatientReportStatus", textBox7.Text);



            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            textClear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PatientDelete";
            command.Parameters.AddWithValue("PatientNumber", textBox1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "Surname")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PatientSearch";
                command.Parameters.AddWithValue("PatientSurname", textBox2.Text);

                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();


            }


            else if(comboBox1.SelectedItem == "ID Number" )
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PatientSearchID";
                command.Parameters.AddWithValue("PatientIdNumber", textBox5.Text);

                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();


            }


            else if(comboBox1.SelectedItem == "Report Status")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PatientSearchReport";
                command.Parameters.AddWithValue("PatientReportStatus", textBox7.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
    }

