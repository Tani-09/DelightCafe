namespace Cafe_Delight.BLL.DTOs.Request
{
    public class OrderRequestDTO
    {

        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }

    }
}
