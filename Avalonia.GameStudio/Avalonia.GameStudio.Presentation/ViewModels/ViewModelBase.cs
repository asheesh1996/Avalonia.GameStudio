using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace Avalonia.GameStudio.Presentation.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public bool SetValue<TValue>(ref TValue backingField, TValue value, [CallerMemberName] string propertyName = null)
        {
            Contract.Requires<ArgumentNullException>(propertyName != null);

            if (EqualityComparer<TValue>.Default.Equals(backingField, value))
                return false;

            this.RaisePropertyChanging(propertyName);
            backingField = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }
    }
}
