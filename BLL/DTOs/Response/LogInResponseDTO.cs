namespace Cafe_Delight.BLL.DTOs.Response
{
    public class LogInResponseDTO
    {

        public int Customerid { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
    }
}
