using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Ligne : Element
    {
        public static long NbLignes;
        private int _X1;
        private int _Y1;
        private int _X2;
        private int _Y2;
        private int _xGrid;
        private int _yGrid;
        private int _xGrid2;
        private int _yGrid2;
        private string _nom;

        public int X2
        {
            get { return _X2; }
            set { _X2 = value; }
        }
        public int Y2
        {
            get { return _Y2; }
            set { _Y2 = value; }
        }
        int Element.xGrid
        {
            get { return _xGrid; }
            set { _xGrid = value; }
        }
        int Element.yGrid
        {
            get { return _yGrid; }
            set { _yGrid = value; }
        }
        public int xGrid2
        {
            get { return _xGrid2; }
            set { _xGrid2 = value; }
        }
        public int yGrid2
        {
            get { return _yGrid2; }
            set { _yGrid2 = value; }
        }
        int Element.X1
        {
            get { return _X1; }
            set { _X1 = value; }
        }
        int Element.Y1
        {
            get { return _Y1; }
            set { _Y1 = value; }
        }

        public Ligne(int x1, int y1, int x2, int y2)
        {
            _X1 = x1;
            _Y1 = y1;
            _X2 = x2;
            _Y2 = y2;
            NbLignes += 1;
            _nom = "Ligne" + NbLignes;
        }

        ~Ligne()
        {
            NbLignes -= 1;
        }

        public override string ToString()
        {
            return _nom + " X:"+_xGrid+" Y:"+_yGrid;
        }
    }
}
