using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace worktimemanager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\worktime.mdb";



            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

            cmd.Connection = con;
            cmd.CommandText = "Select * from Main;";

            con.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                double gehalt = Convert.ToDouble(reader.GetValue(2)) * Info.Default.gehalt;
                dataGridView1.Rows.Add(reader.GetValue(1), reader.GetValue(2), gehalt.ToString());
            }
            reader.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double gehalt = Convert.ToDouble(textBox1.Text) * Info.Default.gehalt;
                dataGridView1.Rows.Add(dateTimePicker1.Value.ToString(), textBox1.Text, gehalt);
            }
            catch (Exception)
            {

                MessageBox.Show("woops something went wrong, double check your input fields and try again");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\worktime.mdb";

            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;
            cmd.Connection = con;
            cmd.CommandText = "DELETE * from Main";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Main ([date],[gehalt]) VALUES (@date,@gehalt)";
                cmd.Parameters.Add("@date", OleDbType.VarChar, 40).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cmd.Parameters.Add("@gehalt", OleDbType.VarChar, 40).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info.Default.gehalt = Convert.ToDouble(textBox2.Text);
            Info.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\worktime.mdb";

            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;
            cmd.Connection = con;
            cmd.CommandText = "DELETE * from Main";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Main ([date],[gehalt]) VALUES (@date,@gehalt)";
                cmd.Parameters.Add("@date", OleDbType.VarChar, 40).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cmd.Parameters.Add("@gehalt", OleDbType.VarChar, 40).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\worktime.mdb";

            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;
            cmd.Connection = con;
            cmd.CommandText = "DELETE * from Main";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Main ([date],[gehalt]) VALUES (@date,@gehalt)";
                cmd.Parameters.Add("@date", OleDbType.VarChar, 40).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cmd.Parameters.Add("@gehalt", OleDbType.VarChar, 40).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
