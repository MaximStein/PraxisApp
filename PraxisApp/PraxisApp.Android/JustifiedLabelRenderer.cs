using Android.Content;
using PraxisApp;
using PraxisApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(JustifiedLabel), typeof(JustifiedLabelRenderer))]
namespace PraxisApp.Droid
{
    //We don't extend from LabelRenderer on purpose as we want to set 
    // our own native control (which is not TextView)
    public class JustifiedLabelRenderer : ViewRenderer
    {


        public JustifiedLabelRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            //if we have a new forms element, we want to update text with font style (as specified in forms-pcl) on native control

            //label = e.NewElement as Label;


            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    (e.NewElement as JustifiedLabel).Renderer = this;
                    //register webview as native control
                    var webView = new Android.Webkit.WebView(Context);
                    var c = new ExtendedWebViewClient(e.NewElement as JustifiedLabel);
                    webView.SetWebViewClient(c);
                    webView.VerticalScrollBarEnabled = false;
                    webView.HorizontalScrollBarEnabled = false;

                    webView.LoadData("<html><body>&nbsp;</body></html>", "text/html; charset=utf-8", "utf-8");
                    SetNativeControl(webView);
                }

                //if we have a new forms element, we want to update text with font style (as specified in forms-pcl) on native control
                UpdateTextOnControl();
            }
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if there is change in text or font-style, trigger update to redraw control
            if (e.PropertyName == nameof(Label.Text)
               || e.PropertyName == nameof(Label.FontFamily)
               || e.PropertyName == nameof(Label.FontSize)
               || e.PropertyName == nameof(Label.TextColor)
               || e.PropertyName == nameof(Label.FontAttributes))
            {
                UpdateTextOnControl();

            }

        }

        class ExtendedWebViewClient : Android.Webkit.WebViewClient
        {

            JustifiedLabel label;

            public ExtendedWebViewClient(JustifiedLabel label) : base()
            {
                this.label = label;
            }

            public override async void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                if (label != null)
                {
                    int i = 10;
                    while (view.ContentHeight == 0 && i-- > 0) // wait here till content is rendered
                        await System.Threading.Tasks.Task.Delay(i * 30);
                    label.HeightRequest = view.ContentHeight;


                    if (label.ContentLoaded != null)
                    {
                        label.ContentLoaded(label, null);
                    }
                }
                base.OnPageFinished(view, url);
            }
        }

        public void UpdateTextOnControl()
        {
            var webView = Control as Android.Webkit.WebView;
            var formsLabel = Element as Label;

            // create css style from font-style as specified
            var cssStyle = $"white-space:pre-line; height:fit-content; display:inline-block; margin: 0px; padding: 0px; text-align: justify; color: {ToHexColor(formsLabel.TextColor)}; background-color: {ToHexColor(formsLabel.BackgroundColor)}; font-family: {formsLabel.FontFamily}; font-size: {formsLabel.FontSize}; font-weight: {formsLabel.FontAttributes}";

            // apply that to text 
            var strData =
                $"<html style=\"height:fit-content; display:inline-block; \"><body style=\"{cssStyle}\">{formsLabel?.Text}</body></html>";

            // and, refresh webview
            webView.LoadData(strData, "text/html; charset=utf-8", "utf-8");

            webView.Reload();

            webView.RefreshDrawableState();
        }

        // helper method to convert forms-color to css-color
        string ToHexColor(Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            var hex = $"#{red:X2}{green:X2}{blue:X2}";

            return hex;
        }
    }
}