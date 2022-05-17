using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFoodFadom.ViewModels
{
    class InteractiveTabloViewModel : ViewModelBase
    {
        private List<Order> _list1;

        public FastFoodFandomContext db = new FastFoodFandomContext();

        public List<Order> List1
        {
            get { return _list1; }
            set
            {
                _list1 = value;
                OnPropertyChanged(nameof(List1));
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

        private List<Order> _list3;

        public List<Order> List3
        {
            get { return _list3; }
            set
            {
                _list3 = value;
                OnPropertyChanged(nameof(List3));
            }
        }


        public InteractiveTabloViewModel()
        {
            List3 = db.Order.ToList();
            List2 = new List<Order>();
            List1 = new List<Order>();


            foreach (var item in List3)
            {
                if (item.Status == "Готов")
                {
                    List2.Add(item);
                }
                else
                {
                    List1.Add(item);
                }

            }
        }



    }
}
