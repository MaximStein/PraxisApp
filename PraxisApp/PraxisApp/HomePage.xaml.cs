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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            foreach (View v in Terminkalender.Children)
            {
                if (v is Label)
                    v.Margin = new Thickness(5, 5, 5, 5);
            }
        }

        private void KontaktButtonClicked(object sender, EventArgs e)
        {
            App.PushDetailPage(new Kontakt());
        }

        private void AnfahrtButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.google.com/maps?ll=53.572528,9.846277&z=13&t=m&hl=de&gl=US&mapclient=embed&cid=13687894572026804464"));
        }

        private void HvvButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.hvv.de/fp.php?id=9b13c3f22cf49979c5b7d65b4e3fc0c9"));
        }
        
    }
}