using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraxisApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hilfe : ContentPage
    {
        public Hilfe()
        {
            InitializeComponent();
        }

        private void PhoneCallButtonClicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall((sender as MyButton).Text);
        }
    }
}