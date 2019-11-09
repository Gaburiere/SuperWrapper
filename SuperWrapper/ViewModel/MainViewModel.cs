using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PropertyChanged;
using SuperWrapper.Classes;
using SuperWrapper.CustomRenderers;
using SuperWrapper.Services;
using SuperWrapper.Services.Impl;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SuperWrapper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ISettingsService _settingsService;
        public ObservableCollection<SuperContext> Contexts { get; set; }

        [DoNotNotify] public ICommand ClickCommand { get; set; }

        public SuperWebView ActiveSuperWebView
        {
            get { return this.Contexts.SingleOrDefault(context => context.ContextSelected)?.SuperWebView; }
        }

        public SuperWebView WhatsappSuperWebView
        {
            get
            {
                var webView = this.Contexts.Single(context =>
                        context.ContextIdentifier == this._settingsService.GetIdentifier(AvailableContexts.Whatsapp))
                    .SuperWebView;
                return webView;
            }
        }

        public SuperWebView TelegramSuperWebView
        {
            get
            {
                var webView = this.Contexts.Single(context =>
                        context.ContextIdentifier == this._settingsService.GetIdentifier(AvailableContexts.Telegram))
                    .SuperWebView;
                return webView;
            }
        }

        public SuperWebView SpotifySuperWebView
        {
            get
            {
                var webView = this.Contexts.Single(context =>
                        context.ContextIdentifier == this._settingsService.GetIdentifier(AvailableContexts.Spotify))
                    .SuperWebView;
                return webView;
            }
        }

        public bool WhatsappVisible
        {
            get
            {
                var visibile = this.Contexts.Single(content =>
                        content.ContextIdentifier == this._settingsService.GetIdentifier(AvailableContexts.Whatsapp))
                    .ContextSelected;
                return visibile;
            }
        }

        public bool TelegramVisible
        {
            get
            {
                var visibile = this.Contexts.Single(content =>
                        content.ContextIdentifier == this._settingsService.GetIdentifier(AvailableContexts.Telegram))
                    .ContextSelected;
                return visibile;
            }
        }

        public bool SpotifyVisible
        {
            get
            {
                var visibile = this.Contexts.Single(content =>
                        content.ContextIdentifier == this._settingsService.GetIdentifier(AvailableContexts.Spotify))
                    .ContextSelected;
                return visibile;
            }
        }

        public MainViewModel()
        {
            _settingsService = DependencyService.Get<ISettingsService>();
            this.BuildContexts();
            this.ClickCommand = new Command(this.InnerClick);
        }

        private void BuildContexts()
        {
            var whatsappIdentifier = this._settingsService.GetIdentifier(AvailableContexts.Whatsapp);
            var telegramIdentifier = this._settingsService.GetIdentifier(AvailableContexts.Telegram);
            var spotifyIdentifier = this._settingsService.GetIdentifier(AvailableContexts.Spotify);
            var whatsappContext =
                new SuperContext("https://web.whatsapp.com", "whatsapp.png", whatsappIdentifier)
                    {ContextSelected = true};
            var telegramContext = new SuperContext("https://web.telegram.org", "telegram.png", telegramIdentifier);
            var spotifyContext =
                new SuperContext("https://open.spotify.com", "spotify.png", spotifyIdentifier);

            this.Contexts = new ObservableCollection<SuperContext> {whatsappContext, telegramContext, spotifyContext};
        }

        private void InnerClick(object e)
        {
            var eventArgs = (ItemTappedEventArgs) e;
            var context = (SuperContext) eventArgs.Item;
            this.Contexts.ForEach(f => f.ContextSelected = false);
            this.Contexts.Single(s => s == context).ContextSelected = true;
            base.RaisePropertyChanged(() => this.WhatsappVisible);
            base.RaisePropertyChanged(() => this.TelegramVisible);
            base.RaisePropertyChanged(() => this.SpotifyVisible);
        }
    }
}