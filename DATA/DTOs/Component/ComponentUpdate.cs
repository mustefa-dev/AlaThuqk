
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs;

public class ComponentUpdate{
    public string Name { get; set; }
    public string Value { get; set; } // path or text depend on type
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public Guid TemplateId { get; set; }
    

}