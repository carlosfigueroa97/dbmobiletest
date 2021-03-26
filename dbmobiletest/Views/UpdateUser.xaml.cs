using dbmobiletest.Models.DB;
using dbmobiletest.ViewModels;
using Xamarin.Forms;

namespace dbmobiletest.Views
{
    public partial class UpdateUser : ContentPage
    {
        private UpdateUserVM _vm;

        public UpdateUser(User selectedItem)
        {
            InitializeComponent();
            _vm = new UpdateUserVM(Navigation);
            BindingContext = _vm;
            _vm.User = selectedItem;
        }
    }
}
