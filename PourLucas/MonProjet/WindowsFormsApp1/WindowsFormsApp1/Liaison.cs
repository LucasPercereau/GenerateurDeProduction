using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Liaison
    {
        private static int nbLiaison=0;
        private int _id1;
        private int _id2;
        public Liaison(int id1,int id2)
        {
            _id1 = id1;
            _id2 = id2;
            nbLiaison++;
        }

        public int ID1
        {
            get { return _id1; }
            set { _id1 = value; }
        }
        public int ID2
        {
            get { return _id2; }
            set { _id2 = value; }
        }
        public int NbLiaisons
        {
            get { return nbLiaison; }
            set { nbLiaison = value; }
        }

        public override string ToString()
        {
            return "L[" + ID1 + ";" + ID2 + "]";
        }
    }
}
