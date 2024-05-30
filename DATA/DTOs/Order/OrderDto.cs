using AlaThuqk.DATA.DTOs.Address;
using AlaThuqk.DATA.DTOs.OrderItem;
using AlaThuqk.DATA.DTOs.PrintComponent;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs.Order;

public class OrderDto : BaseDTO<Guid>{
    public int Phone { get; set; }
    public Guid UserId { get; set; }
    public bool CanShare { get; set; }

    public  AddressDto Address { get; set; }

    public string Note { get; set; }

    public int Quantity { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }

    public OrderStatus Status { get; set; }
    
    public int Price { get; set; }
    public int DeliveryPrice { get; set; }
    public int TotalPrice { get; set; }

}

public enum OrderStatus{
    Pending,
    Processing,
    Shipping,
    Completed,
    Cancelled
}