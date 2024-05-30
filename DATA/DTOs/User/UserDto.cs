using AlaThuqk.DATA.DTOs.Address;

namespace AlaThuqk.DATA.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public  AddressDto Address { get; set; }

    }
}