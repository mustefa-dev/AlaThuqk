using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AlaThuqk.Entities;

public class Component: BaseEntity<Guid>{
    
    public string[] Images { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public Guid TemplateId { get; set; }
    
    public Template Template  { get; set; }

}
