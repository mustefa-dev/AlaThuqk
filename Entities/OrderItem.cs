using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AlaThuqk.Entities;

public class OrderItem : BaseEntity<Guid>{
    public int Quantity { get; set; }
    public string? FinalImage { get; set; }
    public ICollection<PrintComponent> PrintComponents { get; set; }
    public Guid ColorId { get; set; }

    public Guid? ProductId { get; set; }

    [ForeignKey(nameof(ProductId))] public Product? Product { get; set; }
    public Color Color { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid? TemplateId { get; set; }
    [ForeignKey(nameof(TemplateId))] public Template? Template { get; set; }

    public OrderItemType Type { get; set; } = OrderItemType.Product;
}

public enum OrderItemType{
    Product,
    Template
}