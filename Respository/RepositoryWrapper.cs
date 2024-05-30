using AlaThuqk
.DATA;
using AlaThuqk.Interface;
using AlaThuqk.Repository;
using BackEndStructuer.Interface;
using BackEndStructuer.Repository;
using Gaz_BackEnd.Interface;
using Gaz_BackEnd.Respository;

namespace AlaThuqk.Respository;

public class RepositoryWrapper : IRepositoryWrapper{
    private readonly DataContext _context;
        
    private IUserRepository? _user;
    private ICategoryRepository? _category;
    private ComponentRepository? _component;
    // private IOrderItemRepository? _orderItemRepository;
    private IOrderRepository? _orderRepository;
    private IColorRepository? _colorRepository;
    private ISizeRepository? _sizeRepository;
    private IProductRepository? _productRepository;
    private ITemplateRepository? _templateRepository;
    private IPrintComponentRepository? _printComponentRepository;
    private IUserLikeRepository? _userLike;
    private IOtpRepository? _otp;
    private IGovernoratesRepository? _governoratesRepository;
        
    public RepositoryWrapper(DataContext context)
    {
        _context = context;

    }
        
    public IPrintComponentRepository PrintComponent => _printComponentRepository ?? new PrintComponentRepository(_context);
    public IProductRepository Product => _productRepository ??= new ProductRepository(_context);
    public IComponentRepository Component => _component ??= new ComponentRepository(_context);
    public ITemplateRepository Template => _templateRepository ??= new TemplateRepository(_context);
    public ISizeRepository Size => _sizeRepository ??= new SizeRepository(_context);
    public IColorRepository Color => _colorRepository ??= new ColorRepository(_context);
    public ICategoryRepository Category => _category ??= new CategoryRepository(_context);
    public IUserRepository User => _user ??= new UserRepository(_context);
    public IOrderRepository Order => _orderRepository ??= new OrderRepository(_context);
    public IGovernoratesRepository Governorates => _governoratesRepository ??= new GovernoratesRepository(_context);
    public  ISettingRepository Setting => new SettingRepository(_context);
    // here to Add
private IAddressRepository _Address;

public IAddressRepository Address {
    get {
        if(_Address == null) {
            _Address = new AddressRepository(_context);
        }
        return _Address;
    }
}
    public IUserLikeRepository UserLike => _userLike ??= new UserLikeRepository(_context);
    public IOtpRepository Otp
    {
        get
        {
            if (_otp == null) {
                _otp = new OtpRepository(_context);
            }

            return _otp;
        }
    }
   

}
