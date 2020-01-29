using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ArriveeManuelle : Element
    {
        public static long NbArriveeManuelle;
        private int _id;
        private int _X1;
        private int _Y1;
        private int _xGrid;
        private int _yGrid;
        public string _nom;
        private List<Element> _sorties;
        private List<Element> _entrees;
        private bool _isSelected;
        private string _imgPath;

        public ArriveeManuelle(int x1, int y1)
        {
            _X1 = x1;
            _Y1 = y1;
            _sorties = new List<Element>(0);
            _entrees = new List<Element>(1);

            id = (int)NbArriveeManuelle;
            NbArriveeManuelle += 1;
            _nom = "Arrivee Manuelle" + NbArriveeManuelle;
            _isSelected = false;
            _imgPath = @"Images\img1.jpg";
        }

        public string ImgPath
        {
            get { return _imgPath; }
            set { _imgPath = value; }
        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int X1
        {
            get { return _X1; }
            set { _X1 = value; }
        }
        public int Y1
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

        public List<Element> Sorties
        {
            get { return _sorties; }
            set { _sorties = value; }
        }
        public List<Element> Entrees
        {
            get { return _entrees; }
            set { _entrees = value; }
        }
        public bool isSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

       
        public override string ToString()
        {
            if(Sorties.Count>0)
            {
                return _nom + " X:" + _xGrid + " Y:" + _yGrid + "\n Sortie :" + Sorties[0].ToString();
            }
            return _nom + " X:" + _xGrid + " Y:" + _yGrid + "\n Sortie : NULL";
        }

        public string toJS()
        {           
            string ret = "";
            return ret;
        }

        ~ArriveeManuelle()
        {
            NbArriveeManuelle -= 1;
        }
    }
}

