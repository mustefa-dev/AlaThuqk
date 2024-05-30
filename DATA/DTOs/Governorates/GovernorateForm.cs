using System.ComponentModel.DataAnnotations;

namespace Gaz_BackEnd.DATA.DTOs.Governorates{
    public class GovernorateForm{
        [Required] public string Name { get; set; }
        [Required] public int DeliveryPrice { get; set; }
    }
}