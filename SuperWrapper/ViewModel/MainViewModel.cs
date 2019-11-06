using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PropertyChanged;
using SuperWrapper.Classes;
using SuperWrapper.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SuperWrapper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<SuperContext> Contexts { get; set; }
        
        [DoNotNotify] public ICommand ClickCommand { get; set; }


        public SuperWebView ActiveSuperWebView
        {
            get { return this.Contexts.SingleOrDefault(context => context.ContextSelected)?.SuperWebView; }
        }
        public MainViewModel()
        {
            var whatsappContext =
                new SuperContext("https://web.whatsapp.com/", "whatsapp.png") {ContextSelected = true};
            var telegramContext = new SuperContext("https://web.telegram.org", "telegram.png");
            
            this.Contexts = new ObservableCollection<SuperContext> {whatsappContext, telegramContext};
            
            this.ClickCommand = new Command<SuperContext>(context =>
            {
                this.Contexts.ForEach(f=> f.ContextSelected = false);
                this.Contexts.Single(s => s == context).ContextSelected = true;
                base.RaisePropertyChanged(() => this.ActiveSuperWebView);
            });
        }
    }
}