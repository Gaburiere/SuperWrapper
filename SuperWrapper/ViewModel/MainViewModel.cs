using System;
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
        private readonly IConfigurationService _configurationService;
        private readonly (AvailableContexts Context, Guid Identifier, string Source) _whatsappConfiguration;
        private readonly (AvailableContexts Context, Guid Identifier, string Source) _telegramConfiguration;
        private readonly (AvailableContexts Context, Guid Identifier, string Source) _spotifyConfiguration;
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
                        context.ContextIdentifier == this._whatsappConfiguration.Identifier)
                    .SuperWebView;
                return webView;
            }
        }

        public SuperWebView TelegramSuperWebView
        {
            get
            {
                var webView = this.Contexts.Single(context =>
                        context.ContextIdentifier == this._telegramConfiguration.Identifier)
                    .SuperWebView;
                return webView;
            }
        }

        public SuperWebView SpotifySuperWebView
        {
            get
            {
                var webView = this.Contexts.Single(context =>
                        context.ContextIdentifier == this._spotifyConfiguration.Identifier)
                    .SuperWebView;
                return webView;
            }
        }

        public bool WhatsappVisible
        {
            get
            {
                var visibile = this.Contexts.Single(content =>
                        content.ContextIdentifier == this._whatsappConfiguration.Identifier)
                    .ContextSelected;
                return visibile;
            }
        }

        public bool TelegramVisible
        {
            get
            {
                var visibile = this.Contexts.Single(content =>
                        content.ContextIdentifier == this._telegramConfiguration.Identifier)
                    .ContextSelected;
                return visibile;
            }
        }

        public bool SpotifyVisible
        {
            get
            {
                var visibile = this.Contexts.Single(content =>
                        content.ContextIdentifier == this._spotifyConfiguration.Identifier)
                    .ContextSelected;
                return visibile;
            }
        }

        public MainViewModel()
        {
            this._configurationService = DependencyService.Get<IConfigurationService>();
            this._whatsappConfiguration = this._configurationService.GetConfiguration(AvailableContexts.Whatsapp);
            this._telegramConfiguration = this._configurationService.GetConfiguration(AvailableContexts.Telegram);
            this._spotifyConfiguration = this._configurationService.GetConfiguration(AvailableContexts.Spotify);
            
            this.BuildContexts();
            
            this.ClickCommand = new Command(this.InnerClick);
        }

        private void BuildContexts()
        {
            var whatsappContext =
                new SuperContext(this._whatsappConfiguration.Source, "whatsapp.png", this._whatsappConfiguration.Identifier) {ContextSelected = true};
            var telegramContext = 
                new SuperContext(this._telegramConfiguration.Source, "telegram.png", this._telegramConfiguration.Identifier);
            var spotifyContext =
                new SuperContext(this._spotifyConfiguration.Source, "spotify.png", this._spotifyConfiguration.Identifier);

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