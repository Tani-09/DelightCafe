using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Request
{
    public class AddressRequestDTO
    {

        [StringLength(50)]
        public string City { get; set; } = null!;

        [StringLength(50)]
        public string State { get; set; } = null!;
        public string Pincode { get; set; } = null!;

        [StringLength(200)]
        public string StreetAddress { get; set; } = null!;

        [StringLength(200)]
        public string Landmark { get; set; } = null!;
        public int UserId { get; set; }

    }
}
