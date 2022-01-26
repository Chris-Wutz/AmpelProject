using AmpelProjekt.Business;
using AmpelProjekt.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AmpelProjekt
{
    /// <summary>
    /// Interaktionslogik für AmpelGui.xaml
    /// </summary>
    public partial class AmpelGui : Window
    {
        private AppMainController _controller;
        private bool _runAutomaik;
        public AmpelGui(AppMainController contoller)
        {
            InitializeComponent();
            _controller = contoller;
            _runAutomaik = false;
            RedEllipse.Fill = Brushes.Black;
            OrangeEllipse.Fill = Brushes.Black;
            GreenEllipse.Fill = Brushes.Black;
            RecActive.Fill = Brushes.ForestGreen;
        }

        internal void setLights(Light light)
        {
            switch (light)
            {
                case Light.redOrange:
                    activateRed();
                    activateOrange();
                    deactivateGreen();
                    break;
                case Light.red:
                    activateRed();
                    deactivateOrange();
                    deactivateGreen();
                    break;
                case Light.orange:
                    deactivateRed();
                    activateOrange();
                    deactivateGreen();
                    break;
                case Light.green:
                    activateGreen();
                    deactivateRed();
                    deactivateOrange();
                    break;
            }
        }

        public void activateRed()
        {
            RedEllipse.Fill = Brushes.Red;
        }

        public void activateOrange()
        {
            OrangeEllipse.Fill = Brushes.Orange;
        }

        public void activateGreen()
        {
            GreenEllipse.Fill = Brushes.Green;
        }

        public void deactivateRed()
        {
            RedEllipse.Fill = Brushes.Black;
        }

        public void deactivateOrange()
        {
            OrangeEllipse.Fill = Brushes.Black;
        }

        public void deactivateGreen()
        {
            GreenEllipse.Fill = Brushes.Black;
        }

        public void setRecActive()
        {
            if (RecActive.Fill == Brushes.Black)
                RecActive.Fill = Brushes.ForestGreen;
            else
                RecActive.Fill = Brushes.Black;
        }

        public async Task<int> automatikMode()
        {
            _runAutomaik = !_runAutomaik;
            while (_runAutomaik)
            {
                foreach (Light l in (Light[])Enum.GetValues(typeof(Light)))
                {
                    setLights(l);
                    await Task.Delay(1000);
                }
            }
            return 1;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _controller.setSelectedAmpel(this);
            setRecActive();
        }
    }
}
