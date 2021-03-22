using System;
using System.Collections.Generic;
using dbmobiletest.ViewModels;
using Xamarin.Forms;

namespace dbmobiletest.Views
{
    public partial class SelectDB : ContentPage
    {

        SelectDBVM _vm;

        public SelectDB()
        {
            InitializeComponent();
            _vm = new SelectDBVM(Navigation);
            BindingContext = _vm;
        }
    }
}
