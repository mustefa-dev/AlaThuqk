using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Interface
{
    public interface IOrderRepository : IGenericRepository<Order,Guid>
    {
        
    }
}