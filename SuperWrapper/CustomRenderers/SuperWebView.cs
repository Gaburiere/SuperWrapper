using Xamarin.Forms;

namespace SuperWrapper.CustomRenderers
{
    public class SuperWebView : WebView
    {
        public static readonly BindableProperty UserAgentProperty = BindableProperty.Create(
            propertyName: "UserAgent",
            returnType: typeof(string),
            declaringType: typeof(SuperWebView),
            defaultValue: default(string));

        public string UserAgent
        {
            get { return (string) GetValue(UserAgentProperty); }
            set { SetValue(UserAgentProperty, value); }
        }
    }
}