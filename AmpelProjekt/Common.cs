using AmpelProjekt.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpelProjekt
{
    public static class Common
    {
        private static AppMainController _controller;
        public static void init()
        {
            MainWindow main = new MainWindow();
            _controller = new AppMainController(main);
            main.Show();
        }
    }
}
