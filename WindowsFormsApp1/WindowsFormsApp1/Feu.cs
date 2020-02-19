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
    class Feu : Element
    {
        private double _dureeVert;
        private double _dureeRouge;

        public double DureeVert
        {
            get { return _dureeVert; }
        }

        public double DureeRouge
        {
            get { return _dureeRouge; }
        }

        public Feu() : base(1, 1, @"Images\feu.png")
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
                        try
                        {
                            Form3 form3 = new Form3("Feu ", "Durée feu Vert", "Durée feu Rouge");
                            form3.TextBox1.Text = this._dureeVert.ToString();
                            form3.TextBox2.Text = this._dureeRouge.ToString();
                            if (form3.ShowDialog(this) == DialogResult.OK)
                            {
                                _dureeVert = System.Convert.ToInt32(form3.TextBox1.Text);
                                _dureeRouge = System.Convert.ToDouble(form3.TextBox2.Text);
                            }
                            form3.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            setParameter(sender, e);
                        }
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
            myObject.dureeRouge = this.DureeRouge;
            myObject.dureeVert = this.DureeVert;
            return myObject;
        }
    }
}
