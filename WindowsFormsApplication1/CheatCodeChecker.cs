using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class CheatCodeChecker
    {
        private readonly Keys[] _keys;
        private Keys[] _keysEntered;

        public CheatCodeChecker(params Keys[] keys)
        {
            _keys = keys;
            _keysEntered = new Keys[keys.Length];
        }

        public void KeyEntered(Keys key)
        {
            for (int i = 0; i < _keysEntered.Length - 1; i++)
            {
                _keysEntered[i] = _keysEntered[i + 1];
            }

            _keysEntered[_keysEntered.Length - 1] = key;

            for (int i = 0; i < _keysEntered.Length; i++)
            {
                if (_keysEntered[i] != _keys[i])
                {
                    return;
                }
            }

            if (CheatCodeEntered != null)
            {
                CheatCodeEntered(this, EventArgs.Empty);
            }
        }



        public event CheatCodeEnteredHander CheatCodeEntered;
    }

    public delegate void CheatCodeEnteredHander(object sender, EventArgs e);
}
