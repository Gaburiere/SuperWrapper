using System.Collections.Generic;
using SuperWrapper.Classes;
using Xamarin.Forms;

namespace SuperWrapper.Controls
{
    public partial class SuperGrid : Grid
    {
        public SuperGrid()
        {
            InitializeComponent();
        }        
        
        public static readonly BindableProperty ContextsProperty =
            BindableProperty.Create(nameof(Contexts), typeof(List<SuperContext>), typeof(SuperGrid), null,
                BindingMode.OneWay, null, OnContextsChanged);

        private static void OnContextsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SuperGrid)bindable;
            if (control != null)
            {
                if (newValue is List<SuperContext> superContexts)
                {
                    foreach (var superContext in superContexts)
                    {
                        var superWebView = superContext.SuperWebView;
                        superWebView.IsVisible = superContext.ContextSelected;
                        control.Children.Add(superWebView, 0, 0);
                    }
                }
            }
        }
        
        public List<SuperContext> Contexts
        {
            get => (List<SuperContext>)GetValue(ContextsProperty);
            set => SetValue(ContextsProperty, value);
        }
    }
}