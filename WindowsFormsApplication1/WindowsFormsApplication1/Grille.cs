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
        private Element _FirstElement;

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
        public Element FirstElement
        {
            get { return _FirstElement; }
            set { _FirstElement = value; }
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
                Element prov1 = null;
                Element prov2 = null;
                foreach (Element li in LesElements)
                {
                    if (li is Ligne && el.xGrid == li.xGrid && el.yGrid == li.yGrid)
                    {
                        return false;
                    }
                }
                foreach (Element element in LesElements)
                {
                    if(el.xGrid == element.xGrid && el.yGrid == element.yGrid)
                    {
                        flag1 = true;
                        prov1 = element;
                    }
                    if (l.xGrid2 == element.xGrid && l.yGrid2 == element.yGrid)
                    {
                        flag2 = true;
                        prov2 = element;
                    }
                }
                if(FirstElement!=null && el.xGrid == FirstElement.xGrid && el.yGrid == FirstElement.yGrid)
                {
                    flag1 = true;
                    prov1 = FirstElement;
                }
                if (!flag1 || !flag2)
                {
                    return false;
                }else
                {
                    l.ElemPrec = prov1;
                    l.ElemSuiv = prov2;
                    prov1.ElemSuiv = prov2;
                    //prov2.ElemPrec = prov1;
                }
                
            }
            else if (el is Machine)
            {
                foreach (Element element in LesElements)
                {
                    if (el.xGrid == element.xGrid && el.yGrid == element.yGrid)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (_FirstElement == null) { _FirstElement = el;}
                else { return false; }
            }                              
            _LesElements.Add(el);
            return true;
        }
    }
}
