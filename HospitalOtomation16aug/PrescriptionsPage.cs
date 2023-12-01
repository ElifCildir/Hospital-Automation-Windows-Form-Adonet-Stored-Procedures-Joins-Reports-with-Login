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
    public partial class PrescriptionsPage : Form
    {
        public PrescriptionsPage()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");

      
        public void Listt()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = coon;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PresList";
            SqlDataAdapter pol = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            pol.Fill(filldata);
            dataGridView1.DataSource = filldata;




        }

        public void ClearData()
        {

            textBox1.Clear();
     
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
        private void PrescriptionsPage_Load(object sender, EventArgs e)
        {
            Listt();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PresAdd";
            DateTime date=Convert.ToDateTime(dateTimePicker1.Text);
            command.Parameters.AddWithValue("PrescripNumber", textBox1.Text);
            command.Parameters.AddWithValue("PrescripDate", dateTimePicker1.Text);
            command.Parameters.AddWithValue("PrescripDefinition", textBox3.Text);
            command.Parameters.AddWithValue("DoctorNumber", textBox4.Text);
            command.Parameters.AddWithValue("PatientNumber", textBox5.Text);
          

            command.ExecuteNonQuery();
            coon.Close();
            Listt();
            ClearData();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PredDelete";
            command.Parameters.AddWithValue("PrescripNumber", textBox1.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listt();
            ClearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
           
            textBox1.Text = row.Cells["PrescripNumber"].Value.ToString();
            dateTimePicker1.Text = row.Cells["PrescripDate"].Value.ToString();
            textBox3.Text = row.Cells["PrescripDefinition"].Value.ToString();
            textBox4.Text = row.Cells["DoctorNumber"].Value.ToString();
            textBox5.Text = row.Cells["PatientNumber"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PresUpdate";

            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            command.Parameters.AddWithValue("PrescripNumber", textBox1.Text);
            command.Parameters.AddWithValue("PrescripDate", dateTimePicker1.Text);
            command.Parameters.AddWithValue("PrescripDefinition", textBox3.Text);
            command.Parameters.AddWithValue("DoctorNumber", textBox4.Text);
            command.Parameters.AddWithValue("PatientNumber", textBox5.Text);

            command.ExecuteNonQuery();

            coon.Close();
            Listt();
            ClearData();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Date")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PresSearchDate";
                command.Parameters.AddWithValue("PrescripDate", dateTimePicker1.Text);
                SqlDataAdapter polsearch = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();

                polsearch.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();

            }



            else

            {

                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PresSearchDef";
                command.Parameters.AddWithValue("PrescripDefiniton", textBox3.Text);


                SqlDataAdapter polsearch2 = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();

                polsearch2.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();




            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Listt();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
