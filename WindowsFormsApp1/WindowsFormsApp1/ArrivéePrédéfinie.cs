using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    class ArrivéePrédéfinie : Element
    {
        private List<int> _sequence; //voir pour la syntaxe.... 

        public List<int> Sequence
        {
            get { return _sequence; }
        }

        public ArrivéePrédéfinie() : base(0, 1, @"Images\arriveepredefinie.jpg")
        {
            _sequence = new List<int>();
            
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
            string userString = null;
            if (e.Clicks == 2)
            {
                Form2 form2 = new Form2("Arrivée Prédéfinie", "Entrer ici la séquence");
                if (form2.ShowDialog(this) == DialogResult.OK)
                {
                    userString = form2.TextBox.Text;
                }
                form2.Dispose();
            }
        }

        public override string GenerateJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

    }
}
