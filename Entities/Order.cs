using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using OneSignalApi.Model;

namespace AlaThuqk.Entities;

public class Order : BaseEntity<Guid>{
    public int Phone { get; set; }

    public Guid AddressId { get; set; }
    [ForeignKey(nameof(AddressId))] 
    public Address? UserAddress { get; set; }
    public string Note { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus Status { get; set; }
    public bool? CanShare { get; set; }
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))] 
    public AppUser? User { get; set; }
    
    

    public double Price { get; set; }
    public double DeliveryPrice { get; set; }
    public double TotalPrice { get; set; }
}

public enum OrderStatus{
    Pending,
    Processing,
    Shipping,
    Completed,
    Cancelled
}