using AlaThuqk.DATA.DTOs.Color;

namespace AlaThuqk.DATA.DTOs.Size;

public class SizeForm{
    public string SizeText { get; set; }
    public ICollection<ColorForm> Colors { get; set; }

}
