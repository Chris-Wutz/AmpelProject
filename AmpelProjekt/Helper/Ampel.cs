using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;

namespace AmpelProjekt.Helper
{
    public class Ampel
    {
        private Light _currentLight;
        public Light start()
        {
            _currentLight = Light.green;
            return _currentLight;
        }

        public Light switchToNextPhase()
        {
            switch(_currentLight)
            {
                case Light.redOrange:
                    _currentLight = Light.green;
                    break;
                case Light.red:
                    _currentLight = Light.orange;
                    break;
                case Light.orange:
                    _currentLight = Light.green;
                    break;
                case Light.green:
                    _currentLight = Light.red;
                    break;
            }

            return _currentLight;
        }
    }

    public enum Light
    {
        redOrange,
        red,
        orange,
        green,
    }

}
