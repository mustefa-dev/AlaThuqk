using System.ComponentModel.DataAnnotations.Schema;
using AlaThuqk.Entities;
using Newtonsoft.Json;

namespace AlaThuqk.DATA.DTOs;

public class PrintComponentUpdate {
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public string Value { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Guid OrderId { get; set; }
    public int Z { get; set; }

}
