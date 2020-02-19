using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Dynamic;

namespace WindowsFormsApp1
{
    public partial class Element : UserControl
    {

        static int _elementId = 0;
        private int _id;
        private Point _position;
        private string _localisationImage = "";
        private Button[] _tabEntree = null;
        private Button[] _tabSortie = null;
        private Point MouseDownLocation;

        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int ID
        {
            get { return _id; }
        }

        public Button[] TabEntree
        {
            get { return _tabEntree; }
        }

        public Button[] TabSortie
        {
            get { return _tabSortie; }
        }

        public Element(int nbEntree, int nbSortie, string localisation)
        {
            InitializeComponent();
            
            try
            {
                if (localisation != "")
                {
                    _localisationImage = localisation;
                    SetImage(_localisationImage);
                }
                    _tabEntree = new Button[nbEntree];
                    _tabSortie = new Button[nbSortie];

                for (int i = 0; i < nbEntree; i++)
                {
                    Button button = new Button();
                    button.Text = "";
                    button.Name = "buttonEntree" + i;
                    int width = (int)(((double)20 / (100 * ((double)nbEntree / 2))) * this.Size.Width);
                    int height = (int)(((double)20 / (100 * ((double)nbEntree / 2))) * this.Size.Height);
                    button.Size = new Size(width, height);
                    button.Location = new Point(0, (i * this.Size.Height / nbEntree) + (this.Size.Height / (2 * nbEntree)) - (button.Size.Height / 2));
                    this.Controls.Add(button);
                    button.BringToFront();
                    
                    button.MouseClick += new System.Windows.Forms.MouseEventHandler(ClickButtonEntree);

                    _tabEntree[i] = button; //pas sur que ce soit utile // associe juste un boutton avec son état
                }

                for (int i = 0; i < nbSortie; i++)
                {
                    Button button = new Button();
                    button.Name = "buttonSortie" + i;
                    button.Text = "";
                    int width =(int) ((double)20 / (100 * ((double)nbSortie/2)) * this.Size.Width);
                    int height = (int)((double)20 / (100 * ((double)nbSortie/2)) * this.Size.Height);
                    button.Size = new Size(width,height);
                    button.Location = new Point(this.Size.Width-button.Size.Width, (i*this.Size.Height / nbSortie)+ (this.Size.Height / (2 * nbSortie))-(button.Size.Height/2));
                    this.Controls.Add(button);
                    button.BringToFront();

                    button.MouseClick += new System.Windows.Forms.MouseEventHandler(ClickButtonSortie);
                    button.KeyDown += new System.Windows.Forms.KeyEventHandler(Escape) ;
                    _tabSortie[i] = button; 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this._id = _elementId;
            _elementId++;

        }

        private void Escape(object sender, KeyEventArgs e)
        {
            try
            {
                Form1 form1 = (Form1)Form.ActiveForm;
                form1.QuitLinking();
            }
            catch { }
        }
        private void SetImage(string loc)
        {
            Bitmap flag = new Bitmap(loc);
            flag = ResizeBitmap(flag, this.button1.Size.Width, this.button1.Size.Height);
            this.button1.Image = flag;
            this.button1.Text = "";
            this.button1.Refresh();
            this.button1.Visible = true;

        }

        private Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }
            return result;
        }

        private void ClickButtonSortie(object sender, EventArgs e)
        {
            
            Form1 form1 = (Form1)Form.ActiveForm;
            Point p = new Point(((Button)sender).Location.X + (((Button)sender).Parent).Location.X + (((Button)sender).Width / 2), ((Button)sender).Location.Y + (((Button)sender).Parent).Location.Y + (((Button)sender).Height / 2));
            form1.SetForLinking(this,sender);
            try
            {
                foreach (Button b in TabEntree)
                {
                    b.Hide();
                }
            }
            catch { }
        }

        private void ClickButtonEntree(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Form.ActiveForm;
            if (form1.IsLinking)
            {
                try
                {
                    form1.SaveLinking(sender);
                }
                catch { }
            }

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void button1_MouveMove(object sender, MouseEventArgs e)
        {
            Form1 form1 = (Form1)Form.ActiveForm;
            if (!form1.IsLinking)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int left = e.X + this.Left - MouseDownLocation.X;
                    int top = e.Y + this.Top - MouseDownLocation.Y;
                    this.Left = left;
                    this.Top = top;
                    this.Position = new Point(left, top);
                }
            }
            else
            {
                form1.LinkButton.Select();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            Form1 form1 = (Form1)Form.ActiveForm;
            if (!form1.IsLinking)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    Form1 currentForm = (Form1)this.ParentForm;
                    currentForm.DestroyElement(this);
                    this.Dispose();
                }
            }
        }

        public virtual dynamic GenerateJson()
        {
            return null;
        }
    }
}
