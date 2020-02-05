using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
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
        private bool _noise;
        private int nbCell;

        public Form1()
        {
            InitializeComponent();
            nbCell = 20;
            _grille = new Grille(Math.Min(pictureBox1.Size.Width, pictureBox1.Size.Height) / nbCell, nbCell);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.X > nbCell*_grille.tailleCellule || e.Y> nbCell * _grille.tailleCellule) { return; }
            IsMouseDown = true;
            switch(CaseDraw)
            {
                case "Convoyeur":
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
                case "ArriveeManuelle":
                    {
                        ArriveeManuelle AM = new ArriveeManuelle(e.X, e.Y);
                        setToGrid(AM);
                        _grille.add(AM);
                        break;
                    }
                case "ArriveePredefinie":
                    {
                        ArriveePredefinie AP = new ArriveePredefinie(e.X, e.Y);
                        setToGrid(AP);
                        _grille.add(AP);
                        break;
                    }
                case "Match":
                    {
                        Match M = new Match(e.X, e.Y);
                        setToGrid(M);
                        _grille.add(M);
                        break;
                    }
                case "Batch":
                    {
                        Batch B = new Batch(e.X, e.Y);
                        setToGrid(B);
                        _grille.add(B);
                        break;
                    }
                case "UnBatch":
                    {
                        UnBatch UB = new UnBatch(e.X, e.Y);
                        setToGrid(UB);
                        _grille.add(UB);
                        break;
                    }
                case "Aiguillage":
                    {
                        Aiguillage A = new Aiguillage(e.X, e.Y);
                        setToGrid(A);
                        _grille.add(A);
                        break;
                    }
                case "Mux":
                    {
                        Mux M = new Mux(e.X, e.Y);
                        setToGrid(M);
                        _grille.add(M);
                        break;
                    }
                case "Merge":
                    {
                        Merge M = new Merge(e.X, e.Y);
                        setToGrid(M);
                        _grille.add(M);
                        break;
                    }
                case "Feu":
                    {
                        Feu F = new Feu(e.X, e.Y);
                        setToGrid(F);
                        _grille.add(F);
                        break;
                    }
                case "WTEG":
                    {
                        WTEG W = new WTEG(e.X, e.Y);
                        setToGrid(W);
                        _grille.add(W);
                        break;
                    }
                default:
                    {break;}
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
                    case "Convoyeur":
                        {
                            Convoyeur C = new Convoyeur(_StartX, _StartY, _CurX, _CurY);
                            setToGrid(C);
                            _grille.add(C);
                            break;
                        }                    
                    default:
                        {break;}
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
                //SolidBrush Brush = null;
                TextureBrush brush = null;
                /*if (el.isSelected)
                {
                    LinePen = new Pen(Color.Blue, 3);
                    Brush = new SolidBrush(Color.Blue);
                }
                else
                {*/
                    Bitmap bmp = new Bitmap(el.ImgPath);
                    Bitmap result = ResizeBitmap(bmp, _grille.tailleCellule, _grille.tailleCellule);
                    brush = new TextureBrush(result);
                //}
                
                if (el is Convoyeur)
                {
                    LinePen = new Pen(Color.Red, 3);
                    Convoyeur l = (Convoyeur)el;              
                    e.Graphics.DrawLine(LinePen,el.xGrid * _grille.tailleCellule + _grille.tailleCellule / 2, el.yGrid * _grille.tailleCellule + _grille.tailleCellule / 2, l.xGrid2 * _grille.tailleCellule + _grille.tailleCellule / 2, l.yGrid2 * _grille.tailleCellule + _grille.tailleCellule / 2);
                }
                else
                {                   
                    e.Graphics.FillRectangle(brush, (el.xGrid * _grille.tailleCellule + _grille.tailleCellule / 2) - (_grille.tailleCellule - 4) / 2, (el.yGrid * _grille.tailleCellule + _grille.tailleCellule / 2) - (_grille.tailleCellule - 4) / 2, _grille.tailleCellule - 2, _grille.tailleCellule - 2);
                }                                                         
            }
                        
            if (IsMouseDown)
            {
                switch (CaseDraw)
                {
                    case "Convoyeur":
                        {           
                            e.Graphics.DrawLine(new Pen(Color.Blue, 1), _StartX, _StartY, _CurX, _CurY);
                            break;
                        }                    
                    default:
                        {break;}
                }
            }else
            {UpdateList(_grille.LesElements, listBox1.SelectedIndex);}           
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
            if(el is Convoyeur)
            {
                Convoyeur l = (Convoyeur)el;
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
        {
            CaseDraw = "Convoyeur";
            pictureBox4.Image = Image.FromFile(@"Images\img2.jpg");
        }     

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Element el = _grille[listBox1.SelectedIndex];               
                if (el is Convoyeur)
                {
                    el.Entrees[0].Sorties.RemoveAt(0);
                    el.Sorties[0].Entrees.RemoveAt(0);
                }
                _grille.LesElements.RemoveAt(listBox1.SelectedIndex);
                _noise = true;
                listBox1.SelectedIndex = 0;
                _noise = false;
                pictureBox1.Invalidate();
            }
            catch(Exception){}       
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string json = "";
            Element start = _grille[0];
            foreach (Element el in _grille.LesElements)
            {           
                if(el is ArriveeManuelle || el is ArriveePredefinie)
                {
                    json += el.toJS();
                    break;
                }                                              
            }
            File.WriteAllText("../../../../Generation.JSON", json);
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            _grille.tailleCellule = Math.Min(pictureBox1.Size.Width, pictureBox1.Size.Height) / nbCell;
            pictureBox1.Invalidate();
        }
        private void machineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "ArriveeManuelle";
            pictureBox4.Image = Image.FromFile(@"Images\img1.jpg");
        }
        private void arrivéePrédéfinieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "ArriveePredefinie";
            pictureBox4.Image = Image.FromFile(@"Images\img2.jpg");
        }
        private void machine1e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Machine";
            pictureBox4.Image = Image.FromFile(@"Images\machine.png");
        }
        private void match2e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Match";
        }
        private void batch1e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Batch";
        }
        private void unbatch1e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "UnBatch";
        }
        private void aiguillageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Aiguillage";
        }
        private void mux2e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Mux";
        }
        private void merge2e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Merge";
        }
        private void feu1e1sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "Feu";
        }
        private void wTEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseDraw = "WTEG";
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

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nbCell = 10;
            _grille = new Grille(Math.Min(pictureBox1.Size.Width, pictureBox1.Size.Height) / nbCell, nbCell, _grille.LesElements);
            pictureBox1.Invalidate();
        }

        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nbCell = 20;
            _grille = new Grille(Math.Min(pictureBox1.Size.Width, pictureBox1.Size.Height) / nbCell, nbCell, _grille.LesElements);
            pictureBox1.Invalidate();
        }

        private void x50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nbCell = 50;
            _grille = new Grille(Math.Min(pictureBox1.Size.Width, pictureBox1.Size.Height) / nbCell, nbCell, _grille.LesElements);
            pictureBox1.Invalidate();
        }
    }
}
