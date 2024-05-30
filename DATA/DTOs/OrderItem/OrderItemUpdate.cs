namespace AlaThuqk.DATA.DTOs.OrderItem;

public class OrderItemUpdate  {
    public string? FinalImage { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Guid ColorId { get; set; }
    public Guid SizeId { get; set; }  
    public Guid OrderId { get; set; }
    
}