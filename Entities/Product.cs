    using BackEndStructuer.Entities;

    namespace AlaThuqk.Entities;

    public class Product: BaseEntity<Guid>{
        public string Name { get; set; }
        public string[] Images { get; set; }
        public Guid CategoryId { get; set; }
        
        public int Price { get; set; }
        public string Description { get; set; }

        public int Likes { get; set; }

        public ICollection<Size> Sizes { get; set; }
        public ICollection<UserLike> UserLikes { get; set; }
        public Category Category { get; set; }

    }