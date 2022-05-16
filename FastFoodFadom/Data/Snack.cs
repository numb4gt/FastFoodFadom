using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class Snack : ICloneable
    {
        public Snack()
        {
            OrderFromMenu = new HashSet<OrderFromMenu>();
        }

        public Snack(Snack other)
        {
            SnackId = other.SnackId;
            Name = other.Name;
            Coast = other.Coast;
            Image = other.Image;
        }

        public int SnackId { get; set; }
        public string Name { get; set; }
        public int Coast { get; set; }
        public string Image { get; set; }

        public virtual ICollection<OrderFromMenu> OrderFromMenu { get; set; }

        public object Clone()
        {
            return new Snack(this);
        }
    }
}
