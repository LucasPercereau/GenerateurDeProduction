using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestDragDrop
{
    /// <summary>
    /// Logique d'interaction pour Circle.xaml
    /// </summary>
    public partial class Circle : UserControl
    {
        private Brush _previousFill = null;
        public Circle()
        {
            InitializeComponent();
        }

        public Circle(Circle c)
        {
            InitializeComponent();
            this.circleUI.Height = c.circleUI.Height;
            this.circleUI.Width = c.circleUI.Width;
            this.circleUI.Fill = c.circleUI.Fill;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                //Package the data
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, circleUI.Fill.ToString());
                data.SetData("Double", circleUI.Height);
                data.SetData("Object", this);

                //Initiate the drag-and-drop operation
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            //these effects values are set in the drop target's dragover event handler
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            //If the DataObject contains string data, exctact it
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // if the string can be converted into a Brush convert and apply to the ellipse
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString);
                    circleUI.Fill = newFill;

                    //set effects to notify the drag source what effect the drag drop opperation had
                    //copy if ctrl is pressed; otherwise, move
                    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.None;

            //if the dataobject contains string data, extract it
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                //if the string car be converted int oa brus, allow copying or moving
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            //save current brush
            _previousFill = circleUI.Fill;

            //if the dataobject contains string data extract it
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                //if the string can be converted into a brush
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString.ToString());
                    circleUI.Fill = newFill;
                }
            }
        }

        protected override void OnDragLeave(DragEventArgs e)
        {
            base.OnDragLeave(e);
            //undo the preview did in OnDragEnter
            circleUI.Fill = _previousFill;
        }
    }
}
