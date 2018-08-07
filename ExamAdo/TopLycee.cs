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
    public partial class TopLycee : Form
    {
        public TopLycee()
        {
            InitializeComponent();
        }

        private void TopLycee_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Config.cnx.Open();
            SqlCommand cmd = new SqlCommand("select idAcademie,nomAcademie from Academie", Config.cnx);
            Config.dr = cmd.ExecuteReader();
            dt.Load(Config.dr);
            Config.cnx.Close();

            comboBox1.DataSource = dt;

            comboBox1.ValueMember = "idAcademie";
            comboBox1.DisplayMember = "nomAcademie";
            comboBox1.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                DataTable dtx = new DataTable();
                Config.cnx.Open();
                SqlCommand cmd = new SqlCommand("select Top 10 (Count(idProfesseur)) as 'Nombre de Professeur',Lycee.nom from Lycee,Professeur where Lycee.idLycee=Professeur.idLycee and Lycee.idLycee=" + comboBox1.SelectedValue + " group by Lycee.nom", Config.cnx);
                Config.dr = cmd.ExecuteReader();
                dtx.Load(Config.dr);
                dataGridView1.DataSource = dtx;
                Config.cnx.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Config.cnx.Open();
            SqlDataAdapter dp = new SqlDataAdapter("select Top 10 (Count(idProfesseur)) as 'Nombre de Professeur',Lycee.nom from Lycee,Professeur where Lycee.idLycee=Professeur.idLycee and Lycee.idLycee=" + comboBox1.SelectedValue + " group by Lycee.nom", Config.cnx);
            dp.Fill(ds);
            Config.cnx.Close();
            ds.WriteXml("Lycees.xml");

            MessageBox.Show("bien exporter");
        }
    }
}
