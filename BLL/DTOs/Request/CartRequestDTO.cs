using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Request
{
    public class CartRequestDTO
    {

        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        [Range(1,int.MaxValue)]
        public int Ouantity { get; set; }

    }
}
