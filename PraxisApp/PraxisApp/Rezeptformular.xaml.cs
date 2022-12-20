using Plugin.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraxisApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rezeptformular : ContentPage {
        public Rezeptformular() {
            InitializeComponent();

            var tapGestureRecognizer_agb = new TapGestureRecognizer();
            var tapGestureRecognizer_datenschutz = new TapGestureRecognizer();

            var agbText = "Sollten Sie den vereinbarten Termin nicht einhalten können, bitten wir bis 24 Stunden vorher um Absage der Termins per Telefon oder Mail an :\r\n\r\n (info@kinderarzt-elbvororte.de).\r\n\r\nDa viele Patienten auf Termine warten und diese lange Wartezeiten in Kauf nehmen müssen, und die kardiologische - und Vorsorge - Untersuchung eine zeitlich und personell aufwendige Untersuchung ist, sind wir gezwungen für nicht wahrgenommene Termine(ohne Absage innerhalb der oben genannten Frist) 90 Euro in Rechnung zu stellen.";
            var data_privacy_statement_Text = "Passt auf eure Daten auf!";

            tapGestureRecognizer_agb.Tapped += (s, e) =>
            {
                DisplayAlert("AGB", agbText, "Ok");
            };
            this.agb_label.GestureRecognizers.Add(tapGestureRecognizer_agb);


            tapGestureRecognizer_datenschutz.Tapped += (s, e) =>
            {
                DisplayAlert("Datenschutzbestimmungen", data_privacy_statement_Text, "Ok");
            };
            this.data_privacy_statement_label.GestureRecognizers.Add(tapGestureRecognizer_datenschutz);


            LoadFormData();
        }

        void RezeptFormAbschicken(object sender, EventArgs args) {
            SaveFormData();
            List<string> errorList = new List<string>();

            /*if (!string.IsNullOrWhiteSpace(emailField.Text) && Regex.Match(emailField.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                emailErrorLabel.IsVisible = false;
            else
                emailErrorLabel.IsVisible = true;*/

            if(!agb_switch.IsToggled)
                DisplayAlert("Fehler", "Bitte die AGBs akzeptieren", "OK");
            else if(!data_privacy_statement_switch.IsToggled) {
                DisplayAlert("Fehler", "Bitte die Datenschutzvereinbarung akzeptieren", "OK");
            }
            else if(string.IsNullOrWhiteSpace(patient_nachname.Text)
                || string.IsNullOrWhiteSpace(patient_vorname.Text)
                || string.IsNullOrWhiteSpace(patient_krankenkasse.Text)
                || string.IsNullOrWhiteSpace(eltern_nachname.Text)
                || string.IsNullOrWhiteSpace(eltern_tel.Text))
                DisplayAlert("Fehler", "Bitte alle erforderlichen Felder ausfüllen", "OK");
            else {
                var emailMessenger = CrossMessaging.Current.EmailMessenger;
                if(emailMessenger.CanSendEmail) {

                    string mailBody = "---- Patient ----" + "\r\n" +
                        "Name: " + patient_nachname.Text + ", " + patient_vorname.Text + "\r\n" +
                        "Krankenkasse: " + patient_krankenkasse.Text + "\r\n" +
                        "Geburtsdatum: " + patient_dob.Date.Day + "." + patient_dob.Date.Month + "." + patient_dob.Date.Year + "\r\n" +
                        "\r\n" +
                        "---- Eltern ----" + "\r\n" +
                        "Name: " + eltern_nachname.Text + ", " + eltern_vorname.Text + "\r\n" +
                        "Telefon: " + eltern_tel.Text + "\r\n" +
                        "E-Mail: " + eltern_email.Text + "\r\n" +
                        "\r\n" +
                        "Weitere Angaben: " + weitere_angaben.Text
                        ;

                    // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                    emailMessenger.SendEmail("info@kinderarzt-elbvororte.de",
                        "Rezept-/Überweisungsformular: Anfrage von " + eltern_vorname.Text + " " + eltern_nachname.Text + " (" + eltern_tel.Text + ")",
                        mailBody);

                }
            }

        }


        void LoadFormData() {
            Object savedValue = "";
            var Props = App.Current.Properties;
            if(!Props.ContainsKey("patient_dob")) {
                patient_dob.Date = DateTime.Parse("01.01.2000");
            }
            foreach(FieldInfo f in this.GetType().GetRuntimeFields()) {

                if(Props.ContainsKey(f.Name)) {
                    object o = f.GetValue(this);
                    if(o is EntryCell)
                        (o as EntryCell).Text = (string)Props[f.Name];
                    else if(o is DatePicker)
                        (o as DatePicker).Date = (DateTime)Props[f.Name];
                }
            }
        }

        void SaveFormData() {
            var Props = App.Current.Properties;
            Props["patient_nachname"] = patient_nachname.Text;
            Props["patient_vorname"] = patient_vorname.Text;
            Props["patient_krankenkasse"] = patient_krankenkasse.Text;
            Props["patient_dob"] = patient_dob.Date;
            Props["eltern_nachname"] = eltern_nachname.Text;
            Props["eltern_vorname"] = eltern_vorname.Text;
            Props["eltern_tel"] = eltern_tel.Text;
            Props["eltern_email"] = eltern_email.Text;
        }
    }
}
