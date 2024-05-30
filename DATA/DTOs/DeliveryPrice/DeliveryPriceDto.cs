using AlaThuqk.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs.DeliveryPriceDto
{

    public class DeliveryPriceDto : BaseDTO<Guid>
    {
        public Guid? GovernorateID { get; set; }
        public int? Price { get; set; }

    }
}
