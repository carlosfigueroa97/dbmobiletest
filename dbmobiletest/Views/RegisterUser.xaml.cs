using System;
using System.Linq;
using dbmobiletest.Models.DB;
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

            _vm.GetUsersCommand.Execute(null);
            base.OnAppearing();
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var selectedItem = (User)((Label)sender).BindingContext;
            _vm.SelectedItem = selectedItem;
            _vm.DeleteUserCommand.Execute(null);
        }

        void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var selectedItem = (User)((Label)sender).BindingContext;
            _vm.SelectedItem = selectedItem;
            _vm.GoToEditUserCommand.Execute(null);
        }
    }
}
