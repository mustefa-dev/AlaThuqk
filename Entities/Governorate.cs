namespace AlaThuqk.Entities;

public class Governorate : BaseEntity<Guid>{
    public string? Name { get; set; }
    public int DeliveryPrice { get; set; }
}