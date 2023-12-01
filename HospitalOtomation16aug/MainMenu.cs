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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        SqlConnection coon = new SqlConnection("Server=.;Database=HospitalOtomation;Integrated Security=true;");
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patients go = new Patients();
            go.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Policlinics go = new Policlinics();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            PrescriptionsPage go = new PrescriptionsPage();
            go.Show();
            this.Hide();

        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Doctors go = new Doctors();
            go.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Patients go = new Patients();
            go.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Policlinics go = new Policlinics();
            go.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PrescriptionsPage go = new PrescriptionsPage();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReportsPage go = new ReportsPage();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           Form1 go = new Form1(); 
            go.Show();
            this.Hide();
        }
    }
}
