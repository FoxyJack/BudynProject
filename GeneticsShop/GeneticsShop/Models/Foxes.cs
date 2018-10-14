using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeneticsShop.Models
{
    public partial class Foxes
    {
        [Display(Name = "Produkt")]
        public int IdProduct { get; set; }
        public int Tails { get; set; }

        [Display(Name = "Nazwa")]
        public Product IdProductNavigation { get; set; }
    }
}
