﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    class Machine : Element
    {
        public static long NbMachine;
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

        public Machine(int x1, int y1)
        {
            _X1 = x1;
            _Y1 = y1;

            _sorties = new List<Element>(1);
            _entrees = new List<Element>(1);

            id = (int)NbMachine;
            NbMachine += 1;
            _nom = "Machine" + NbMachine;
            _isSelected = false;
            _imgPath = @"Images\img2.jpg";
        }

        ~Machine()
        {
            NbMachine -= 1;
        }

        public override string ToString()
        {
            return _nom + " X:" + _xGrid + " Y:" + _yGrid;
        }

        public string toJS()
        {
            string sortie = "";
            if (Sorties.Count>0 && Sorties[0] is Convoyeur)
            {
                sortie = "tabConvoyeur[" + Sorties[0].id + "]";
            }

            string ret = "";
            ret += "tabMachine[" + id + "]= new Machine("+xGrid*100+","+(yGrid*100-60)+",10,"+sortie+");\n";
            return ret;
        }
    }
}
