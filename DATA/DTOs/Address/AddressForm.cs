using Gaz_BackEnd.DATA.DTOs.Governorates;

namespace AlaThuqk.DATA.DTOs.Address{
    public class AddressUpdate{
        public GovernorateForm Governorate { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public int Phone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}