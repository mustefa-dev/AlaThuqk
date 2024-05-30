using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs;

public class TemplateUpdate{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string SafeAreaHeight { get; set; }
    public string SafeAreaWidth { get; set; }
    public int Price { get; set; }
    public string[] Tags { get; set; }
    public ICollection<SizeForm> Sizes { get; set; }
}