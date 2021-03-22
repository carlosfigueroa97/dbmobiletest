using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using dbmobiletest.Helpers;
using dbmobiletest.Models.DB;
using dbmobiletest.ViewModels.Base;
using dbmobiletest.Views;
using Xamarin.Forms;

namespace dbmobiletest.ViewModels
{
    public class RegisterUserVM : BaseViewModel
    {

        #region Properties & Commands

        public ObservableCollection<User> UserList { get; set; }

        public Command SaveUserCommand { get; set; }
        public Command GetUsersCommand { get; set; }

        int _typeDB;
        public int TypeDB
        {
            get
            {
                return _typeDB;
            }

            set
            {
                SetValue(ref _typeDB, value);
            }
        }

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

        #endregion

        public RegisterUserVM(INavigation navigation) : base(navigation)
        {
            SaveUserCommand = new Command(async () => await ExecuteSaveUserCommand());
            GetUsersCommand = new Command(() => ExecuteGetUsersCommand());
        }

        #region Methods

        async Task ExecuteSaveUserCommand()
        {
            try
            {

                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(LastName))
                    return;

                var user = new User()
                {
                    Id = new Random().Next(),
                    Name = Name,
                    LastName = LastName,
                    Status = 0
                };

                switch (TypeDB)
                {
                    case 0:
                        var response = liteDBService.RegisterUser(user);

                        if (!response)
                            return;
                        break;
                    default:
                        break;
                }

                GetUser();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteSaveUserCommand), ex);
            }
            finally
            {
                Name = null;
                LastName = null;
            }
        }

        private Task ExecuteGetUsersCommand()
        {
            try
            {
                GetUser();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteGetUsersCommand), ex);
            }

            return null;
        }

        private void GetUser()
        {
            var users = liteDBService.GetUsers();

            if (users != null || users.Any())
            {
                UserList = new ObservableCollection<User>(users);
                OnPropertyChanged(nameof(UserList));
            }
            else
            {
                UserList = new ObservableCollection<User>(users);
            }
        }

        #endregion
    }
}
