using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Repository
{
    public class OrderRepository : GenericRepository<Order,Guid>, IOrderRepository{
        
        private readonly DataContext _context;

        public OrderRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}