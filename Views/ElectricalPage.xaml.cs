using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace MechTools.Views
{
    public partial class ElectricalPage : ContentPage
    {
        private bool _isLoaded = false;

        public ElectricalPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!_isLoaded)
            {
                _isLoaded = true;
                await LoadPosterAsync();
            }
        }

        private async Task LoadPosterAsync()
        {
            try
            {
                using var stream = await FileSystem.Current.OpenAppPackageFileAsync("poster_elettrica.png");
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);

                string base64Image = Convert.ToBase64String(memoryStream.ToArray());

                // FIX TECNICO: Rimosso "width=device-width" dal meta tag
                // FIX TECNICO: Rimosso "width: 100%" dal CSS dell'immagine
                string html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta name='viewport' content='minimum-scale=0.01, maximum-scale=30.0, user-scalable=yes'>
                    <style>
                        body {{
                            background-color: #121212;
                            margin: 0;
                            padding: 0;
                            text-align: center;
                        }}
                        img {{
                            display: block;
                            margin: 0 auto;
                        }}
                    </style>
                </head>
                <body>
                    <img src='data:image/png;base64,{base64Image}' />
                </body>
                </html>";

                PosterWebView.Source = new HtmlWebViewSource { Html = html };

                StatusLabel.Text = "Pronto! Usa 2 dita per zoomare o fai doppio tap.";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Errore: {ex.Message}";
                StatusLabel.TextColor = Colors.Red;
            }
        }

        private void OnWebViewHandlerChanged(object sender, EventArgs e)
        {
#if ANDROID
            var webView = PosterWebView.Handler?.PlatformView as Android.Webkit.WebView;
            if (webView != null)
            {
                webView.Settings.SetSupportZoom(true);
                webView.Settings.BuiltInZoomControls = true;
                webView.Settings.DisplayZoomControls = false;

                // 2. IL FIX DEFINITIVO:
                // Obblighiamo Android a comportarsi come un vero browser web
                // e ad ascoltare il meta-tag "viewport" dell'HTML.
                webView.Settings.UseWideViewPort = true;
                webView.Settings.LoadWithOverviewMode = true;
            }
#endif
        }
    }
}