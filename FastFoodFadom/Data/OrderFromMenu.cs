using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class OrderFromMenu
    {
        public int CodOfOrder { get; set; }
        public int? CodOfFood { get; set; }
        public int? CodOfDrink { get; set; }
        public int? CodOfSnack { get; set; }
        public int Count { get; set; }
        public int Coast { get; set; }

        public virtual Drink CodOfDrinkNavigation { get; set; }
        public virtual Food CodOfFoodNavigation { get; set; }
        public virtual Snack CodOfSnackNavigation { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
