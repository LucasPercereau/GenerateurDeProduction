using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    interface Element
    {
        int xGrid
        {
            get;
            set;
        }
        int yGrid
        {
            get;
            set;
        }
        int X1
        {
            get;
            set;
        }
        int Y1
        {
            get;
            set;
        }
        bool isSelected
        {
            get;
            set;
        }

        Element ElemPrec
        {
            get;
            set;
        }
        Element ElemSuiv
        {
            get;
            set;
        }
    }
}
