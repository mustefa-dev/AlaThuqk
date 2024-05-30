using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class PrintComponentRepository : GenericRepository<PrintComponent,Guid>, IPrintComponentRepository
    {
        
        private readonly DataContext _context;

        public PrintComponentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}