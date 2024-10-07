using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Response
{
    public class AddressResponseDTO
    {

        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Landmark { get; set; } = null!;
        public int UserId { get; set; }
    }
}
