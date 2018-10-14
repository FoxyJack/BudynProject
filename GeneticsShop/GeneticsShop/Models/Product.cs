using System;
using System.Collections.Generic;

namespace GeneticsShop.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Foxes Foxes { get; set; }
        public Katanas Katanas { get; set; }
    }
}
