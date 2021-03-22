using System;
using System.Threading.Tasks;
using dbmobiletest.Helpers;
using dbmobiletest.ViewModels.Base;
using dbmobiletest.Views;
using Xamarin.Forms;

namespace dbmobiletest.ViewModels
{
    public class SelectDBVM : BaseViewModel
    {
        #region Variables & Commands

        public Command LiteDBCommand { get; set; }

        #endregion

        public SelectDBVM(INavigation navigation) : base(navigation)
        {
            LiteDBCommand = new Command(async () => await ExecuteLiteDBCommand());
        }

        #region Methods

        async Task ExecuteLiteDBCommand()
        {
            try
            {
                await navigation.PushAsync(new RegisterUser(0));
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteLiteDBCommand), ex);
            }
        }

        #endregion
    }
}
