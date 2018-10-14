using System;
using System.Collections.Generic;

namespace GeneticsShop.Models
{
    public partial class Katanas
    {
        public int IdProduct { get; set; }
        public double Sharpness { get; set; }

        public Product IdProductNavigation { get; set; }
    }
}
