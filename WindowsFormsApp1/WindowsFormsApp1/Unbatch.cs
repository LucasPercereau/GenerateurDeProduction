using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Dynamic;

namespace WindowsFormsApp1
{
    class Unbatch : Element
    {
        private int _tailleLot;

        public int TailleLot
        {
            get { return _tailleLot; }
        }
        public Unbatch() : base(1, 1, @"Images\unbatch.png")
        {
            try
            {
                Button button = this.Controls.Find("button1", true).FirstOrDefault() as Button;
                button.MouseDown += setParameter;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void setParameter(object sender, MouseEventArgs e)
        {
            Form1 form1 = (Form1)Form.ActiveForm;
            if (!form1.IsLinking)
            {
                try
                {
                    if (e.Clicks == 2)
                    {
                        Form2 form2 = new Form2("Unbatch", "Taille des lots");
                        form2.TextBox.Text = _tailleLot.ToString();
                        if (form2.ShowDialog(this) == DialogResult.OK)
                        {
                            try
                            {
                                _tailleLot = System.Convert.ToInt32(form2.TextBox.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                form2.Dispose();
                                setParameter(sender, e);
                            }
                        }
                        form2.Dispose();
                    }
                }
                catch { }
            }
            
        }


        public override dynamic GenerateJson()
        {
            dynamic myObject = new ExpandoObject();
            myObject.name = this.GetType().Name;
            myObject.id = this.ID;
            myObject.X = this.Position.X;
            myObject.Y = this.Position.Y;
            myObject.tailleLot = this.TailleLot;
            return myObject;
        }
    }
}
