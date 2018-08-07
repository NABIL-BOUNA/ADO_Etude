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
    public partial class Professeur : Form
    {
        public Professeur()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            charge();
        }

        private void Professeur_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("célibataire");
            comboBox1.Items.Add("marié");
            comboBox1.Items.Add("divorcé");
            comboBox1.Items.Add("veuf");
            charge();

        }
        public DataTable dt = new DataTable();
        public void charge() 
        {
            dt.Clear();
            DataTable dt1 = new DataTable();
            Config.cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from Professeur", Config.cnx);
            Config.dr = cmd.ExecuteReader();
            dt.Load(Config.dr);
            SqlCommand cmd1 = new SqlCommand("select * from Lycee", Config.cnx);
            Config.dr = cmd1.ExecuteReader();
            dt1.Load(Config.dr);

            comboBox2.DataSource = dt1;

            comboBox2.ValueMember = "idLycee";
            comboBox2.DisplayMember = "nom";
            Config.cnx.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = null;
            comboBox2.Text = null;
            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker2.Value = System.DateTime.Now;
            textBox6.Enabled = true;
            textBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "célibataire") 
            {
                textBox6.Text = "0";
                textBox6.Enabled = false;
            }
            else 
            {
                textBox6.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (chercher() == false)
            {
                Config.cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into Professeur values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker2.Text + "','" + comboBox1.Text + "'," + int.Parse(textBox6.Text) + "," + comboBox2.SelectedValue + ")", Config.cnx);
                cmd.ExecuteNonQuery();
                Config.cnx.Close();
                MessageBox.Show("Bien ajouter");
                charge();
            }
            else
            {
                MessageBox.Show("Existe déja la base");
            }
        }


        bool test;
        int d;
        public bool chercher()
        {
            test = false;
            
            if (textBox1.Text != "")
            {
                int i = 0;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].ItemArray[0].ToString() == textBox1.Text)
                    {
                        d = 1;
                        break;
                    }

                    i++;
                }
            }
            if (d == 1)
            {
                test = true;
            }

            return test;
        }

        public int ps = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            ps = 0;

            textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0].ItemArray[3].ToString());
            textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
            textBox5.Text = dt.Rows[0].ItemArray[5].ToString();
            dateTimePicker2.Value = DateTime.Parse(dt.Rows[0].ItemArray[6].ToString());
            comboBox1.Text = dt.Rows[0].ItemArray[7].ToString();

            textBox6.Text = dt.Rows[0].ItemArray[8].ToString();
            comboBox2.SelectedValue = dt.Rows[0].ItemArray[9].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            int c = dt.Rows.Count;
            ps = c - 1;

            textBox1.Text = dt.Rows[ps].ItemArray[0].ToString();
            textBox2.Text = dt.Rows[ps].ItemArray[1].ToString();
            textBox3.Text = dt.Rows[ps].ItemArray[2].ToString();
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[ps].ItemArray[3].ToString());
            textBox4.Text = dt.Rows[ps].ItemArray[4].ToString();
            textBox5.Text = dt.Rows[ps].ItemArray[5].ToString();
            dateTimePicker2.Value = DateTime.Parse(dt.Rows[ps].ItemArray[6].ToString());
            comboBox1.Text = dt.Rows[ps].ItemArray[7].ToString();

            textBox6.Text = dt.Rows[ps].ItemArray[8].ToString();
            comboBox2.SelectedValue = dt.Rows[ps].ItemArray[9].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ps > 0)
            {
                ps = ps - 1;

                textBox1.Text = dt.Rows[ps].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[ps].ItemArray[1].ToString();
                textBox3.Text = dt.Rows[ps].ItemArray[2].ToString();
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[ps].ItemArray[3].ToString());
                textBox4.Text = dt.Rows[ps].ItemArray[4].ToString();
                textBox5.Text = dt.Rows[ps].ItemArray[5].ToString();
                dateTimePicker2.Value = DateTime.Parse(dt.Rows[ps].ItemArray[6].ToString());
                comboBox1.Text = dt.Rows[ps].ItemArray[7].ToString();

                textBox6.Text = dt.Rows[ps].ItemArray[8].ToString();
                comboBox2.SelectedValue = dt.Rows[ps].ItemArray[9].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ps < dt.Rows.Count-1)
            {
                ps = ps + 1;

                textBox1.Text = dt.Rows[ps].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[ps].ItemArray[1].ToString();
                textBox3.Text = dt.Rows[ps].ItemArray[2].ToString();
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[ps].ItemArray[3].ToString());
                textBox4.Text = dt.Rows[ps].ItemArray[4].ToString();
                textBox5.Text = dt.Rows[ps].ItemArray[5].ToString();
                dateTimePicker2.Value = DateTime.Parse(dt.Rows[ps].ItemArray[6].ToString());
                comboBox1.Text = dt.Rows[ps].ItemArray[7].ToString();

                textBox6.Text = dt.Rows[ps].ItemArray[8].ToString();
                comboBox2.SelectedValue = dt.Rows[ps].ItemArray[9].ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (chercher() == true)
            {
                Config.cnx.Open();
                SqlCommand cmdr = new SqlCommand("Delete Professeur where idProfesseur = " + int.Parse(textBox1.Text) + "", Config.cnx);
                cmdr.ExecuteNonQuery();
                Config.cnx.Close();
                MessageBox.Show("Bien Supprimer");
                charge();
            }
            else
            {
                MessageBox.Show("n'Existe pas dans la base");
            }
        }

        int x;

        private void button6_Click(object sender, EventArgs e)
        {


            if (chercher() == true)
            {
                Config.cnx.Open();
                SqlCommand cmdr = new SqlCommand("Update Professeur set nom='" + textBox2.Text + "',prenom='" + textBox3.Text + "',dateN='" + dateTimePicker1.Text + "',email='" + textBox4.Text + "',pass='" + textBox5.Text + "',dateAffLycee='" + dateTimePicker2.Text + "',EtatCivil='" + comboBox1.Text + "',NEnfants=" + int.Parse(textBox6.Text) + ",idLycee=" + comboBox2.SelectedIndex + " where idProfesseur = " + int.Parse(textBox1.Text) + "", Config.cnx);
                cmdr.ExecuteNonQuery();
                Config.cnx.Close();
                MessageBox.Show("Bien Modifier");
                charge();
            }
            else
            {
                MessageBox.Show("n'Existe pas dans la base");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
