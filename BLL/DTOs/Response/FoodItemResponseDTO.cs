namespace Cafe_Delight.BLL.DTOs.Response
{
    public class FoodItemResponseDTO
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }

        public string? ImageUrl {  get; set; }

        

        public string CategoryName { get; set; }
    }
}
