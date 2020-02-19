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
    class Machine : Element
    {
        private int _buffer;
        private double _time;

        public int Buffer
        {
            get { return _buffer; }
        }

        public double Time
        {
            get { return _time; }
        }


        public Machine() : base(1, 1, @"Images\machine.png")
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
                            Form3 form3 = new Form3("Machine ", "Ressources", "Temps de traitement");
                            form3.TextBox1.Text = this._buffer.ToString();
                            form3.TextBox2.Text = this._time.ToString();
                            if (form3.ShowDialog(this) == DialogResult.OK)
                            {
                                _buffer = System.Convert.ToInt32(form3.TextBox1.Text);
                                _time = System.Convert.ToDouble(form3.TextBox2.Text);
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
            myObject.buffer = this.Buffer;
            myObject.taille = this.Time;
            return myObject;
        }
    }
}
