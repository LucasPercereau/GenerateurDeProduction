using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class ArriveeManuelle : Element
    {

        public ArriveeManuelle() : base(0,1,@"Images\arriveemanuelle.png")
        {
        }

        public override dynamic GenerateJson()
        {
            dynamic myObject = new ExpandoObject();
            myObject.name = this.GetType().Name;
            myObject.id = this.ID;
            myObject.X = this.Position.X;
            myObject.Y = this.Position.Y;
            return myObject;
        }

    }
}
