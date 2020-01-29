using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Convoyeur : Element
    {
        public static long NbLignes;
        private int _id;
        private int _X1;
        private int _Y1;
        private int _X2;
        private int _Y2;
        private int _xGrid;
        private int _yGrid;
        private int _xGrid2;
        private int _yGrid2;
        private string _nom;
        private List<Element> _sorties;
        private List<Element> _entrees;
        private bool _isSelected;
        private string _imgPath;

        public Convoyeur(int x1, int y1, int x2, int y2)
        {
            _X1 = x1;
            _Y1 = y1;
            _X2 = x2;
            _Y2 = y2;

            _sorties = new List<Element>(1);
            _entrees = new List<Element>(1);

            id = (int)NbLignes;
            NbLignes += 1;
            _nom = "Ligne" + NbLignes;
            _isSelected = false;
            _imgPath = @"Images\img3.jpg";
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
            return _nom + " X:" + _xGrid + " Y:" + _yGrid;
        }
        public string toJS()
        {
            string sortie = "";
            if (Sorties.Count>0 && Sorties[0] is Machine)
            {
                sortie = "tabStock["+ Sorties[0].id+"]";
            }
            
            string ret = "";
            ret += "tabConvoyeur["+id+"]= new convoyeur("+ xGrid*100 + ","+yGrid*100+","+(xGrid2*100-xGrid*100)+",20,"+sortie+");\n";
            return ret;
        }
        ~Convoyeur()
        {
            NbLignes -= 1;
        }        
    }
}
