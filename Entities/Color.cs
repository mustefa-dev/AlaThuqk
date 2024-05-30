using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AlaThuqk.Entities;

public class Color: BaseEntity<Guid>{
    public string ColorText { get; set; }
    public Guid SizeId { get; set; }
    public string FrontImage { get; set; }
    public int Quantity { get; set; }
    public Size? Size { get; set; }

}