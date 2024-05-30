using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.DATA.DTOs.PrintComponent;
using AlaThuqk.DATA.DTOs.Product;
using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.DATA.DTOs.Template;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs.OrderItem;

public class OrderItemDto : BaseDTO<Guid>{
    public string? FinalImage { get; set; }

    public int Quantity { get; set; }

    public string? ProductId { get; set; }
    public string? Color { get; set; }
    public string? ColorId { get; set; }
    public string? Size { get; set; }
    public string? SizeId { get; set; }
    public ProductDto? Product { get; set; }

    public List<PrintComponentDto>? PrintComponents { get; set; }
    public TemplateDto? Template { get; set; }
    public Guid? TemplateId { get; set; }
}