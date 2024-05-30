using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs;

public class ProductForm {
    public string? Name { get; set; }
    public string[]? Images { get; set; } 
    public Guid CategoryId { get; set; }
    public string? SafeAreaHeight { get; set; }
    public string? SafeAreaWidth { get; set; }
    public string?Description { get; set; }
    public int? Price { get; set; }
    public string[]? Tags { get; set; }
    public List<SizeForm>? Sizes { get; set; }
    

}