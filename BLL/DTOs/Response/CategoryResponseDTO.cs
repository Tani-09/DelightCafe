using System.ComponentModel.DataAnnotations;

namespace Cafe_Delight.BLL.DTOs.Response
{
    public class CategoryResponseDTO
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? ImageUrl {  get; set; }

    }
}
