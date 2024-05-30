using System.ComponentModel.DataAnnotations;

namespace AlaThuqk.DATA.DTOs;

public class BaseDTO<TId>{
    [Key]
    public TId Id { get; set; }

    public DateTime? CreationDate { get; set; } = DateTime.UtcNow;
}