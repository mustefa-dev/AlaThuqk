using AlaThuqk.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs.DeliveryPriceFilter
{

    public class DeliveryPriceFilter : BaseFilter 
    {

        public Guid? GovernorateID { get; set; }
        public int? Price { get; set; }
    }
}
