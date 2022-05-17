using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class UserOrder
    {
        public int OrderKey { get; set; }
        public string Name { get; set; }
        public string HowMach { get; set; }
        public string Coast { get; set; }
        public int? FoodKey { get; set; }
    }
}
