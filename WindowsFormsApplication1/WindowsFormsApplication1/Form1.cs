using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool IsMouseDown = false;
        private int _StartX;
        private int _StartY;
        private int _CurX;
        private int _CurY;
        private string CaseDraw = "Ligne";
        private Grille _grille;
        private int tailleGrille;
    
        public Form1()
        {
            InitializeComponent();
            tailleGrille = pictureBox1.Size.Height;
            _grille = new Grille(tailleGrille/10,10);        
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            switch(CaseDraw)
            {
                case "Ligne":
                    {
                        _StartX = e.X;
                        _StartY = e.Y;
                        _CurX = _StartX;
                        _CurY = _StartY;
                        break;
                    }      
                case "Machine":
                    {
                        Machine M = new Machine(e.X, e.Y);
                        setToGrid(M);
                        _grille.add(M);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen dashed_pen = new Pen(Color.Green, 1);
            dashed_pen.DashStyle = DashStyle.Dash;
            if (IsMouseDown == false) return;
            _CurX = e.X;
            _CurY = e.Y;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;

            if (e.Button == MouseButtons.Left)
            {
                switch (CaseDraw)
                {
                    case "Ligne":
                        {                                                   
                            Ligne L = new Ligne(_StartX, _StartY, _CurX, _CurY);
                            setToGrid(L);
                            _grille.add(L);
                            break;
                        }
                    case "Machine":
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            pictureBox1.Invalidate();
        }

        //Dessin de la fenetre
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            UpdateList(_grille.LesElements);
            paintGrid(e);
            foreach (Element el in _grille.LesElements)
            {
                setToGrid(el);
                Pen LinePen = new Pen(Color.FromArgb(255, 255, 0, 0), 3);
                if (el is Ligne)
                {
                    Ligne l = (Ligne)el;              
                    e.Graphics.DrawLine(LinePen,el.xGrid * _grille.tailleCellule + _grille.tailleCellule / 2, el.yGrid * _grille.tailleCellule + _grille.tailleCellule / 2, l.X2, l.Y2);
                }
                if(el is Machine)
                {
                    e.Graphics.DrawRectangle(LinePen, el.xGrid*_grille.tailleCellule + _grille.tailleCellule / 2, el.yGrid* _grille.tailleCellule + _grille.tailleCellule / 2, 10, 10);
                }
            }
        
            
            if (IsMouseDown)
            {
                switch (CaseDraw)
                {
                    case "Ligne":
                        {           
                            e.Graphics.DrawLine(new Pen(Color.Blue, 1), _StartX, _StartY, _CurX, _CurY);
                            break;
                        }
                    case "Machine":
                        {break;}
                    default:
                        {break;}
                }
            }           
        }

        public void paintGrid(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y <= _grille.nbCellule; y++)
            {
                g.DrawLine(p, 0, y * _grille.tailleCellule, _grille.nbCellule * _grille.tailleCellule, y * _grille.tailleCellule);
            }

            for (int x = 0; x <= _grille.nbCellule; x++)
            {
                g.DrawLine(p, x * _grille.tailleCellule, 0, x * _grille.tailleCellule, _grille.nbCellule * _grille.tailleCellule);
            }          
        }
        
        private void setToGrid(Element el)
        {
            if(el is Ligne)
            {
                Ligne l = (Ligne)el;
                l.yGrid2 = (l.Y2) * _grille.nbCellule / (_grille.nbCellule * _grille.tailleCellule);
                l.xGrid2 = (l.X2) * _grille.nbCellule / (_grille.nbCellule * _grille.tailleCellule);
            }
            el.yGrid = (el.Y1)* _grille.nbCellule / (_grille.nbCellule * _grille.tailleCellule);
            el.xGrid = (el.X1)* _grille.nbCellule / (_grille.nbCellule * _grille.tailleCellule);
        }

        private void UpdateList(List<Element> list)
        {
            listBox1.Items.Clear();
            foreach (Element el in list)
            {
                listBox1.Items.Add(el);
            }
        }

        private bool Delete(Ligne ligne)
        {
            return false;
        }

        //Boutons canva
        private void button1_Click(object sender, EventArgs e)
        {CaseDraw = "Ligne";}

        private void button2_Click(object sender, EventArgs e)
        {CaseDraw = "Machine";}

        private void button3_Click(object sender, EventArgs e)
        {}

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                _grille.LesElements.RemoveAt(listBox1.SelectedIndex);
                pictureBox1.Invalidate();
            }
            catch(Exception){}       
        }    
    }
}
