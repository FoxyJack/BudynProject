using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneticsShop.Models
{
    public partial class Katanas
    {
        [Display(Name = "Produkt")]
        public int IdProduct { get; set; }
        public double Sharpness { get; set; }

        public Product IdProductNavigation { get; set; }
    }
}
