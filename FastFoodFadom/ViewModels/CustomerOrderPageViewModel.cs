using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;
using FastFoodFadom.Views.Windows;
using Microsoft.Win32;

namespace FastFoodFadom.ViewModels
{
    class CustomerOrderPageViewModel : ViewModelBase
    {

        private List<UserOrder> _list;

        public List<UserOrder> List2
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(List2));
            }
        }

        private UserOrder _foodSelected;

        public UserOrder FoodSelected
        {
            get { return _foodSelected; }
            set
            {
                _foodSelected = value;
                OnPropertyChanged();
            }
        }

        public ICommand Add { get; }

        private bool CanAdd(object p) => true;

        private void OnAdd(object p)
        {

            if(db.UserOrder.ToList().Count == 0)
            {
                MessageBox.Show("Ваш заказ пуст, внесите хотябы одну позицию");
                return;
            }



            var List = db.UserOrder.ToList();
            int a = 0;
            
            var order1 = new OrderFromMenu();


            foreach (var item in List)
            {
                order1.OrderKey = MainCoast.Coast;
                order1.NameOf = item.Name;
                order1.Count = Convert.ToInt32(item.HowMach);
                order1.Coast = Convert.ToInt32(item.Coast);
                db.OrderFromMenu.Add(order1);
                db.SaveChanges();
                MainCoast.Coast++;
            }

            foreach(var item in List)
            {
                a += Convert.ToInt32(item.Coast);
            }

            Order order = new Order();
            order.Date = DateTime.Now.ToString();
            order.Coast = a.ToString();
            order.OrderKey = MainCoast.Coast2;
            order.Status = "Не готов";
            MainCoast.Coast2++;
            db.Order.Add(order);
            db.SaveChanges();


            StartWindow main = new StartWindow();
            main.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = main;

        }


        public ICommand Delete { get; }

        private bool CanDelete(object p)
        {
            if (FoodSelected == null)
            {
                return false;
            }
            return true;
        }

        private void OnDelete(object p)
        {
            db.UserOrder.Remove(FoodSelected);
            db.SaveChanges();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List2 = db.UserOrder.ToList();
            
        }




        public FastFoodFandomContext db = new FastFoodFandomContext();




        public CustomerOrderPageViewModel()
        {
            List2 = db.UserOrder.ToList();
            Add = new LamdaCommand(OnAdd, CanAdd);
            Delete = new LamdaCommand(OnDelete, CanDelete);
        }

    }

}
