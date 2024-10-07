using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Request
{
    public class FoodItemRequestDTO
    {
        [StringLength(50)]
        public string ItemName { get; set; } = null!;

        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(200)]
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }

        public string? ImageUrl {  get; set; }

          

       
    }
}
