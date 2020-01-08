using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Grille
    {
        private int _tailleCellule;
        private int _nbCellule;
        private List<Element> _LesElements;

        public Grille(int taille,int nb)
        {
            _LesElements = new List<Element>();
            _tailleCellule = taille;
            _nbCellule = nb;
        }

        public int tailleCellule
        {
            get { return _tailleCellule; }
            set { _tailleCellule = value; }
        }
        public int nbCellule
        {
            get { return _nbCellule; }
            set { _nbCellule = value; }
        }
        public List<Element> LesElements
        {
            get { return _LesElements; }
            set { _LesElements = value; }
        }

        public bool add(Element el)
        {        
            if(el is Ligne)
            {
                Ligne l = (Ligne)el;
                bool flag1 = false;
                bool flag2 = false;
                foreach (Element element in LesElements)
                {
                    if(el.xGrid == element.xGrid && el.yGrid == element.yGrid)
                    {
                        flag1 = true;
                    }
                    if (l.xGrid2 == element.xGrid && l.yGrid2 == element.yGrid)
                    {
                        flag2 = true;
                    }
                }
                if(!flag1 || !flag2)
                {
                    return false;
                }
            }
            else
            {
                foreach (Element element in LesElements)
                {
                    if (el.xGrid == element.xGrid && el.yGrid == element.yGrid)
                    {
                        return false;
                    }
                }
            }                              
            _LesElements.Add(el);
            return true;
        }
    }
}
