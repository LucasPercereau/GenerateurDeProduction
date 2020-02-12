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
    public partial class Form2 : Form
    {
        public Form2(string titre, string label)
        {
            InitializeComponent();
            this.label1.Text = label;
            this.Text= titre;
        }
        public TextBox TextBox
        {
            get { return this.textBox1; }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //verifier la chaine passée
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
