using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;
using FastFoodFadom.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace FastFoodFadom.ViewModels
{
    class LoginWindowViewModel : ViewModelBase
    {
        private string _password2;

        public string password2
        {
            get => _password2;
            set => Set(ref _password2, value);
        }

        private string _login;

        public string login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public FastFoodFandomContext db = new FastFoodFandomContext();

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

            if (login.Length <= 30 && login.Length > 4 && password2.Length <= 30 && password2.Length > 4)
            {
                var list = db.Admin.ToList();

                foreach (var item in list)
                {
                    if (item.Login == login)
                    {
                        if (item.Password == password2)
                        {
                            AdminWindow main = new AdminWindow();
                            main.Show();
                            App.Current.MainWindow.Close();
                            App.Current.MainWindow = main;
                            return;
                        }
                    }

                }

                MessageBox.Show("Неверный пароль или логин");


            }
            else
            {
                MessageBox.Show("Недопустимое значение пароля или логина");
            }



        }

        public LoginWindowViewModel()
        {
            ChangeViewOnBackWindow = new LamdaCommand(OnChangeViewOnBackWindow, CanChangeViewOnBackWindow);
            GoToAdmin = new LamdaCommand(OnChangeAdmin, CanAdmin);
        }
    }
}
