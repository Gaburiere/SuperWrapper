using System;
using System.Windows.Input;
using PropertyChanged;
using SuperWrapper.CustomRenderers;
using Xamarin.Forms;

namespace SuperWrapper.Classes
{
    [AddINotifyPropertyChangedInterface]
    public class SuperContext
    {
        private const string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.70 Safari/537.36";

        public SuperContext(string source, string imageSource)
        {
            this.SuperWebView = new SuperWebView {Source = source, UserAgent = UserAgent};
            this.ImageSource = imageSource;
        }

        public SuperWebView SuperWebView { get; set; }
        public bool ContextSelected { get; set; }
        public string ImageSource { get; set;}
    }
}