using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Request
{
    public class CategoryRequestDTO
    {
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

    }
}
