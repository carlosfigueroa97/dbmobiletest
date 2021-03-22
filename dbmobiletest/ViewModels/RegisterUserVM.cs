using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using dbmobiletest.Helpers;
using dbmobiletest.Models.DB;
using dbmobiletest.ViewModels.Base;
using Xamarin.Forms;

namespace dbmobiletest.ViewModels
{
    public class RegisterUserVM : BaseViewModel
    {

        #region Properties & Commands

        public ObservableCollection<User> UserList { get; set; }

        public Command SaveUserCommand { get; set; }
        public Command GetUsersCommand { get; set; }
        public Command DeleteUserCommand { get; set; }

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

        User _selectedItem;
        public User SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                SetValue(ref _selectedItem, value);
            }
        }

        #endregion

        public RegisterUserVM(INavigation navigation) : base(navigation)
        {
            SaveUserCommand = new Command(() => ExecuteSaveUserCommand());
            GetUsersCommand = new Command(() => ExecuteGetUsersCommand());
            DeleteUserCommand = new Command(() => ExecuteDeleteUserCommand());
        }

        #region Methods

        private Task ExecuteSaveUserCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(LastName))
                    return null;

                var user = new User()
                {
                    Id = new Random().Next(),
                    Name = Name,
                    LastName = LastName,
                    FullName = $"{Name} {LastName}",
                    Status = 0
                };

                switch (TypeDB)
                {
                    case 0:
                        var response = liteDBService.RegisterUser(user);

                        if (!response)
                            return null;
                        break;
                    default:
                        break;
                }

                Name = null;
                LastName = null;

                GetUser();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteSaveUserCommand), ex);
            }

            return null;
        }

        private void ExecuteGetUsersCommand()
        {
            try
            {
                GetUser();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteGetUsersCommand), ex);
            }
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
                UserList = new ObservableCollection<User>();
            }
        }

        private void ExecuteDeleteUserCommand()
        {
            try
            {
                if(SelectedItem != null)
                {
                    var response = liteDBService.DeleteUser(SelectedItem);
                    if (response)
                        GetUser();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(ExecuteGetUsersCommand), ex);
            }
            finally
            {
                SelectedItem = null;
            }
        }

        #endregion
    }
}