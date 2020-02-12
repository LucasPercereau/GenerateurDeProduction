using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Element> _elements;


        public List<Element> Elements
        {
            get { return _elements; }
        }

        public Form1()
        {
            _elements = new List<Element>();
            InitializeComponent();          
        }

        private void splitContainer1_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
                if (this.listBox1.SelectedIndex != -1)
                {
                    string classToInstanciate = this.listBox1.GetItemText(this.listBox1.SelectedItem);
                    try
                    {
                        switch (classToInstanciate)
                        {
                            case "Arrivée Manuelle":
                                ArriveeManuelle arrivemanuelle = new ArriveeManuelle();
                                this.splitContainer1.Panel2.Controls.Add(arrivemanuelle);
                                arrivemanuelle.Position = arrivemanuelle.Location = new Point(e.Location.X - (arrivemanuelle.Width / 2), e.Location.Y - (arrivemanuelle.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(arrivemanuelle);
                                break;
                            case "Arrivée Prédéfinie":
                                ArriveePredefinie arriveepredefinie = new ArriveePredefinie();
                                this.splitContainer1.Panel2.Controls.Add(arriveepredefinie);
                                arriveepredefinie.Position = arriveepredefinie.Location = new Point(e.Location.X - (arriveepredefinie.Width / 2), e.Location.Y - (arriveepredefinie.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(arriveepredefinie);
                                break;
                            case "Machine":
                                Machine machine = new Machine();
                                this.splitContainer1.Panel2.Controls.Add(machine);
                                machine.Position = machine.Location = new Point(e.Location.X - (machine.Width / 2), e.Location.Y - (machine.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(machine);
                                break;
                            case "Match":
                                Match match = new Match();
                                this.splitContainer1.Panel2.Controls.Add(match);
                                match.Position = match.Location = new Point(e.Location.X - (match.Width / 2), e.Location.Y - (match.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(match);
                                break;
                            case "Batch":
                                Batch batch = new Batch();
                                this.splitContainer1.Panel2.Controls.Add(batch);
                                batch.Position = batch.Location = new Point(e.Location.X - (batch.Width / 2), e.Location.Y - (batch.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(batch);
                                break;
                            case "Unbatch":
                                Unbatch unbatch = new Unbatch();
                                this.splitContainer1.Panel2.Controls.Add(unbatch);
                                unbatch.Position = unbatch.Location = new Point(e.Location.X - (unbatch.Width / 2), e.Location.Y - (unbatch.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(unbatch);
                                break;
                            case "Router":
                                Router router = new Router();
                                this.splitContainer1.Panel2.Controls.Add(router);
                                router.Position = router.Location = new Point(e.Location.X - (router.Width / 2), e.Location.Y - (router.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(router);
                                break;
                            case "Mux":
                                Mux mux = new Mux();
                                this.splitContainer1.Panel2.Controls.Add(mux);
                                mux.Position = mux.Location = new Point(e.Location.X - (mux.Width / 2), e.Location.Y - (mux.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(mux);
                                break;
                            case "Merge":
                                Merge merge = new Merge();
                                this.splitContainer1.Panel2.Controls.Add(merge);
                                merge.Position = merge.Location = new Point(e.Location.X - (merge.Width / 2), e.Location.Y - (merge.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(merge);
                                break;
                            case "Feu":
                                Feu feu = new Feu();
                                this.splitContainer1.Panel2.Controls.Add(feu);
                                feu.Position = feu.Location = new Point(e.Location.X - (feu.Width / 2), e.Location.Y - (feu.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(feu);
                                break;
                            case "WTEG":
                                WTEG wteg = new WTEG();
                                this.splitContainer1.Panel2.Controls.Add(wteg);
                                wteg.Position = wteg.Location = new Point(e.Location.X - (wteg.Width / 2), e.Location.Y - (wteg.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(wteg);
                                break;
                            default:
                                break;

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
        }


        public void DestroyElement(Element element)
        {
            for (int i=0; i < _elements.Count; i++)
            {
                if(_elements[i].ID == element.ID)
                {
                    _elements.RemoveAt(i);
                }
            }
        }

        private void générerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<dynamic> list = new List<dynamic>();
           foreach(Element el in _elements)
            {
                list.Add(el.GenerateJson());
            }
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("Generation.JSON", json);

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Generation.JSON"))
                Process.Start(@"Javascript\index.html");
            else
            {
                MessageBox.Show("You need to generate a Json file before");
            }
        }

        
        private void splitContainer1_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("FSDFSDFSDFDFSD");
            this.splitContainer1.Panel2.Invalidate();           
        }
        
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("FSDFSDFSDFDFSD");
            foreach (Element el in _elements)
            {
                
                foreach(Liaison l in el.Liaisons)
                {
                    MessageBox.Show(l.ToString());
                    Pen redPen = new Pen(Color.Red, 1);
                    e.Graphics.DrawLine(redPen, _elements[l.ID1].Position.X, _elements[l.ID1].Position.Y, _elements[l.ID2].Position.X, _elements[l.ID2].Position.Y);
                }
            }
        }

 
    }
}
