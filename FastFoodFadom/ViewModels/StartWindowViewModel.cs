using FastFoodFadom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Views.Windows;
using FastFoodFadom.Models;

namespace FastFoodFadom.ViewModels
{
    class StartWindowViewModel : ViewModelBase
    {
        public ICommand ChangeViewOnMainWindow { get; }

        private bool CanChangeViewOnMainWindow(object p) => true;

        private void OnChangeViewOnMainWindow(object p)
        {
            MainWindow main = new MainWindow();
            main.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = main;
        }

        FastFoodFandomContext db = new FastFoodFandomContext();

        public ICommand ChangeViewOnLoginWindow { get; }

        private bool CanChangeViewOnLoginWindow(object p) => true;

        private void OnChangeViewOnLoginWindow(object p)
        {
            LoginWindow main = new LoginWindow();
            main.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = main;
        }

        public ICommand Change { get; }

        private bool CanChange(object p) => true;

        private void OnChange(object p)
        {
            db.Order.RemoveRange(db.Order);
            db.SaveChanges();

            db.OrderFromMenu.RemoveRange(db.OrderFromMenu);
            db.SaveChanges();
        }






        public StartWindowViewModel()
        {
            MainCoast.Coast3 = 1;
            db.UserOrder.RemoveRange(db.UserOrder);
            db.SaveChanges();
            Change = new LamdaCommand(OnChange,CanChange);
            ChangeViewOnLoginWindow = new LamdaCommand(OnChangeViewOnLoginWindow,CanChangeViewOnLoginWindow);
            ChangeViewOnMainWindow = new LamdaCommand(OnChangeViewOnMainWindow,CanChangeViewOnMainWindow);
        }
    }
}
