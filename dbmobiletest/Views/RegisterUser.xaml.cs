using System.Linq;
using dbmobiletest.ViewModels;
using Xamarin.Forms;

namespace dbmobiletest.Views
{
    public partial class RegisterUser : ContentPage
    {
        RegisterUserVM _vm;

        public RegisterUser(int typeDB)
        {
            InitializeComponent();
            _vm = new RegisterUserVM(Navigation);
            BindingContext = _vm;
            _vm.TypeDB = typeDB;
        }

        protected override void OnAppearing()
        {
            if (_vm.UserList == null || !_vm.UserList.Any())
                _vm.GetUsersCommand.Execute(null);
            base.OnAppearing();
        }
    }
}
