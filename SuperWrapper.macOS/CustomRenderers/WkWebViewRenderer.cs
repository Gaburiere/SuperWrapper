using System;
using System.IO;
using AppKit;
using Foundation;
using SuperWrapper.CustomRenderers;
using SuperWrapper.macOS.CustomRenderers;
using SuperWrapper.Services;
using SuperWrapper.Services.Impl;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer (typeof(SuperWebView), typeof(SuperWebViewRenderer))]
namespace SuperWrapper.macOS.CustomRenderers
{
	public class SuperWebViewRenderer : ViewRenderer<SuperWebView, WKWebView>, IWKScriptMessageHandler
	{
		private WKWebView _wkWebView;
		protected override void OnElementChanged(ElementChangedEventArgs<SuperWebView> e)
		{
			base.OnElementChanged(e);

			if (this.Control == null)
			{
//				var tryGet = NSBundle.MainBundle.ResourceUrl.TryGetResource(new NSString(Script), out var urlValue);
//				if(!tryGet || urlValue == null)
//					throw new Exception($"i'm not able to find resource: {Script}");

				string script;
				var path = NSBundle.MainBundle.BundlePath + "/Contents/Resources/UserScript.js";
				using (var reader = new StreamReader(path))
				{
					script = reader.ReadToEnd();
				}
				
				var userScriptCode = new NSString(script);
				var userScript = new WKUserScript(userScriptCode, WKUserScriptInjectionTime.AtDocumentStart, false);
				var configuration = new WKWebViewConfiguration();
				configuration.UserContentController.AddUserScript(userScript);
				configuration.UserContentController.AddScriptMessageHandler(this, "notify");

//            let userScriptURL = Bundle.main.url(forResource: "UserScript", withExtension: "js")!
//            let userScriptCode = try! String(contentsOf: userScriptURL)
//            let userScript = WKUserScript(source: userScriptCode, injectionTime: .atDocumentStart, forMainFrameOnly: false)
//            let configuration = WKWebViewConfiguration()
//            configuration.userContentController.addUserScript(userScript)
//            configuration.userContentController.add(self, name: "notify")
//
//            let documentURL = Bundle.main.url(forResource: "Document", withExtension: "html")!
//            let webView = WKWebView(frame: view.frame, configuration: configuration)
//            webView.loadFileURL(documentURL, allowingReadAccessTo: documentURL)
				
				this._wkWebView = new WKWebView(this.Frame, configuration);
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

		public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
		{
//			var content = new UNMutableNotificationContent();
//			content.Title = "Super Wrapper Notifica!";
//			content.Body = message.Body.ToString();
//
//			var request = UNNotificationRequest.FromIdentifier(Guid.NewGuid().ToString(), content, null);
//			UNUserNotificationCenter.Current.AddNotificationRequest(request, error =>
//			{
//				if (error != null)
//				{
//					Debug.WriteLine(error.Code);
//					Debug.WriteLine(error.LocalizedFailureReason);
//				}
//			});

			
			var source = message.FrameInfo.Request.ToString();
			var configuration = DependencyService.Get<IConfigurationService>().GetConfigurationBySource(source);
			
			SentLocalNotification(message, configuration);
		}

		private void SentLocalNotification(WKScriptMessage message,
			(AvailableContexts Context, Guid Identifier, string Source) configuration)
		{
			var notification = new NSUserNotification
			{
				Title = "Super Wrapper Notifica!",
				InformativeText = message.Body.ToString(),
				SoundName = NSUserNotification.NSUserNotificationDefaultSoundName,
				HasActionButton = true
			};

			switch (configuration.Context)
			{
				case AvailableContexts.Whatsapp:
					notification.Title = configuration.Context.ToString();
					notification.ContentImage = NSImage.ImageNamed("whatsapp.png");
					break;
				case AvailableContexts.Telegram:
					notification.Title = configuration.Context.ToString();
					notification.ContentImage = NSImage.ImageNamed("telegram.png");
					break;
				case AvailableContexts.Spotify:
					notification.Title = configuration.Context.ToString();
					notification.ContentImage = NSImage.ImageNamed("spotify.png");
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			NSUserNotificationCenter.DefaultUserNotificationCenter.DeliverNotification(notification);
		}
	}
}