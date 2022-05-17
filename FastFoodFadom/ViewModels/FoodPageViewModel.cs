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
        private int _CodOfFood;


        public int CodOfFood
        {
            get => _CodOfFood;
            set => Set(ref _CodOfFood, value);
        }

        private string _Name;

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private int _Coast;

        public int Coast
        {
            get => _Coast;
            set => Set(ref _Coast, value);
        }

        private string _Image;

        public string Image
        {
            get => _Image;
            set => Set(ref _Image, value);
        }

        private Food _foodSelected;
        public bool isSelected = false;
        public List<Food> go = new List<Food>();

        public Food FoodSelected
        {
            get { return _foodSelected; }
            set
            {
                HowMach = 1;
                _foodSelected = value;
                OnPropertyChanged();
                if (isSelected == false)
                {
                    Updated = (Food)FoodSelected.Clone();
                }
                isSelected = false;
            }
        }

        private Food Updated;

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

        private string _ImageSource = "C:/Users/USER/Desktop/КП/Проект/FastFoodFadom/FastFoodFadom/Images/no-image.png";

        /// <summary>Заголовок окна</summary>
        public string ImageSource
        {
            get => _ImageSource;
            set => Set(ref _ImageSource, value);
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
                ListOrder arder = new ListOrder(FoodSelected.FoodId, FoodSelected, null, null, HowMach, FoodSelected.Coast * HowMach);
                ListPr.order.Add(arder);


                var toCustomer = new UserOrder();

                toCustomer.Name = FoodSelected.Name;
                toCustomer.OrderKey = FoodSelected.FoodId;
                toCustomer.HowMach = HowMach.ToString();
                toCustomer.Coast = (FoodSelected.Coast * HowMach).ToString();

                db.UserOrder.Add(toCustomer);
                db.SaveChanges();
               
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
            if (FoodSelected.Name != Updated.Name || FoodSelected.Image != Updated.Image || FoodSelected.Coast != Updated.Coast)
            {
                MessageBox.Show("У вас есть несохраненные изменения\nНажмите конпку Сохранить");
                return;
            }
            isSelected = true;
            FoodSelected = null;
        }



        public ICommand Add { get; }

        private bool Can(object p) => true;
        

        private void On(object p)
        {
                MessageBox.Show(ListPr.order[0]._food.Name.ToString());
        }





        public FoodPageViewModel()
        {
            List = db.Food.ToList();
            AddToList = new LamdaCommand(OnAddToList, CanAddToList);
            NullNewInDB = new LamdaCommand(OnGetNull, CanNull);
            Add = new LamdaCommand(On, Can);
        }

   
    }
}
