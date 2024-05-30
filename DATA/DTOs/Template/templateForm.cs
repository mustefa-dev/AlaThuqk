namespace AlaThuqk.DATA.DTOs.Template;

public class templateForm{
    public Guid? ColorId { get; set; }
    public Entities.Color? Color { get; set; }
    public List<ComponentForm> Components { get; set; }
}