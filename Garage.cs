using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PimpMyRide
{
    class Garage
    {
        // Fields
        string naam;

        // Constructor
        public Garage(string garageNaam)
        {
            naam = garageNaam;
        }

        //Methods
        public string GeefNaam()
        {
            return naam;
        }

        public void VoegEenSpoilerToe(Auto auto, string omschrijving)
        {
            omschrijving = "Spoiler: " + omschrijving;
            if(auto.InstalleerEenToevoeging(omschrijving))
            {
                MessageBox.Show("Spoiler is gePIMPt", "Spoiler toegevoegd");
            }
        }

        public void VoegSpeakersToe(Auto auto, string omschrijving)
        {
            omschrijving = "Speakers: " + omschrijving;
            if(auto.InstalleerEenToevoeging(omschrijving))
            {
                MessageBox.Show("Speakers zijn gePIMPt", "Speakers toegevoegd");
            }
        }

        public void VoegLCDSchermToe(Auto auto, string omschrijving)
        {
            omschrijving = "LCDScherm: " + omschrijving;
            if(auto.InstalleerEenToevoeging(omschrijving))
            {
                MessageBox.Show("LCD-scherm is gePIMPt", "LCD-scherm toegevoegd");
            }
        }

        public void VoegVelgenToe(Auto auto, string omschrijving)
        {
            omschrijving = "Velgen: " + omschrijving;
            if(auto.InstalleerEenToevoeging(omschrijving))
            {
                MessageBox.Show("Velgen zijn gePIMPt", "Velgen toegevoegd");
            }
            
        }

        public void VoegOverspuitenToe(Auto auto, string omschrijving)
        {
            omschrijving = "Overspuiten: " + omschrijving;
            if (auto.InstalleerEenToevoeging(omschrijving))
            {
                MessageBox.Show("Chassis is gePIMPt", "Auto is overgespoten");
            }
        }
    }
}
