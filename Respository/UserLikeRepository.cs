using AlaThuqk.DATA;
using AlaThuqk.Repository;
using AutoMapper;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{

    public class UserLikeRepository : GenericRepository<UserLike , Guid> , IUserLikeRepository
    {
        public UserLikeRepository(DataContext context) : base(context)
        {
        }
    }
}
