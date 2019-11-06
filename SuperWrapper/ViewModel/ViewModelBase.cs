using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SuperWrapper.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        protected void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var propertyName = ((MemberExpression)property.Body).Member.Name;
            this.OnPropertyChanged(propertyName);
        }
    }
    

}