using SuperWrapper.Services;
using SuperWrapper.Services.Impl;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace SuperWrapper
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            this.ConfigureServices();
            this.BuildIdentifiers();

            MainPage = new MainPage();
        }

        private void BuildIdentifiers()
        {
            DependencyService.Get<ISettingsService>().BuildIdentifiers();
        }


        private void ConfigureServices()
        {
            DependencyService.Register<IOneTimeService, OneTimeService>();
            DependencyService.Register<ISettingsService, SettingsService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}