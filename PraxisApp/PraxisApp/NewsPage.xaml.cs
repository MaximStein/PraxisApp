using System;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using Xamarin.Forms;

namespace PraxisApp
{
    public partial class NewsPage : ContentPage
    {
        private bool pageLoaded = false;

        public NewsPage()
        {
            InitializeComponent();

			news_webview.Navigating += (s, e) =>
			{
                if(pageLoaded || Device.RuntimePlatform == Device.Android) {
					try
					{
						var uri = new Uri(e.Url);
						Device.OpenUri(uri);
					}
					catch (Exception)
					{
					}

					e.Cancel = true;
                } else {
                    pageLoaded = true;
                    e.Cancel = false;
                }
                
				
			};

            LoadNewsPage();


        }


        protected async void LoadNewsPage()
        {
            var htmlSource = new HtmlWebViewSource();
            try
            {
				var url = @"http://www.kinderarzt-elbvororte.de/";
                var webPage = await new HttpClient().GetStringAsync(new Uri(url));

                HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(webPage);
                var newsElement = htmldoc.GetElementbyId("news");

              
                var stylesheetUrl = "http://www.kinderarzt-elbvororte.de/wp-content/themes/twentyeleven-child/style.css";
                htmlSource.Html = @"<html><head><link rel=stylesheet type='text/css' href='"+stylesheetUrl+"'></head><body style='overflow-wrap:break-word; padding:10px;'>" + newsElement.InnerHtml + "</body></html>"; ;
             
            }
            catch (Exception ex)
            {


                htmlSource.Html = "News konnten nicht geladen werden.";             
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

			news_webview.Source = htmlSource; ;
        
        }
    }
}
