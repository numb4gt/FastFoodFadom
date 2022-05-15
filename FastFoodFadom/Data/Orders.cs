using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FastFoodFadom.Models
{
    public partial class Orders
    {
        public int CodOfOrder { get; set; }
        public DateTime? Date { get; set; }
        public int? Coast { get; set; }
        public string Status { get; set; }

        public virtual OrderFromMenu CodOfOrderNavigation { get; set; }
    }
}
