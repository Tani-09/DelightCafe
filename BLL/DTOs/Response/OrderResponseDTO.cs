namespace Cafe_Delight.BLL.DTOs.Response
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
       
    }
}
