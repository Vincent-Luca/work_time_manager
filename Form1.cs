using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace worktimemanager
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Info.Default.name;
            textBox2.Text = Info.Default.passwort;
            checkBox1.Checked = Info.Default.rememberme;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
            acc acc = new acc();
            acc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info.Default.rememberme = checkBox1.Checked;
            Info.Default.name = textBox1.Text;
            Info.Default.passwort = textBox2.Text;
            Info.Default.Save();
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
