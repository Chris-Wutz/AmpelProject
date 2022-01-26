using AmpelProjekt.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AmpelProjekt.Business
{
    public class AppMainController
    {
        private MainWindow _main;
        private AmpelGui _selectedAmpelGui;
        private Ampel _ampelLight;
        public AppMainController(MainWindow main)
        {
            _main = main;
            _selectedAmpelGui = null;
            _ampelLight = new Ampel();
            _main.BtnNewAmpel.Click += BtnNewAmpel_Click;
            _main.BtnStartAmpel.Click += BtnStartAmpel_Click;
            _main.BtnSwitchLight.Click += BtnSwitchLight_Click;
            _main.BtnAutomatik.Click += BtnAutomatik_Click;
        }

        private async void BtnAutomatik_Click(object sender, RoutedEventArgs e)
        {
            if(checkIfAmpelGuiIsSet())
                await _selectedAmpelGui.automatikMode();
        }

        private void BtnSwitchLight_Click(object sender, RoutedEventArgs e)
        {
            if(checkIfAmpelGuiIsSet())
                _selectedAmpelGui.setLights(_ampelLight.switchToNextPhase());
        }

        private void BtnStartAmpel_Click(object sender, RoutedEventArgs e)
        {
            if(checkIfAmpelGuiIsSet())
                _selectedAmpelGui.setLights(_ampelLight.start());
        }

        private void BtnNewAmpel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AmpelGui newAmpel = new AmpelGui(this);
            _selectedAmpelGui = newAmpel;
            _selectedAmpelGui.setRecActive();
            _selectedAmpelGui.Show();
        }


        public void setSelectedAmpel(AmpelGui ampel)
        {
            _selectedAmpelGui.setRecActive();
            _selectedAmpelGui = ampel;
        }

        private bool checkIfAmpelGuiIsSet()
        {
            if (_selectedAmpelGui == null)
            {
                MessageBox.Show("Erzeugen Sie erst eine Ampel.");
                return false;
            }
            return true;
        }
    }
}
