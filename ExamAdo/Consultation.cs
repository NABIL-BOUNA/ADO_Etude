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

namespace ExamAdo
{
    public partial class Consultation : Form
    {
        public Consultation()
        {
            InitializeComponent();
        }

        private void Consultation_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Config.cnx.Open();
            SqlCommand cmd = new SqlCommand("select idLycee,nom from Lycee", Config.cnx);
            Config.dr = cmd.ExecuteReader();
            dt.Load(Config.dr);
            Config.cnx.Close();
            
            comboBox1.DataSource = dt;

            comboBox1.ValueMember = "idLycee";
            comboBox1.DisplayMember = "nom";
            comboBox1.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                DataTable dt = new DataTable();
                Config.cnx.Open();
                SqlCommand cmd = new SqlCommand("select idProfesseur,nom,prenom from Professeur where idLycee=" + comboBox1.SelectedValue + "", Config.cnx);
                Config.dr = cmd.ExecuteReader();
                dt.Load(Config.dr);
                dataGridView1.DataSource = dt;
                Config.cnx.Close();
            }
        }
    }
}
