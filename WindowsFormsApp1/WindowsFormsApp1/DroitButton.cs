using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DroitButton
    {
        private bool _buttonActif;
        private Button _button;

        public DroitButton(bool etat, Button button)
        {
            _buttonActif = etat;
            _button = button;
        }
    }
}
