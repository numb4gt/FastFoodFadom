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
    class FoodPageViewModel : ViewModelBase
    {
        private Food _foodSelected;

        public Food FoodSelected
        {
            get { return _foodSelected; }
            set
            {
                HowMach = 1;
                _foodSelected = value;
                OnPropertyChanged();
            }
        }


        private int _HowMach;

        public int HowMach 
        {
            get => _HowMach;
            set => Set(ref _HowMach, value);
        }


        public FastFoodFandomContext db = new FastFoodFandomContext();

        private List<Food> _list;

        public List<Food> List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(List));
            }
        }

        public ICommand AddToList { get; }

        private bool CanAddToList(object p)
        {
            if (FoodSelected != null)
            {
                return true;
            }
            return false;
        }

        

        private void OnAddToList(object p)
        {
            try
            {
                var toCustomer = new UserOrder();

                toCustomer.Name = FoodSelected.Name;
                toCustomer.OrderKey = MainCoast.Coast3;
                toCustomer.HowMach = HowMach.ToString();
                toCustomer.Coast = (FoodSelected.Coast * HowMach).ToString();

                db.UserOrder.Add(toCustomer);
                db.SaveChanges();
                MainCoast.Coast3++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public ICommand NullNewInDB { get; }

        private bool CanNull(object p)
        {
            if (FoodSelected != null)
            {
                return true;
            }
            return false;
        }

        private void OnGetNull(object p)
        {
            FoodSelected = null;
        }

        public FoodPageViewModel()
        {
            List = db.Food.ToList();
            AddToList = new LamdaCommand(OnAddToList, CanAddToList);
            NullNewInDB = new LamdaCommand(OnGetNull, CanNull);
        }

   
    }
}
