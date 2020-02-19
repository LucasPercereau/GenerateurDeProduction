using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Match : Element
    {
        public Match() : base(2, 1, @"Images\match.jpg")
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
