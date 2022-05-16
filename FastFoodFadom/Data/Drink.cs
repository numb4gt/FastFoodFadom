﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class Drink : ICloneable
    {
        public Drink()
        {
            OrderFromMenu = new HashSet<OrderFromMenu>();
        }

        public Drink(Drink other)
        {
            DrinkId = other.DrinkId;
            Name = other.Name;
            Coast = other.Coast;
            Image = other.Image;
        }

        public int DrinkId { get; set; }
        public string Name { get; set; }
        public int Coast { get; set; }
        public string Image { get; set; }

        public virtual ICollection<OrderFromMenu> OrderFromMenu { get; set; }

        public object Clone()
        {
            return new Drink(this);
        }
    }
}
