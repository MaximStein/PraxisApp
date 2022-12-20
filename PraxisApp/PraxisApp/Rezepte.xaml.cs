using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PraxisApp {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rezepte : ContentPage {
        public Rezepte() {
            InitializeComponent();
        }
        private void RezeptButtonClicked(object sender, EventArgs e) {
            App.PushDetailPage(new Rezeptformular());
        }
    }
}