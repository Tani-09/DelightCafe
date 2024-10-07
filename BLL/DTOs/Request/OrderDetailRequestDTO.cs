using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Request
{
    public class OrderDetailRequestDTO
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Ouantity { get; set; }

        [Range(1,double.MaxValue)]
        public double Price { get; set; }


    }
}
