using System.ComponentModel.DataAnnotations;
using AlaThuqk.DATA.DTOs.OrderItem;

namespace AlaThuqk.DATA.DTOs.Order;

public class OrderForm{
    [Required]
    public Guid? AddressId { get; set; }
    public bool? CanShare { get; set; }
    public string Note { get; set; }
    public List<OrderItemForm> OrderItems { get; set; }
}