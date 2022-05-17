using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FastFoodFadom.ViewModels
{
    class TablePageViewModel : ViewModelBase
    {
        public FastFoodFandomContext db = new FastFoodFandomContext();

        private List<OrderFromMenu> _list;

        public List<OrderFromMenu> List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(List));
            }
        }


        private List<Order> _list2;

        public List<Order> List2
        {
            get { return _list2; }
            set
            {
                _list2 = value;
                OnPropertyChanged(nameof(List2));
            }
        }

        private Order _isSelected;

        public Order IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
               
            }
        }



        public ICommand MakeDone { get; }

        private bool CanMakeDone(object p)
        {
            return true;
        }

        private void OnMakeDone(object p)
        {
            if (IsSelected.Status == "Готов")
            {
                MessageBox.Show("Заказ уже готов");
                return;
            }


            IsSelected.Status = "Готов";
            db.SaveChanges();
            List2 = db.Order.ToList();
            MessageBox.Show("Заказ готов");
        }



        public ICommand GetNull { get; }

        private bool CanGetNull(object p)
        {
            if (IsSelected == null)
            {
                return false;
            }
            return true;
        }


        private void OnGetNull(object p)
        {
            IsSelected = null;

        }


        public TablePageViewModel()
        {
            List = db.OrderFromMenu.ToList();
            List2 = db.Order.ToList();

            MakeDone = new LamdaCommand(OnMakeDone, CanMakeDone);
            GetNull = new LamdaCommand(OnGetNull, CanGetNull);
        }





    }
}
