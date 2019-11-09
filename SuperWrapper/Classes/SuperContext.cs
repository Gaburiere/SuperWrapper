using System;
using PropertyChanged;
using SuperWrapper.CustomRenderers;

namespace SuperWrapper.Classes
{
    [AddINotifyPropertyChangedInterface]
    public class SuperContext
    {
        private const string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.97 Safari/537.36";
        
        public SuperContext(string source, string imageSource, Guid identifier)
        {
            this.SuperWebView = new SuperWebView() {Source = source, UserAgent = UserAgent};
            this.ImageSource = imageSource;
            this.ContextIdentifier = identifier;
        }

        public Guid ContextIdentifier { get; set; }

        public SuperWebView SuperWebView { get; set; }
        public bool ContextSelected { get; set; }
        public string ImageSource { get; set;}
    }
}