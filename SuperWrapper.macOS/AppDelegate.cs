using AppKit;
using FFImageLoading.Forms.Platform;
using Foundation;

namespace SuperWrapper.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.MacOS.FormsApplicationDelegate
    {
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CoreGraphics.CGRect(200, 200, 800, 600);
            this.MainWindow = new NSWindow(rect, style, NSBackingStore.Buffered, false) {Title = "Super Wrapper"};
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
//            var notificationCenter = UNUserNotificationCenter.Current;
//            notificationCenter.RequestAuthorization(UNAuthorizationOptions.Alert|UNAuthorizationOptions.Badge|UNAuthorizationOptions.Sound, (b, error) =>
//            {
//                Debug.WriteLine(b
//                    ? "Notification permission granted"
//                    : $"Notification permission denied because of: {error.LocalizedDescription}");
//            });
            CachedImageRenderer.Init();
            Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }
        
        public override NSWindow MainWindow { get; }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
