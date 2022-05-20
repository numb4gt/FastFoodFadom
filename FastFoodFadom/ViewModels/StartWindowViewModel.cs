using FastFoodFadom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Views.Windows;
using FastFoodFadom.Models;
using System.Diagnostics;
using System.Windows.Navigation;

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
            //NavigationService.Navigate(New Uri("/page2.xaml", UriKind.Relative)
            //Process.Start("https://app.diagrams.net/");



            Process.Start(new ProcessStartInfo("cmd", $"/c start https://eda.yandex.by/minsk?shippingType=delivery&utm_campaign=71992271.%5BEDA%5DDT_BR-goal_BY-HM-MIN_brand_restype-search_NU.460&utm_content=&utm_medium=cpc&utm_source=yasearch&utm_term=%D1%8F%D0%BD%D0%B4%D0%B5%D0%BA%D1%81%20%D0%B5%D0%B4%D0%B0%7Cpid%7C37012633128%7Caid%7C11843735974&yadclid=91361046&yadordid=171992271&yclid=7712555836419866623")
            {
                CreateNoWindow = true
            });

            //db.OrderFromMenu.RemoveRange(db.OrderFromMenu);
            //db.SaveChanges();

            //db.Order.RemoveRange(db.Order);
            //db.SaveChanges();
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
