using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Convoyeur :Element
    {
        private List<int[]> _segment;
        private int[] _currentSegment;
        public Convoyeur() :base(1,1,@"Images\convoyeur.png")
        {
            _segment = new List<int[]>();
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
        
        public void StartDraw(object sender, EventArgs e)
        {
            _currentSegment = new int[2];
            _currentSegment[0] = ((Button)sender).Location.X+ (((Button)sender).Parent).Location.X;
            _currentSegment[1] = ((Button)sender).Location.Y + (((Button)sender).Parent).Location.Y;
            _segment.Insert(0, _currentSegment);
            Console.WriteLine("");
            Console.Write(_segment[0][0]);
            Console.Write(";");
            Console.Write(_segment[0][1]);
        }

        public void AddSegment()
        {

        }

        public void Draw(object sender,PaintEventArgs e, Point p)
        {
            using (Pen pen = new Pen(Color.Black, 3))
            {
                e.Graphics.DrawLine(pen, new Point(_segment[_segment.Count-1][0], _segment[_segment.Count-1][1]),p);
            }
        }
    }
}
