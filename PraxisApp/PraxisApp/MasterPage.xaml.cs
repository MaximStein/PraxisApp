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
	public partial class MasterPage : ContentPage
	{


        public MasterPage ()
		{
			InitializeComponent ();

            var homePage = new HomePage();
            var terminPage = new Terminformular();
            var kontaktPage = new Kontakt();
            var hilfePage = new Hilfe();
            var leistungenPage = new Leistungen();
            var rezeptePage = new Rezepte();
            var newsPage = new NewsPage();

            this.FindByName<Button>("navigation_home").Command = new Command(s => App.SetDetailPage(homePage));
            this.FindByName<Button>("navigation_terminformular").Command = new Command(s => App.SetDetailPage(terminPage));            
            this.FindByName<Button>("navigation_kontakt").Command = new Command(s => App.SetDetailPage(kontaktPage));
            this.FindByName<Button>("navigation_hilfe").Command = new Command(s => App.SetDetailPage(hilfePage));
            this.FindByName<Button>("navigation_leistungen").Command = new Command(s => App.SetDetailPage(leistungenPage));
            this.FindByName<Button>("navigation_rezepte").Command = new Command(s => App.SetDetailPage(rezeptePage));
            this.FindByName<Button>("navigation_news").Command = new Command(s => App.SetDetailPage(new NewsPage()));
        }
	}
}