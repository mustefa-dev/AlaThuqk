using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class TemplateRepository : GenericRepository<Template,Guid>, ITemplateRepository
    {
        
        private readonly DataContext _context;

        public TemplateRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}