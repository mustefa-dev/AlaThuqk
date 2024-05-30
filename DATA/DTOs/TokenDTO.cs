using AlaThuqk.Entities;

namespace AlaThuqk.DATA.DTOs;

public class TokenDTO{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public UserRole? Role { get; set; }
}