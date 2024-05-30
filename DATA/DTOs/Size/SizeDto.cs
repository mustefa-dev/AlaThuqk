using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs.Size;

public class SizeDto : BaseDTO<Guid>{
    public string SizeText { get; set; }
    public Guid? ProductId { get; set; }

    public List<ColorDto> Colors { get; set; }
}