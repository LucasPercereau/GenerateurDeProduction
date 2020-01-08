using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Machine : Element
    {
        public static long NbMachine;
        private int _X1;
        private int _Y1;
        private int _xGrid;
        private int _yGrid;
        private string _nom;

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

        public int xGrid
        {
            get { return _xGrid; }
            set { _xGrid = value; }
        }
        public int yGrid
        {
            get { return _yGrid; }
            set { _yGrid = value; }
        }

        public Machine(int x1, int y1)
        {
            _X1 = x1;
            _Y1 = y1;
       
            NbMachine += 1;
            _nom = "Machine" + NbMachine;
        }

        ~Machine()
        {
            NbMachine -= 1;
        }

        public override string ToString()
        {
            return _nom + " X:" + _xGrid + " Y:" + _yGrid;
        }
    }
}
