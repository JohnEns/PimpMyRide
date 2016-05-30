using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PimpMyRide
{
    class Auto
    {
        // Fields
        string merk;
        string model;
        int bouwjaar;
        string toevoeging1;
        string toevoeging2;
        string toevoeging3;
        string toevoeging4;
        string toevoeging5;
        int aantalGeplaatsteToevoegingen;

        // Constructor
        public Auto(string autoMerk, string autoModel, int autoBouwjaar)
        {
            // Stap 2
            // De waarden van de Parameters dienen opgeslagen te worden in 
            // de bijbehorende Fields.
            this.merk = autoMerk;
            this.model = autoModel;
            this.bouwjaar = autoBouwjaar;
            aantalGeplaatsteToevoegingen = 0;

        }

        //Methods
        public string GeefBeschrijving()
        {
            // Stap 2
            // Retourneer een samengestelde string van het merk, model en bouwjaar van de auto.
            
            // Vervang onderstaande regel door je eigen code.
            return merk + " " + model + " " + bouwjaar;
        }

        public bool InstalleerEenToevoeging(string omschrijving)
        {
            // Stap 4
            // Als deze auto reeds 5 toevoegingen heeft dan kan er geen toevoeging gedaan worden en 
            // retourneert deze methode 'false'.+
            // Anders, wordt er gekeken hoeveel toevoegingen er al gedaan zijn en wordt het Field met
            // waar de volgende toevoeging bewaard dient te worden, gevuld met de Parameter omschrijving.
            // Daarna wordt 'aantalGeplaatsteToevoegingen' met 1 opgehoogd en retourneert deze
            // methode 'true'.

            // Vervang onderstaande regel door je eigen code.
                switch(aantalGeplaatsteToevoegingen)
                {
                    case 0:
                        toevoeging1 = omschrijving;
                        aantalGeplaatsteToevoegingen++;
                        return true;
                    case 1:
                        toevoeging2 = omschrijving;
                        aantalGeplaatsteToevoegingen++;
                        return true;
                    case 2:
                        toevoeging3 = omschrijving;
                        aantalGeplaatsteToevoegingen++;
                        return true;
                    case 3:
                        toevoeging4 = omschrijving;
                        aantalGeplaatsteToevoegingen++;
                        return true;
                    case 4:
                        toevoeging5 = omschrijving;
                        aantalGeplaatsteToevoegingen++;
                        return true;
                    default:
                        MessageBox.Show("Helaas, je kunt maximaal 5 toevoegingen doen", "Toevoegen mislukt!");
                        return false;
                }
        }

        public bool IsCool()
        {
            // Stap 5
            // Indien het aantal geplaatste toevoegingen gelijk is aan 5,
            // dan is deze auto cool, retourneer dan 'true', anders 'false'.

            // Vervang onderstaande regel door je eigen code.
            // En deze info is allen maar bedoeld om GitHub te testen...
            // Meer testmateriaal
              
            if(aantalGeplaatsteToevoegingen == 5)
                {
                        return true;
                }
             return false;
        }

        public string GeefToevoegingen()
        {
            // Stap 5
            // Retourneer een samengestelde string van alle 5 de toevoegingen van deze auto.

            // Vervang onderstaande regel door je eigen code.
            return toevoeging1 + Environment.NewLine + toevoeging2 + Environment.NewLine + toevoeging3 + Environment.NewLine + toevoeging4 + Environment.NewLine + toevoeging5;
        }
    }
}
