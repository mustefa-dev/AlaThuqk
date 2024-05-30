using System.Collections.ObjectModel;
using AlaThuqk.DATA.DTOs.Order;

namespace AlaThuqk.DATA.DTOs;

public class OrderUpdate{
    public int Phone { get; set; }
    public string Address { get; set; }
    public int Lat { get; set; }
    public int Long { get; set; }
    public string Note { get; set; }
    public OrderStatus Status { get; set; }
}