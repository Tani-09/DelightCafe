using System;
using System.Collections.Generic;

namespace Cafe_Delight.DAL.Entities
{
    public partial class FoodItem
    {
        public FoodItem()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }


        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
