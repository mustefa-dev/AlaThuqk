using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Repository;
using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{

    public class AddressRepository : GenericRepository<Address , Guid> , IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}
