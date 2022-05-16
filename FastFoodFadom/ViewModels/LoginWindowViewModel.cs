using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.ViewModels.Base;
using FastFoodFadom.Views.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace FastFoodFadom.ViewModels
{
    class LoginWindowViewModel : ViewModelBase
    {


        public ICommand ChangeViewOnBackWindow { get; }

        private bool CanChangeViewOnBackWindow(object p) => true;

        private void OnChangeViewOnBackWindow(object p)
        {
         
            StartWindow main = new StartWindow();
            main.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = main;
        }

        public ICommand GoToAdmin { get; }

        private bool CanAdmin(object p) => true;

        private void OnChangeAdmin(object p)
        {

            AdminWindow main = new AdminWindow();
            main.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = main;
        }

        public LoginWindowViewModel()
        {
            ChangeViewOnBackWindow = new LamdaCommand(OnChangeViewOnBackWindow, CanChangeViewOnBackWindow);
            GoToAdmin = new LamdaCommand(OnChangeAdmin, CanAdmin);
        }
    }
}
