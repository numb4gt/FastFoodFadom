using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodFadom.Models
{
    class ListOrder
    {
        public int Key;

        public Food? _food;
        public Snack? _snack;
        public Drink? _drink;

        public int Count;

        public int Coast;


        public ListOrder(int _Key, Food food, Snack snack, Drink drink, int _Count, int _Coast)
        {
            Key = _Key;
            _food = food;
            _snack = snack;
            _drink = drink;
            Count = _Count;
            Coast = _Coast;
        }
    }
}
