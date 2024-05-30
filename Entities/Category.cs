using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AlaThuqk.Entities;

public class Category : BaseEntity<Guid>{
    public string Name { get; set; }
    [NotMapped]
    [JsonIgnore]
    public ICollection<Product> Products { get; set; }
}