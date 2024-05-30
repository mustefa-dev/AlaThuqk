using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlaThuqk.Entities
{
    public class Address : BaseEntity<Guid>
    {
        public Guid? GovernorateId { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone { get; set; } 
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        
        public Guid UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        [ForeignKey(nameof(GovernorateId))]
        public Governorate Governorate { get; set; }
    }
}