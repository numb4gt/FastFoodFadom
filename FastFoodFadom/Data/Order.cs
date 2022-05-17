using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class Order
    {
        public int OrderKey { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string Coast { get; set; }
    }
}
