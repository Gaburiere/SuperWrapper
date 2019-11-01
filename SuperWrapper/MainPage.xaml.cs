using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SuperWrapper
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GmailButton_OnClicked(object sender, EventArgs e)
        {
            var webViewSource = new UrlWebViewSource();
            webViewSource.Url = "https://mail.google.com/";
            this.MainWebView.Source = webViewSource;
        }

        private void WhatsAppButton_OnClicked(object sender, EventArgs e)
        {
            var webViewSource = new UrlWebViewSource();
            webViewSource.Url = "https://web.whatsapp.com/";
            this.MainWebView.Source = webViewSource;
        }
    }
}