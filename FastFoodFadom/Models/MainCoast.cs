using FastFoodFadom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastFoodFadom.Models
{
    internal class MainCoast
    {
   
        public static int Coast = 5;

        public static int CoastGo(int value)
        {
            Coast += value;
            return Coast;
        }

    }
}
