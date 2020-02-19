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
using System.Reflection;
using System.Dynamic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Element> _elements;
        private List<int[]> _liaisons;
        private List<Button[]> _lignes;
        private bool _drawingLink = false;
        private Point MouseDownLocationLigne;
        private Element _elementdepartLigne;
        private Button _debutLigne;
        private Graphics graph;
        public bool IsLinking
        {
            get { return _drawingLink; }
            set { _drawingLink = value; }
        }

        public Button LinkButton
        {
            get { return _debutLigne; }
        }
        public Form1()
        {
            _elements = new List<Element>();
            _lignes = new List<Button[]>();
            _liaisons = new List<int[]>();
            InitializeComponent();
            graph = this.splitContainer1.Panel2.CreateGraphics();            
        }

        private void splitContainer1_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsLinking)
            {
                this.splitContainer1.Panel1.Enabled = true; 
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
                            case "Convoyeur":
                                Convoyeur convoyeur = new Convoyeur();
                                this.splitContainer1.Panel2.Controls.Add(convoyeur);
                                convoyeur.Position = convoyeur.Location = new Point(e.Location.X - (convoyeur.Width / 2), e.Location.Y - (convoyeur.Height / 2));
                                this.listBox1.SelectedIndex = -1;
                                _elements.Add(convoyeur);
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
        }

        public void DestroyElement(Element element) //verifier que les tables sont biens vidées à la suppression
        {
            List<Button[]> copieLignes = new List<Button[]>(_lignes.Count);
            _lignes.ForEach((item) =>
            {
                copieLignes.Add(item);
            });

            List<int[]> copieLiaison = new List<int[]>(_liaisons.Count);
            _liaisons.ForEach((item) =>
            {
                copieLiaison.Add(item);
            });


            foreach(Button[] tab in copieLignes)
            {
                foreach(Button b in tab)
                {
                    if (((Element)b.Parent).ID == element.ID)
                    {
                        _lignes.Remove(tab);
                    }
                }
            }

            foreach(int[] tabInt in copieLiaison)
            {
                foreach(int i in tabInt)
                {
                    if (i == element.ID)
                    {
                        _liaisons.Remove(tabInt);
                    }
                }
            }

            Console.WriteLine(_lignes.Count);
            Console.WriteLine(_liaisons.Count);

            for (int i=0; i < _elements.Count; i++)
            {
                if(_elements[i].ID == element.ID)
                {
                    _elements.RemoveAt(i);
                }
            }
            QuitLinking();
        }

        private void générerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<dynamic> list = new List<dynamic>();
           foreach(Element el in _elements)
            {
                list.Add(el.GenerateJson());
            }
           foreach(int[] tab in _liaisons)
            {
                dynamic myObject = new ExpandoObject();
                myObject.name = "liaison";
                myObject.element1 = tab[0];
                myObject.element2 = tab[1];
                list.Add(myObject);
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
            if (IsLinking)
            {
                MouseDownLocationLigne = e.Location;
                this.splitContainer1.Panel2.Invalidate();
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (IsLinking)
            {
                Point point= new Point(_debutLigne.Location.X + (_debutLigne.Parent).Location.X + (_debutLigne.Width / 2), (_debutLigne.Location.Y + ((_debutLigne.Parent).Location.Y + (_debutLigne.Height / 2))));
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graph.DrawLine(Pens.Black,point,MouseDownLocationLigne);
                foreach (Button[] tab in _lignes)
                {
                    Point point1 = new Point(tab[0].Location.X + (tab[0].Parent).Location.X + (tab[0].Width / 2), (tab[0].Location.Y + ((tab[0].Parent).Location.Y + (tab[0].Height / 2))));
                    Point point2 = new Point(tab[1].Location.X + (tab[1].Parent).Location.X + (tab[1].Width / 2), (tab[1].Location.Y + ((tab[1].Parent).Location.Y + (tab[1].Height / 2))));
                    graph.DrawLine(Pens.Black, point1, point2);
                }
            }
            else
            {
                //Graphics graph= this.splitContainer1.Panel2.CreateGraphics();
                graph.Clear(this.splitContainer1.Panel2.BackColor);
                foreach (Button[] tab in _lignes)
                {
                    Point point1 = new Point(tab[0].Location.X + (tab[0].Parent).Location.X + (tab[0].Width / 2), (tab[0].Location.Y + ((tab[0].Parent).Location.Y + (tab[0].Height / 2))));
                    Point point2 = new Point(tab[1].Location.X + (tab[1].Parent).Location.X + (tab[1].Width / 2), (tab[1].Location.Y + ((tab[1].Parent).Location.Y + (tab[1].Height / 2))));
                    graph.DrawLine(Pens.Black, point1, point2);
                }
            }
        }

        public void SetForLinking(Element element, object sender)
        {
            IsLinking = true;
            this.splitContainer1.Panel1.Enabled = false;
            _elementdepartLigne = element;
            _debutLigne = (Button)sender;  //faire autrement pour être sur que le trait suive l'element 
            foreach(Element el in _elements)
            {/*
               Button button = (Button)el.Controls.Find("button1", true).First();
                if(el.Controls.Find("button1", true).First() != null)
                {
                    button.Enabled = false;
                }*/
                try
                {
                    foreach (Button b in el.TabSortie)
                    {
                        if (el.ID == ((Element)(((Button)sender).Parent)).ID && b.Name == ((Button)sender).Name) { }
                        else { b.Hide(); }
                    }
                }
               catch { }
            }
        }

        public void QuitLinking()
        {
            IsLinking = false;
            _elementdepartLigne = null;
            foreach (Element el in _elements)
            {
                /*Button button = (Button)el.Controls.Find("button1", true).First();
                if (el.Controls.Find("button1", true).First() != null)
                {
                    button.Enabled = true;
                }*/
                try
                {
                   foreach(Button b in el.TabSortie)
                    {
                        b.Show();
                        foreach(Button[] tab in _lignes)
                        {
                            foreach(Button bu in tab)
                            {
                                if(b.Name == bu.Name)
                                {
                                    if (((Element)b.Parent).ID == ((Element)bu.Parent).ID)
                                    {
                                        b.Hide();
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                try
                {
                    foreach (Button b in el.TabEntree)
                    {
                        b.Show();
                        foreach (Button[] tab in _lignes)
                        {
                            foreach (Button bu in tab)
                            {
                                if (b.Name == bu.Name)
                                {
                                    if (((Element)b.Parent).ID == ((Element)bu.Parent).ID)
                                    {
                                        b.Hide();
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
           this.splitContainer1.Panel2.Invalidate();
            this.splitContainer1.Panel1.Enabled = true; 
        }

        public void SaveLinking(object sender)
        {
            Point point = new Point(_debutLigne.Location.X + (_debutLigne.Parent).Location.X + (_debutLigne.Width / 2), (_debutLigne.Location.Y + ((_debutLigne.Parent).Location.Y + (_debutLigne.Height / 2))));
            _lignes.Add(new Button[2] { _debutLigne, (Button)sender });
            _liaisons.Add(new int[2] { _elementdepartLigne.ID, ((Element)(((Button)sender).Parent)).ID });
            QuitLinking();
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            graph = this.splitContainer1.Panel2.CreateGraphics();
        }
    }
}

