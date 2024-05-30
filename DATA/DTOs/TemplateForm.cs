using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs;

public class TemplateForm{
    public string? Name { get; set; }
    public string[]? Images { get; set; } 
    public Guid? CategoryId { get; set; }
    public string? SafeAreaHeight { get; set; }
    public string? SafeAreaWidth { get; set; }
    public string?Description { get; set; }
    public int? Price { get; set; }
    public string[]? Tags { get; set; }
    public List<SizeForm>? Sizes { get; set; }
    public List<ComponentForm> Components { get; set; }

}