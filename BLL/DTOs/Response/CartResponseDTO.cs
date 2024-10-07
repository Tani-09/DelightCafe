using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Response
{
    public class CartResponseDTO
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Ouantity { get; set; }

    }
}
