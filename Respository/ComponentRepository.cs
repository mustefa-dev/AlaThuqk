using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;
using AlaThuqk.Repository;

namespace AlaThuqk.Repository
{
    public class ComponentRepository : GenericRepository<Component,Guid>, IComponentRepository
    {
        
        private readonly DataContext _context;

        public ComponentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}