using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3(string titre, string label1, string label2)
        {
            InitializeComponent();
            this.label1.Text = label1;
            this.label2.Text = label2;
            this.Text = titre;
        }

        public TextBox TextBox1
        {
            get { return this.textBox1; }
        }

        public TextBox TextBox2
        {
            get { return this.textBox2; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
