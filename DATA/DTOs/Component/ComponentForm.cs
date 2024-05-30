

using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs;

public class ComponentForm{
    public string[] Images { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public Guid TemplateId { get; set; }
    

}