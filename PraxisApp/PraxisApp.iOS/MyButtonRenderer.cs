using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using PraxisApp.iOS;
using PraxisApp;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(PraxisApp.MyButton), typeof(MyButtonRenderer))]
namespace PraxisApp.iOS
{
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null)
            {
                var El = (MyButton)Element;                

                switch(El.TextAlignment)
                {
                    case MyButton.MyButtonTextAlignment.Center:
                        Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                    break;

                    case MyButton.MyButtonTextAlignment.Left:
                        Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                    break;

                    case MyButton.MyButtonTextAlignment.Right:
                        Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
                    break;
                }
                
            }
        }
    }
}