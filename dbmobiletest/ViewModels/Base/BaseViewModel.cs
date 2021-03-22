using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using dbmobiletest.Services.LiteDB;
using Xamarin.Forms;

namespace dbmobiletest.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Variables

        public INavigation navigation { get; set; }
        public ILiteDBService liteDBService => DependencyService.Get<ILiteDBService>();

        #endregion

        public BaseViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        #region Methods

        protected bool SetValue<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
