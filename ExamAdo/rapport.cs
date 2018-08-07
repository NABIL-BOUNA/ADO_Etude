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
    public partial class rapport : Form
    {
        public rapport()
        {
            InitializeComponent();
        }

        private void rapport_Load(object sender, EventArgs e)
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
            
        private void button1_Click(object sender, EventArgs e)
        {
            print r = new print();

            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetParameterValue("@Id",comboBox1.SelectedValue);
            r.crystalReportViewer1.ReportSource = rpt;
            r.Show();
        }
    }
}
