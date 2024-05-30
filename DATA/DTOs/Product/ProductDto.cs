using AlaThuqk.DATA.DTOs.Size;

namespace AlaThuqk.DATA.DTOs.Product;

public class ProductDto : BaseDTO<Guid>{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Images { get; set; }

    public Guid CategoryId { get; set; }
    public int Price { get; set; }
    public int Likes { get; set; }
    public bool IsLiked { get; set; }
    public string? CategoryName { get; set; }
    public ICollection<SizeDto> Sizes { get; set; }
    public int? Quantity { get; set; }

}