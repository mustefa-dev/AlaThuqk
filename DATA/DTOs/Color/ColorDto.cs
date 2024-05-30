using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs.Color;

public class ColorDto:BaseDTO<Guid>{
    public Guid Id { get; set; }
    public string ColorText { get; set; }
    public Guid SizeId { get; set; }
    public string FrontImage { get; set; }
    public int Quantity { get; set; }
}