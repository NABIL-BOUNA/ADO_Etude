using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamAdo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Professeur_Click(object sender, EventArgs e)
        {
            Professeur pr = new Professeur();
            pr.MdiParent = this;
            pr.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Consultation con = new Consultation();
            con.MdiParent = this;
            con.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            TopLycee tp = new TopLycee();
            tp.MdiParent = this;
            tp.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            rapport tp = new rapport();
            tp.MdiParent = this;
            tp.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            rep_region r = new rep_region();
            r.MdiParent = this;
            r.Show();
        }
    }
}
