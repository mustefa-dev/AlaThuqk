    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    namespace AlaThuqk.Entities;

    public class Size: BaseEntity<Guid>{
        public string SizeText { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? TemplateId { get; set; }
        
        public ICollection<Color>? Colors { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("TemplateId")]
        public Template? Template { get; set; }
        
        

    }