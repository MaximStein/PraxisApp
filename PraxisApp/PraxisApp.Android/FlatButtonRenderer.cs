using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using PraxisApp.Droid;
using Xamarin.Forms;
using static PraxisApp.MyButton;

[assembly: ExportRenderer(typeof(PraxisApp.MyButton), typeof(FlatButtonRenderer))]
namespace PraxisApp.Droid
{
    class FlatButtonRenderer : ButtonRenderer
    {
        public FlatButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                var El = (MyButton)Element;
                if (El.TextAlignment == null) ;
                else if (El.TextAlignment == MyButtonTextAlignment.Left)
                    Control.Gravity = GravityFlags.Left | GravityFlags.CenterVertical;
                else if (El.TextAlignment == MyButtonTextAlignment.Right)
                    Control.Gravity = GravityFlags.Right;
                
            }
            

        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
        }
    }
}