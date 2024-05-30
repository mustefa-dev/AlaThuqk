using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AlaThuqk.Entities
{
    public class AppUser : BaseEntity<Guid>
    {
        
        public string? PhoneNumber { get; set; }

        public string? Name { get; set; }

        public string? Password { get; set; }

        public UserRole? Role { get; set; }
        public List<Address> Addresses { get; set; }    
        
        public int Lat { get; set; }
        public int Long { get; set; }

    }
    
    public enum UserRole
    {
        None = 0,
        Admin = 1,
        User = 2,
    }
}