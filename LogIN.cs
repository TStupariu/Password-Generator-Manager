using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;

namespace PasswordGenerator
{
    public partial class LogIN : Form
    {

        string password = "salatacufructe_97";


        public LogIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if (password == textBox1.Text)
            {
                Form generate = new Form2();
                generate.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Log In data invalid!");
                this.textBox1.Text = "";
            }
        }

        private void LogIN_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }
    }
}
