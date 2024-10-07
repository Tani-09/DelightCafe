using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Request
{
    public class CustomerRequestDTO
    {

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; } = null!;

        [StringLength(30)]
        public string Password { get; set; } = null!;

        [StringLength(10)]
        public string PhoneNo { get; set; } = null!;

    }
}
