using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AlaThuqk.Entities;

public class PrintComponent : BaseEntity<Guid>{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public ItemType? Type { get; set; }
    public string? Value { get; set; }
    public int? X { get; set; }
    public int? Y { get; set; }
    public Guid? OrderItemId { get; set; }
    
    [ForeignKey(nameof(OrderItemId))]
    public OrderItem? OrderItem  { get; set; }
    public int? Z { get; set; }

}

public enum ItemType {
    Text,
    Image,
   
}