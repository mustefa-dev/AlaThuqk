using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class SizeRepository : GenericRepository<Size,Guid>, ISizeRepository
    {
        
        private readonly DataContext _context;

        public SizeRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}