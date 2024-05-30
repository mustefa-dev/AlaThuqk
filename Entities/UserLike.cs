using AlaThuqk.Entities;

namespace BackEndStructuer.Entities
{
    public class UserLike : BaseEntity<Guid>
    {
        public Guid? UserId { get; set; }
        public AppUser? User { get; set; }
        public Guid? TemplateId { get; set; }

        public Template? Template { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
