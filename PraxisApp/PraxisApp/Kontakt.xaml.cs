using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraxisApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kontakt : ContentPage {
        public Kontakt() {
            InitializeComponent();
        }

        private void AnrufClicked(object sender, EventArgs e) {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if(phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("040804110");
        }

        private void MailClicked(object sender, EventArgs e) {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;

            if(emailMessenger.CanSendEmail) {
                emailMessenger.SendEmail("info@kinderarzt-elbvororte.de", "", "");
            }
        }

        private void HomepageClicked(object sender, EventArgs e) {
            Device.OpenUri(new Uri("http://kinderarzt-elbvororte.de"));
        }
    }
}