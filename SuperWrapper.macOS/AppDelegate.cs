using System;
using System.Diagnostics;
using AppKit;
using Foundation;
using UserNotifications;

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
//            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (b, error) =>
//            {
//                Debug.WriteLine("ERROR IN REQUEST AUTHORIZATION");
//            });
            
            //UNUserNotificationCenter.current().requestAuthorization(options: [.alert]) { (granted, error) in
            // Enable or disable features based on authorization.

            
            
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
