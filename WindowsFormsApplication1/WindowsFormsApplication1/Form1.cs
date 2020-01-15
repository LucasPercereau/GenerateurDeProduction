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
using Newtonsoft.Json;
using System.IO;

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
        private bool _noise;

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
                case "FirstElement":
                    {
                        FirstElement F = new FirstElement(e.X, e.Y);
                        setToGrid(F);
                        _grille.add(F);
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
                        { break; }
                    case "FirstElement":
                        { break; }
                    default:
                        {
                            break;
                        }
                }
            }
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Dessin de la fenetre
        /// </summary>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {         
            paintGrid(e);
            foreach (Element el in _grille.LesElements)
            {
                Pen LinePen = null;
                SolidBrush Brush = null;
                if (el.isSelected)
                {
                    LinePen = new Pen(Color.Blue, 3);
                    Brush = new SolidBrush(Color.Blue);
                }
                else
                {
                    LinePen = new Pen(Color.FromArgb(255, 255, 0, 0), 3);
                    Brush = new SolidBrush(Color.Red);
                }
                
                if (el is Ligne)
                {
                    Ligne l = (Ligne)el;              
                    e.Graphics.DrawLine(LinePen,el.xGrid * _grille.tailleCellule + _grille.tailleCellule / 2, el.yGrid * _grille.tailleCellule + _grille.tailleCellule / 2, l.xGrid2 * _grille.tailleCellule + _grille.tailleCellule / 2, l.yGrid2 * _grille.tailleCellule + _grille.tailleCellule / 2);
                }
                if(el is Machine)
                {
                    e.Graphics.FillRectangle(Brush, (el.xGrid*_grille.tailleCellule + _grille.tailleCellule / 2) -5, (el.yGrid* _grille.tailleCellule + _grille.tailleCellule / 2) -5, 10, 10);
                }    
                if(el is FirstElement)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), (_grille.FirstElement.xGrid * _grille.tailleCellule + _grille.tailleCellule / 2) - 5, (_grille.FirstElement.yGrid * _grille.tailleCellule + _grille.tailleCellule / 2) - 5, 10, 10);
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
                    case "FirstElement":
                        {break;}
                    default:
                        {break;}
                }
            }else
            {
                UpdateList(_grille.LesElements, listBox1.SelectedIndex);
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

        private void UpdateList(List<Element> list,int idx)
        {
            listBox1.Items.Clear();
            foreach (Element el in list)
            {
                listBox1.Items.Add(el);
            }
            _noise = true;
            if (idx < _grille.LesElements.Count) { listBox1.SelectedIndex = idx; }            
            _noise = false;
        }

        //Boutons canva
        private void button1_Click(object sender, EventArgs e)
        {CaseDraw = "Ligne";}

        private void button2_Click(object sender, EventArgs e)
        {CaseDraw = "Machine";}

        private void button3_Click(object sender, EventArgs e)
        { CaseDraw = "FirstElement"; }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if(listBox1.SelectedItem is FirstElement)
                {
                    _grille.FirstElement = null;
                }
                                
                _grille.LesElements.RemoveAt(listBox1.SelectedIndex);                                              
                _noise = true;
                listBox1.SelectedIndex = 0;
                _noise = false;
                pictureBox1.Invalidate();
            }
            catch(Exception){}       
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noise) return;
            try
            {
                foreach (Element el in _grille.LesElements)
                {
                    el.isSelected = false;
                }
                _grille.LesElements[listBox1.SelectedIndex].isSelected = true;            
                pictureBox1.Invalidate();                
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string json = "";
            foreach (Element el in _grille.LesElements)
            {
                if(el is Machine)
                {
                    Machine m = (Machine)el;
                    json += m.GetJson();
                }               
            }        
            File.WriteAllText("BONJOUR", json);
        }
    }
}
