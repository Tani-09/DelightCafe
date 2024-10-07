using System;
using System.Collections.Generic;

namespace Cafe_Delight.DAL.Entities
{
    public partial class Category
    {
        public Category()
        {
            FoodItems = new HashSet<FoodItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public virtual ICollection<FoodItem> FoodItems { get; set; }
    }
}
