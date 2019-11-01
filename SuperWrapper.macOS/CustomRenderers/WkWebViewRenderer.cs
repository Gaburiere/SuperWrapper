using Foundation;
using SuperWrapper.CustomRenderers;
using SuperWrapper.macOS.CustomRenderers;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer (typeof(SuperWebView), typeof(SuperWebViewRenderer))]
namespace SuperWrapper.macOS.CustomRenderers
{
	public class SuperWebViewRenderer : ViewRenderer<SuperWebView, WKWebView>
	{
		private WKWebView _wkWebView;
		protected override void OnElementChanged(ElementChangedEventArgs<SuperWebView> e)
		{
			base.OnElementChanged(e);

			if (this.Control == null)
			{
				var config = new WKWebViewConfiguration();
				this._wkWebView = new WKWebView(this.Frame, config);
				this.SetNativeControl(this._wkWebView);
			}
			if (e.NewElement != null)
			{
				var source = (UrlWebViewSource) e.NewElement.Source;
				if(source != null)
					this.Control.LoadRequest(new NSUrlRequest(new NSUrl(source.Url)));
				this.Control.CustomUserAgent = e.NewElement.UserAgent;
			}
		}
	}
}