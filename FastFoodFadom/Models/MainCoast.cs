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
   
        public static int Coast = 1;

        public static int CoastGo(int value)
        {
            Coast += value;
            return Coast;
        }

        public static int Coast2 = 1;

        public static int CoastGo2(int value)
        {
            Coast2 += value;
            return Coast2;
        }

        public static int Coast3 = 1;

        public static int CoastGo3(int value)
        {
            Coast2 += value;
            return Coast2;
        }

    }
}
