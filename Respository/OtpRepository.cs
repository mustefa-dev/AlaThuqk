using AlaThuqk.DATA;
using AlaThuqk.Entities;
using AlaThuqk.Repository;
using Gaz_BackEnd.Interface;

namespace Gaz_BackEnd.Respository{
    public class OtpRepository : GenericRepository<Otp, Guid>, IOtpRepository{
        private readonly DataContext _context;

        public OtpRepository(DataContext context) : base(context) {
            _context = context;
        }
    }
}