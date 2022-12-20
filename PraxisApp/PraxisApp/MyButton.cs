using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraxisApp
{
    public class MyButton : Button
    {
        public enum MyButtonTextAlignment { Center, Left, Right};

        public MyButtonTextAlignment TextAlignment { get; set; }

    }
}
