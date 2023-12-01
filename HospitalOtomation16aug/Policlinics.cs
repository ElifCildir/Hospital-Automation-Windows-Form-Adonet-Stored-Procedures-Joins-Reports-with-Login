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
    public partial class Policlinics : Form
    {
        public Policlinics()
        {
            InitializeComponent();
        }

        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");

        public void listt()

        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = coon;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PoliclinicList";
            SqlDataAdapter pol = new SqlDataAdapter(komut);
            DataTable filldata = new DataTable();
            pol.Fill(filldata);
            dataGridView1.DataSource = filldata;


        }

        public void ClearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        

        }


        private void Policlinics_Load(object sender, EventArgs e)
        {
            listt();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddPoliclinic";
            command.Parameters.AddWithValue("PolName", textBox1.Text);
            command.Parameters.AddWithValue("PolEmpNumber", textBox2.Text);
            command.Parameters.AddWithValue("PolResponsiblePerson", textBox3.Text);
            command.Parameters.AddWithValue("PolBudget", textBox4.Text);
        

            command.ExecuteNonQuery();
            coon.Close();
            listt();
            ClearData();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType= CommandType.StoredProcedure;
            command.CommandText = "PoliclinicDelete";
            command.Parameters.AddWithValue("PolNo", textBox1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
            listt();
            ClearData();





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["PolNo"].Value.ToString();
            textBox1.Text = row.Cells["PolName"].Value.ToString();
            textBox2.Text = row.Cells["PolEmpNumber"].Value.ToString();
            textBox3.Text = row.Cells["PolResponsiblePerson"].Value.ToString();
            textBox4.Text = row.Cells["PolBudget"].Value.ToString();
           




        }

        private void button5_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdatePoliclinic";

            command.Parameters.AddWithValue("PolNo", textBox1.Tag);
            command.Parameters.AddWithValue("PolName", textBox1.Text);
            command.Parameters.AddWithValue("PolEmpNumber", textBox2.Text);
            command.Parameters.AddWithValue("PolResponsiblePerson", textBox3.Text);
            command.Parameters.AddWithValue("PolBudget", textBox4.Text);
          

            command.ExecuteNonQuery();
            coon.Close();
            listt();
            ClearData();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            listt();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "Name")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType= CommandType.StoredProcedure;
                command.CommandText = "PoliclinicSearch";
                command.Parameters.AddWithValue("PolName", textBox1.Text);
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
                command.CommandText = "PoliclinicSearhResp";
                command.Parameters.AddWithValue("PolResponsiblePerson", textBox3.Text);
                SqlDataAdapter polsearch2 = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();

                polsearch2.Fill(filldata);
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
    }
}
