using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Feu : Element
    {
        public static long NbFeu;
        private int _X1;
        private int _Y1;
        private int _xGrid;
        private int _yGrid;
        public string _nom;
        private List<Element> _sorties;
        private List<Element> _entrees;
        private bool _isSelected;
        private string _imgPath;

        public Feu(int x1, int y1)
        {
            _X1 = x1;
            _Y1 = y1;

            NbFeu += 1;
            _nom = "Feu" + NbFeu;
            _isSelected = false;
            _imgPath = @"Images\img2.jpg";
        }

        public string ImgPath
        {
            get { return _imgPath; }
            set { _imgPath = value; }
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
        bool Element.isSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }


        public override string ToString()
        {
            return _nom + " X:" + _xGrid + " Y:" + _yGrid;
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        ~Feu()
        {
            NbFeu -= 1;
        }
    }
}

