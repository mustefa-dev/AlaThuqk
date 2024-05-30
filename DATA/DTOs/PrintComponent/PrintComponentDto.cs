using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs.PrintComponent;

public class PrintComponentDto : BaseDTO<Guid>{
    public string? Name { get; set; }
    public ItemType? Type { get; set; }
    public string? Value { get; set; }
    public int? X { get; set; }
    public int? Y { get; set; }
    public int? Z { get; set; }
}