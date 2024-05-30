using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class ProductRepository : GenericRepository<Product,Guid>, IProductRepository
    {
        
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}