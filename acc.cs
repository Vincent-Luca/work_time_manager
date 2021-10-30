using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace worktimemanager
{
    public partial class acc : Form
    {
        public acc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info.Default.name = textBox1.Text;
            Info.Default.passwort = textBox2.Text;
            try
            {
                Info.Default.gehalt = Convert.ToDouble(textBox3.Text);
                Info.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("You have to put a number in in the slot");
            }
            Form1 form = new Form1();
            form.Show();
            this.Close();

        }
    }
}
