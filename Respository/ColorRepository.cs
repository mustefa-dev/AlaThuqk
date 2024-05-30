using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class ColorRepository : GenericRepository<Color,Guid>, IColorRepository
    {
        
        private readonly DataContext _context;

        public ColorRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}