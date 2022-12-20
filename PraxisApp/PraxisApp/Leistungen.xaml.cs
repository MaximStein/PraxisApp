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
	public partial class Leistungen : ContentPage
	{
        
		public Leistungen ()
		{
			InitializeComponent ();
            if (Device.RuntimePlatform == Device.Android)
            {
                leistungenLabel1.ContentLoaded = leistungenLabel2.ContentLoaded = leistungenLabel4.ContentLoaded = leistungenLabel5.ContentLoaded = (s, e) =>
                {                    
                    if (s == leistungenLabel1)
                    {
                        leistungenText1.IsVisible = false;
                   
                    }
                    else if (s == leistungenLabel2)
                    {
                        leistungenText2.IsVisible = false;
                
                    }
                    else if (s == leistungenLabel4)
                    {
                        leistungenText4.IsVisible = false;
                    }
                    else if (s == leistungenLabel5)
                    {
                        leistungenText5.IsVisible = false;
                       
                    }
                };

            } else
            {
                leistungenText1.IsVisible = leistungenText2.IsVisible = leistungenText4.IsVisible = leistungenText5.IsVisible = false;                
            }

            leistungenText3.IsVisible = false;
            leistungenText6.IsVisible = false;
        }

        public void SectionButtonClicked(object sender, EventArgs e) {
            Button button = sender as Button;


            leistungenText1.IsVisible = leistungenButton1 == button ? !leistungenText1.IsVisible : leistungenText1.IsVisible;
            leistungenText2.IsVisible = leistungenButton2 == button ? !leistungenText2.IsVisible : leistungenText2.IsVisible;
            leistungenText3.IsVisible = leistungenButton3 == button ? !leistungenText3.IsVisible  : leistungenText3.IsVisible;
            leistungenText4.IsVisible = leistungenButton4 == button ? !leistungenText4.IsVisible : leistungenText4.IsVisible;
            leistungenText5.IsVisible = leistungenButton5 == button ? !leistungenText5.IsVisible : leistungenText5.IsVisible;
            leistungenText6.IsVisible = leistungenButton6 == button ? !leistungenText6.IsVisible : leistungenText6.IsVisible;

        }

        private void TerminButtonClicked(object sender, EventArgs e)
        {
            App.PushDetailPage(new Terminformular());
        }

    }
}