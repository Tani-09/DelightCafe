using System;
using System.Collections.Generic;

namespace Cafe_Delight.DAL.Entities
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Ouantity { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual FoodItem Product { get; set; } = null!;
    }
}
