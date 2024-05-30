using AlaThuqk.DATA.DTOs.PrintComponent;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs.OrderItem;

public class OrderItemForm{
    public OrderItemType Type { get; set; }
    public string? FinalImage { get; set; }
    public int Quantity { get; set; }
    public Guid ColorId { get; set; }
    public ICollection<PrintComponentForm>? PrintComponents { get; set; }
    public Guid? TemplateId { get; set; }
}