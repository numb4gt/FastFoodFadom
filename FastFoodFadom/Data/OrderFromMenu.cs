using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class OrderFromMenu
    {
        public int OrderKey { get; set; }
        public string NameOf { get; set; }
        public int? Count { get; set; }
        public int? Coast { get; set; }
        public int? SnackId { get; set; }
        public int? FoodId { get; set; }
        public int? Drinkid { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Food Food { get; set; }
        public virtual Snack Snack { get; set; }
    }
}
