using AlaThuqk.Entities;
using AlaThuqk.Interface;

namespace AlaThuqk.Interface
{
    public interface IProductRepository : IGenericRepository<Product,Guid>
    {
        
    }
}