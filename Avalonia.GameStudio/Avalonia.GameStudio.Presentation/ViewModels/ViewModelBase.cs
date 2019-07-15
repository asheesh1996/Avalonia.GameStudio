using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace Avalonia.GameStudio.Presentation.ViewModels
{
    /// <summary>
    /// Base view model class.
    /// </summary>
    public class ViewModelBase : ReactiveObject
    {
        /// <summary>
        /// Sets the <paramref name="backingField"/> of the property with the provided <paramref name="value"/>,
        /// and raises the property changing/changed events when the values has changed.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="backingField">A reference to the backing field for the property.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>true</c> if the value was changed; otherzise, <c>false</c>.</returns>
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
