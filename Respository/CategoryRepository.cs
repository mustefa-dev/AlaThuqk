using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class CategoryRepository : GenericRepository<Category,Guid>, ICategoryRepository
    {
        
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}