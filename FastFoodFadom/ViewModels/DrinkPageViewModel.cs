﻿using FastFoodFadom.Infrastucture.Commands;
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
    class DrinkPageViewModel : ViewModelBase
    {
       
        private Drink _foodSelected;
       

        public Drink FoodSelected
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

        private List<Drink> _list;

        public List<Drink> List
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
            if (HowMach == 0)
            {
                MessageBox.Show("Ноль еды? Брат, потише");
                return;
            }
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

        public DrinkPageViewModel()
        {
            List = db.Drink.ToList();
            AddToList = new LamdaCommand(OnAddToList, CanAddToList);
            NullNewInDB = new LamdaCommand(OnGetNull, CanNull);
        }


    }


}

