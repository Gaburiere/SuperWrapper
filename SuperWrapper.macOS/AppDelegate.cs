using AppKit;
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
            this.MainWindow = new NSWindow(rect, style, NSBackingStore.Buffered, false) {Title = "Mind of Ai"};
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
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
