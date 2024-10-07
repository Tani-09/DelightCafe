using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Response
{
    public class OrderDetailResponseDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Ouantity { get; set; }
        public double Price { get; set; }

    }
}
