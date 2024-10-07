using System;
using System.Collections.Generic;

namespace Cafe_Delight.DAL.Entities
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Ouantity { get; set; }
        public double Price { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual FoodItem Product { get; set; } = null!;
    }
}
