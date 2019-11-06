using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SuperWrapper.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            string propertyName = ((MemberExpression)property.Body).Member.Name;
            this.OnPropertyChanged(propertyName);
        }
    }
    

}