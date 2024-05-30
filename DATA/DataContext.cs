using AlaThuqk.Entities;
using BackEndStructuer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlaThuqk.DATA
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<AppUser> Users { get; set; }
 
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PrintComponent> PrintComponent { get; set; }
        public  DbSet<Address> Addresses { get; set; }
        public  DbSet<Otp> Otps { get; set; }
        public  DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
         
           

            // modelBuilder.Entity<Order>()
            //     .HasMany(o => o.OrderItems)
            //     .WithOne(o => o.Order)
            //     .HasForeignKey(o => o.OrderId);

            

            base.OnModelCreating(modelBuilder);

        }
        
    }
}