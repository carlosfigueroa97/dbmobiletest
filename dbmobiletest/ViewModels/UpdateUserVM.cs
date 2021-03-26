using System;
using System.Threading.Tasks;
using dbmobiletest.Helpers;
using dbmobiletest.Models.DB;
using dbmobiletest.ViewModels.Base;
using Xamarin.Forms;

namespace dbmobiletest.ViewModels
{
    public class UpdateUserVM : BaseViewModel
    {

        #region Properties & Command

        public Command UpdateUserCommand { get; set; }

        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetValue(ref _name, value);
            }
        }

        string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                SetValue(ref _lastName, value);
            }
        }

        User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                SetValue(ref _user, value);
            }
        }

        #endregion

        public UpdateUserVM(INavigation navigation) : base(navigation)
        {
            UpdateUserCommand = new Command(async () => await ExecuteUpdateUserCommand());
        }

        #region Methods

        async Task ExecuteUpdateUserCommand()
        {
            try
            {
                User.Name = Name;
                User.LastName = LastName;
                User.FullName = $"{Name} {LastName}";
                var response = liteDBService.UpdateUser(User);

                if (!response)
                    return;

                await navigation.PopAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteUpdateUserCommand), ex);
            }
        }

        #endregion
    }
}
