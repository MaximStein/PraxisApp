using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraxisApp
{
    public class JustifiedLabel : Label
    {
        public object Renderer = null;

        public EventHandler ContentLoaded;
    }
}
