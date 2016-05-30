using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PimpMyRide
{
    public partial class MainForm : Form
    {
        // Fields
        Auto auto;
        Garage garage;

        /// <summary>
        /// Deze integer haalt het huidige jaar op. Zo kun je de bovengrens aangeven wat er ingevuld kan worden als bouwjaar.
        /// </summary>
        int currentYear = DateTime.Now.Year;

        /// <summary>
        /// Class om de resultaten van de invoer-check netjes weer te geven
        /// </summary>
        public class Result
        {
            public bool Success;
            public string ErrorMessage;
            public string ErrorTitle;
        }

        /// <summary>
        /// Deze methode controleert invoer. C = true voor INTEGER; C = false voor STRING
        /// </summary>
        /// <param name="TB"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public Result CheckInput(TextBox TB, bool C)
        { 
            Result result = new Result();

            if (!string.IsNullOrWhiteSpace(TB.Text))
            {
                //Controle-sectie voor input van integer
                if (C == true)
                {
                    try
                    {
                        int doubleCheck = Convert.ToInt32(TB.Text);
                    }
                    catch (Exception )
                    {
                        result.ErrorMessage = "Vul alsjeblieft een correct bouwjaar in";
                        result.ErrorTitle = "Bouwjaar incorrect";
                        result.Success = false;
                    }

                    //Controleer met behulp van lokale variabele bj of er inderdaad 4 getallen zijn ingevuld tussen 1880 en het huidige jaar.
                    int bj;
                    if (int.TryParse(TB.Text, out bj))
                    {
                        if (bj >= 1880 && bj <= currentYear)
                        {
                            //Het opgegeven getal is echt een getal en het is een geldig bouwjaar
                            result.Success = true;
                        }
                        else
                        {
                            //De input voor Bouwjaar is geen getal                                
                            result.ErrorMessage = "Vul alsjeblieft een correct bouwjaar in";
                            result.ErrorTitle = "Bouwjaar incorrect";
                            result.Success = false;
                        }
                    }
                }
                    //Controle sectie voor strings
                else
                {
                    //Dit is opgegeven tekst en dus OK
                    result.Success = true;
                }
            }
            else
            {
                //Geen informatie ingevuld
                result.ErrorMessage = "Vul alsjeblieft alle velden in";
                result.ErrorTitle = "Er mist informatie";
                result.Success = false;
            }
            return result;
        }

        /// <summary>
        /// Controleert mbv CheckInput of de ingevulde info correct is en geeft de foutmeldingen door indien info foutief is
        /// </summary>
        /// <param name="TT"></param>
        /// <param name="D"></param>
        /// <returns></returns>
        private bool IsInputCorrect(TextBox TT, bool D)
        {
            Result result = CheckInput(TT, D);
            if (result.Success == true)
            {
                //alles is dus goed. Code draait door
                return true;
            }
            else
            {
                //Geef de foutmeldingen weer
                MessageBox.Show(result.ErrorMessage, result.ErrorTitle);
                return false;
            }
        }

            
        // Constructor
        public MainForm()
        {
            InitializeComponent();
            gbToevoegingen.Enabled = false;

            garage = new Garage("West Coast Customs");

            this.Text += " - " + garage.GeefNaam();
        }

        // Methods
        private void btnBrengBinnen_Click(object sender, EventArgs e)
        {
            // Stap 1
            // Valideer de ingevoerde waarden van het Form en geef foutmeldingen
            // als de ingevoerde waarden niet juist zijn.
            // Indien alle ingevoerde waarden juist zijn
            // maak dan een nieuwe instantie aan van de klasse Auto. Sla deze
            // instantie op in het Field met de naam 'auto'.


            if (!IsInputCorrect(txtMerk, false) || !IsInputCorrect(txtModel, false) || !IsInputCorrect(txtBouwjaar, true))
            { 
                return; 
            }

                int bj = Convert.ToInt16(txtBouwjaar.Text);

                auto = new Auto(txtMerk.Text, txtModel.Text, bj);
            
            // Stap 1
            // De label met de naam 'lbAutobeschrijving' krijgt als 
            // tekst de beschrijving van de zojuist aangemaakte auto.
            // Roep hiertoe de methode GeefBeschrijving aan op de instantie
            // van de auto.

            // plaats je code hier.
                lbAutobeschrijving.Text = auto.GeefBeschrijving();

            gbNieuweAuto.Enabled = false;
            gbToevoegingen.Enabled = true;

            txtMerk.Clear();
            txtModel.Clear();
            txtBouwjaar.Clear();
        }

        /// <summary>
        /// Controleert of de auto Cool is. Oftewel, na 5 toevoegingen wordt de auto gepresenteerd
        /// </summary>
        private void CheckAutoIsCool()
        {
            if (auto.IsCool())
            {
                PresenteerAuto(auto);
            }
        }

        /// <summary>
        /// Verwerkt de info van gebruiker mbt spoiler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstalleerSpoiler_Click(object sender, EventArgs e)
        {
            // Stap 3
            // Valideer de ingevoerde waarde voor de omschrijving van de spoiler, geef een
            // foutmelding indien de waarde leeg is.
            if (!IsInputCorrect(txtSpoilerOmschrijving, false) )
            {
                return;
            }
            
            // Roep vervolgens de methode VoegSpoilerToe aan op de garage. Geef een melding om
            // aan te duiden dat de spoiler toegevoegd is en wis het omschrijvingsveld.
            garage.VoegEenSpoilerToe(auto, txtSpoilerOmschrijving.Text);
            txtSpoilerOmschrijving.Clear();

            // Indien de auto na het toevoegen van deze spoiler cool is, de methode IsCool 
            // retourneerde 'true', roep dan de methode PresenteerAuto aan.

            // plaats je code hier.
            //CheckAutoIsCool();
        }

        /// <summary>
        /// Verwerkt de info van gebruiker mbt speakers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstalleerSpeakers_Click(object sender, EventArgs e)
        {
            // Stap 3
            // Valideer de ingevoerde waarde voor de omschrijving van de speakers, geef een
            // foutmelding indien de waarde leeg is.
            if (!IsInputCorrect(txtSpeakersOmschrijving, false))
            {
                return;
            }
            
            // Roep vervolgens de methode VoegSpeakersToe aan op de garage. Geef een melding om
            // aan te duiden dat de speakers toegevoegd zijn en wis het omschrijvingsveld.
            garage.VoegSpeakersToe(auto, txtSpeakersOmschrijving.Text);
            txtSpeakersOmschrijving.Clear();

            // Indien de auto na het toevoegen van deze speakers cool is, de methode IsCool 
            // retourneerde 'true', roep dan de methode PresenteerAuto aan.

            // plaats je code hier.
            //CheckAutoIsCool();
        }

        /// <summary>
        /// Verwerkt de info van gebruiker mbt LCD scherm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstalleerLCDScherm_Click(object sender, EventArgs e)
        {
            // Stap 3
            // Valideer de ingevoerde waarde voor de omschrijving van de LCD-scherm, geef een
            // foutmelding indien de waarde leeg is.
            if (!IsInputCorrect(txtLCDSchermOmschrijving, false))
            {
                return;
            }
            
            // Roep vervolgens de methode VoegLCDSchermToe aan op de garage. Geef een melding om
            // aan te duiden dat het LCD-scherm toegevoegd is en wis het omschrijvingsveld.
            garage.VoegLCDSchermToe(auto, txtLCDSchermOmschrijving.Text);
            txtLCDSchermOmschrijving.Clear();
            
            // Indien de auto na het toevoegen van dit LCD-scherm cool is, de methode IsCool 
            // retourneerde 'true', roep dan de methode PresenteerAuto aan.

            // plaats je code hier.
            //CheckAutoIsCool();
        }

        /// <summary>
        /// Verwerkt de info van gebruiker mbt velgen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstalleerVelgen_Click(object sender, EventArgs e)
        {
            if (!IsInputCorrect(txtVelgenOmschrijving, false))
            {
                return;
            }

            garage.VoegVelgenToe(auto, txtVelgenOmschrijving.Text);
            txtVelgenOmschrijving.Clear();

            //CheckAutoIsCool();
        }

        /// <summary>
        /// Verwerkt de info van gebruiker mbt overspuiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOverspuiten_Click(object sender, EventArgs e)
        {
            if (!IsInputCorrect(txtOverspuitenOmschrijving, false))
            {
                return;
            }

            garage.VoegOverspuitenToe(auto, txtOverspuitenOmschrijving.Text);
            txtOverspuitenOmschrijving.Clear();

           // CheckAutoIsCool();
        }

        /// <summary>
        /// Geeft de info over de auto weer
        /// </summary>
        /// <param name="auto"></param>
        private void PresenteerAuto(Auto auto)
        {
            string bericht = auto.GeefBeschrijving();
            bericht += " met de volgende toevoegingen:" + Environment.NewLine;
            bericht += auto.GeefToevoegingen();
            MessageBox.Show(bericht, "De bolide is klaar!");

            gbToevoegingen.Enabled = false;
            gbNieuweAuto.Enabled = true;
        }

        /// <summary>
        /// Geeft de info over de auto weer na een muisklik
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPresenteren_Click(object sender, EventArgs e)
        {
            PresenteerAuto(auto);
        }
    }
}
