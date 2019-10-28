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
            this.MainWebView.Source = "https://mail.google.com/";
        }
    }
}