using AlaThuqk.Interface;
using BackEndStructuer.Interface;
using Gaz_BackEnd.Interface;

namespace AlaThuqk.Repository{
    public interface IRepositoryWrapper{
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
        IColorRepository Color { get; }
        IComponentRepository Component { get; }

        IOrderRepository Order { get; }

        IPrintComponentRepository PrintComponent { get; }
        IProductRepository Product { get; }
        ISizeRepository Size { get; }
        ITemplateRepository Template { get; }
        IOtpRepository Otp { get; }
        IGovernoratesRepository Governorates { get; }

        // here to Add
        IAddressRepository Address { get; }
        IUserLikeRepository UserLike { get; }
        ISettingRepository Setting { get; }
    }
}
